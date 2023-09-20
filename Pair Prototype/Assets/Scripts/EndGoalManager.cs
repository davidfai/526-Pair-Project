using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGoalManager : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public Light playerLight;
    public Light directionalLight;
    public GameObject goal;
    public bool secondhalf=false;

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
            secondhalf = true;
        }
        if (goal != GameObject.Find("endPoint2")){ return;}
        if (!playerMovement.endGoalFlagOne){ return;}
        if (playerMovement.currentDecals != 0) { return;}
       
    }
}
