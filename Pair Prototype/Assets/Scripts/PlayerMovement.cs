using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // player movement speed
    public float playerSpeed = 5f;
    // prefab used to represent the trail
    public GameObject decalPrefab;
    // max number of decals spawned before
    public int maxDecals = 10;
    // interval of time when next decal is generated
    public float decalSpawnInterval = 0.05f;
    // decal counter
    private int currentDecals = 0;
    // initialize decal generation to true
    private bool genDecal = true;
    
    void Update()
    {
        //Get input from arrow keys (or WASD) for player movement
        float veriticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        
        // Calculate the direction the player is moving, normalize the movement so
        // that the speed of the player does not change in any direction.
        Vector3 movement = new Vector3(horizontalInput, 0f, veriticalInput).normalized;

        // if input is detected, player moves
        if( movement != Vector3.zero)
        {
            // set players position to a new position based on player movement
            transform.position = transform.position + movement * playerSpeed * Time.deltaTime;
            // check if decal generation is set to true
            if(genDecal)
            {
                // start a coroutine to delay the decal generation (so that not so many decals
                // are generated at once, increases performance) and adjust where the decal is 
                // generated, slightly behind the player game object.
                StartCoroutine(CreateTrail(transform.position - movement * 0.05f));
            }

        }
    }

    IEnumerator CreateTrail(Vector3 position)
    {
        genDecal = false;
        if( currentDecals < maxDecals )
        {
            //wait for specified time before creating another decal
            yield return new WaitForSeconds( decalSpawnInterval );
            // Create a raycast from the player's position downward to detect the ground.
            Ray ray = new Ray(position, Vector3.down);
            RaycastHit hit;
            // Offset the decal position to be right on top of the ground surface.
            Vector3 offset = new Vector3(0f,0.01f,0f);
            // use raycast to set the position of the decal on top of the surface
            // of the level ground gameobject (need to add a Y-axis offset since
            // ground plane and decal are on same plane (sometimes not visible to see
            // decal)).
            if (Physics.Raycast(ray, out hit))
            {
                Vector3 decalPosition = hit.point;
                // Instantiate a decal prefab at the adjusted position.
                Instantiate(decalPrefab, decalPosition + offset, Quaternion.identity);
                // increment current decal to reach max
                currentDecals++;
            }
        } 
        genDecal=true;
    }
}
