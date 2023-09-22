using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;

using UnityEngine;

public class JumpScareController : MonoBehaviour
{
    public GameObject jumpScareNPC;
    public Transform initialPosition;
    public Transform finalPosition;
    public PlayerMovement playerMovement;
    public AudioSource jumpScareAudio;
    public float jumpScareSpeed = 30f;
    public float delayTime = 0.05f;
    private float step;
    public bool hasJumpScareOnce = false;
    public bool canJumpScare = false;

    private void Start()
    {
        jumpScareNPC.SetActive(false);
        jumpScareNPC.transform.position = initialPosition.position;
    }

    private void Update()
    {
        if (!hasJumpScareOnce && canJumpScare)
        {
            float distance = Vector3.Distance(jumpScareNPC.transform.position, finalPosition.position);
            step = jumpScareSpeed * Time.deltaTime;
            step = Mathf.Min(step, distance);
            jumpScareNPC.transform.position = Vector3.MoveTowards(jumpScareNPC.transform.position, finalPosition.position, step);
            
            if (Vector3.Distance(jumpScareNPC.transform.position, finalPosition.position) < 0.01f)
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
            StartCoroutine(DelayScareEvent());
            jumpScareAudio.Play();
        }
        
    }

    private IEnumerator DelayScareEvent()
    {
        yield return new WaitForSeconds(delayTime);
        canJumpScare = true;
        jumpScareNPC.SetActive(true);
    }
}
