using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGoalManager : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public Light playerLight;
    public Light directionalLight;
    public GameObject goal;

    private void Start()
    {
        RenderSettings.ambientLight = Color.white;
        playerLight.enabled = false;
        directionalLight.enabled = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")){ return;}
        if (goal == GameObject.Find("endPoint1")) 
        { 
            playerMovement.endGoalFlagOne = true;
            RenderSettings.ambientLight = Color.black;
            playerLight.enabled = true;
            directionalLight.enabled = false;
        }
        if (goal != GameObject.Find("endPoint2")){ return;}
        if (!playerMovement.endGoalFlagOne){ return;}
        if (playerMovement.currentDecals != 0) { return;}
        Debug.Log("Game Complete!"); 
    }
}
