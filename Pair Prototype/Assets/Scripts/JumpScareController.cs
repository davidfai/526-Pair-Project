using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build.Reporting;
using UnityEngine;

public class JumpScareController : MonoBehaviour
{
    public GameObject jumpScareNPC;
    public Transform initialPosition;
    public Transform finalPosition;
    public PlayerMovement playerMovement;
    public float jumpScareSpeed = 30f;
    private float step;
    private bool hasJumpScareOnce = false;
    private bool canJumpScare = false;

    private void Start()
    {
        jumpScareNPC.SetActive(false);
        jumpScareNPC.transform.position = initialPosition.position;
    }

    private void Update()
    {
        if (!hasJumpScareOnce && canJumpScare)
        {
            step = jumpScareSpeed * Time.deltaTime;
            jumpScareNPC.transform.position = Vector3.MoveTowards(jumpScareNPC.transform.position, finalPosition.position, step);
            if(jumpScareNPC.transform.position == finalPosition.position)
            {
                hasJumpScareOnce=true;
                canJumpScare=false;
                jumpScareNPC.SetActive(false);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player") && !canJumpScare && !hasJumpScareOnce 
            && playerMovement.endGoalFlagOne)
        {
            canJumpScare = true;
            jumpScareNPC.SetActive(true) ;
        }
        
    }
}
