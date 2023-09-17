using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailController : MonoBehaviour
{
    public float normalPlayerSpeed = 5f;
    public float slowedPlayerSpeed = 2.5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
            if (playerMovement != null)
            {
                //playerMovement.SetPlayerSpeed(slowedPlayerSpeed);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
            if (playerMovement != null)
            {
                //playerMovement.SetPlayerSpeed(normalPlayerSpeed);
            }
        }
    }
}
