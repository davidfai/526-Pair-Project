using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailController : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private void OnTriggerEnter(Collider other)
    {
        playerMovement = other.GetComponent<PlayerMovement>();
        if (playerMovement == null){ return;}
        if (!playerMovement.endGoalFlagOne){ return;}
        if (!other.CompareTag("Player")){ return;}
        Destroy(gameObject);
        playerMovement.currentDecals--;
    }
}
