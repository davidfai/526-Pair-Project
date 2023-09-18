using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public TrailMeterManager trailMeterManager;
    public EndGoalManager endGoalManager;
    // player movement speed
    public float playerSpeed = 5f;
    // prefab used to represent the trail
    public GameObject decalPrefab;
    // player rotation speed when turning
    public float rotationSpeed = 45.0f; 
    // max number of decals spawned before
    public int maxDecals = 300;
    // interval of time when next decal is generated
    public float decalSpawnInterval = 0.2f;
    // control the turn speed of the player when moving left to right
    // decal counter
    public int currentDecals = 0;
    // track if player has arrived to end goal 1 (Point B)
    public bool endGoalFlagOne = false; 
    // distance of raycast
    private float raycastDistance = 2;
    // List containing all the prefabs trail objects generated to keep track
    private List<GameObject> trailList = new List<GameObject>();
    // store player's previous position
    private Vector3 playerPrevPosition;
    private void Start()
    {
        // initialize players previous position
        playerPrevPosition = transform.position;
    }
    void Update()
    {
        //Get input from arrow keys (or WASD) for player movement
        float veriticalInput = Input.GetAxisRaw("Vertical");
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        // calculate distance the player has traveled
        float distanceTraveled = Vector3.Distance(transform.position, playerPrevPosition);
        // update the trail meter
        if (trailMeterManager != null)
        {
            trailMeterManager.UpdateTrailPercentage();
        }
        else
        {
            Debug.LogWarning("TrailMeterManager reference is missing.");
        }
        // Calculate the direction the player is moving, normalize the movement so
        // that the speed of the player does not change in any direction.
        Vector3 movement = new Vector3( horizontalInput, 0f, veriticalInput).normalized;
        // if input is detected, player moves
        if( movement != Vector3.zero)
        {
            // store where you want the player to rotate (towards movement)
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            // set players rotation to the new rotation (toRotation) starting from the
            // initial rotation, set how fast we want the player to rotate from the initial
            // to final rotate transform.
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation,
                rotationSpeed * Time.deltaTime);
            // set players position to a new position based on player movement
            transform.position = transform.position + movement * playerSpeed * Time.deltaTime;

            // check if decal generation is set to true
            if(distanceTraveled >= decalSpawnInterval)
            {
                // Call method to generate a decal to create trail
                CreateTrail(transform.position - movement * 0.05f);
                // update previous position
                playerPrevPosition = transform.position;
            }

        }
    }
    void CreateTrail(Vector3 position)
    {
        // check if player has reached end goal one (point B)
        if (endGoalFlagOne)
        {
            // if yes then stop generating decals
            return;
        }
        if( currentDecals < maxDecals )
        {
            // Create a raycast from the player's position downward to detect the ground.
            Ray ray = new Ray(position, Vector3.down);
            RaycastHit hit;
            // Offset the decal position to be right on top of the ground surface.
            Vector3 offset = new Vector3(0f,0.01f,0f);
            // use raycast to set the position of the decal on top of the surface
            // of the level ground gameobject (need to add a Y-axis offset since
            // ground plane and decal are on same plane (sometimes not visible to see
            // decal)).
            if (Physics.Raycast(ray, out hit, raycastDistance, ~LayerMask.GetMask("Decals")))
            {
                Vector3 decalPosition = hit.point;
                // Instantiate a decal prefab at the adjusted position.
                GameObject newDecal = Instantiate(decalPrefab, decalPosition + offset, Quaternion.identity);
                // add newly generated prefab to list
                trailList.Add(newDecal);
                // increment current decal to reach max
                currentDecals++;
            }
        }
    }

    public void DeleteTrail(GameObject decal)
    {
        Destroy(decal);
    }

    public void OnPartOneFailure() 
    {
        // delete all decals to remove trail when 
        // part one failure condition is met
        foreach ( var obj in trailList )
        {
            Destroy( obj );
        }
        // delete all references to gameObjects from list
        trailList.Clear();
    }
}
