using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGoalManager : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public GameObject goal;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")){ return;}
        if (goal == GameObject.Find("endPoint1")) { playerMovement.endGoalFlagOne = true;}
        if (goal != GameObject.Find("endPoint2")){ return;}
        if (!playerMovement.endGoalFlagOne){ return;}
        if (playerMovement.currentDecals != 0) { return;}
        Debug.Log("Game Complete!"); 
    }
}
