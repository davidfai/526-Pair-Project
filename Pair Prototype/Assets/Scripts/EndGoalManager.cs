using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGoalManager : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public GameObject goalOne;
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerMovement.endGoalFlagOne = true;
        }
    }
}
