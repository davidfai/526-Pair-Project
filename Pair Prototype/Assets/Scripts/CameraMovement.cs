using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // The target to follow (the player).
    public Transform target;
    public PlayerMovement playerMovement;
    public bool isFlipped = false;
    // camera is above player
    private Vector3 offsetPartOne = new Vector3 (0, 10, 1);
    private Vector3 offsetPartTwo = new Vector3(0, 10, -1);
    // Update is called once per frame
    void LateUpdate()
    {
        if(playerMovement.endGoalFlagOne && !isFlipped) 
        {
            transform.Rotate(180, 180, 0);
            isFlipped = true;
        }

        if (isFlipped)
        {
            transform.position = target.transform.position + offsetPartTwo;
        }
        else
        {
            transform.position = target.transform.position + offsetPartOne;
        }
        
    }
}
