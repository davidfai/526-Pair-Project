using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // The target to follow (the player).
    public Transform target;
    // camera is above player
    private Vector3 offset = new Vector3 (0, 10, 0);

    // Update is called once per frame
    void LateUpdate()
    {

        //reposition camera to players position
        transform.position = target.transform.position + offset;
    }
}
