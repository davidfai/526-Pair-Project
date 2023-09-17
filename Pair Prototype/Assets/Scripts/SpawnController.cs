using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public Transform spawnPointOne;
    void Update()
    {
        if (playerMovement.currentDecals >= playerMovement.maxDecals)
        {
            // set player position to spawn position one (part one of game)
            playerMovement.transform.position = spawnPointOne.position;
            // reset the trail meter and to restart generating trail
            playerMovement.currentDecals = 0;
            // delete all existing trail pieces from level
            playerMovement.OnPartOneFailure();
        }
    }

}
