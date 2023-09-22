using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOV : MonoBehaviour
{
    public GameObject bodyOfNPC;
    public GameObject endpoint1;
    public bool infected = false;
    public float step;
    public float detectDistance;
    public Vector3 startposn;
    public Vector3 startposncyl;
    public AudioSource audioSource;
    public AudioClip clip;
    public bool canSee = false;
    public bool isAudioOn = false;
    // Start is called before the first frame update
    void Start()
    {
        audioSource.Stop();
        endpoint1 = GameObject.Find("endPoint1");
    }

    // Update is called once per frame
    void Update()
    {
        
        if (gameObject.tag == "Infected")
        {
            infected = true;
        }
        else
        {
            infected = false;
        }
        if (infected)
        {
            var fov = GetComponent<Collider>();
            fov.isTrigger = true;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && infected)
        {

            //audioSource.Play();
            step = 2.5f * Time.deltaTime;
            transform.parent.gameObject.transform.GetChild(0).gameObject.transform.position = Vector3.MoveTowards(transform.parent.gameObject.transform.GetChild(0).gameObject.transform.position, other.gameObject.transform.position, step);
            transform.position = Vector3.MoveTowards(transform.position, other.gameObject.transform.position, step);




        }
        /*if (other.CompareTag("wall"))
        {

            step = 0;
            *//*transform.parent.gameObject.transform.GetChild(0).gameObject.transform.position = Vector3.MoveTowards(transform.parent.gameObject.transform.GetChild(0).gameObject.transform.position, startposncyl, step);
            transform.position = Vector3.MoveTowards(transform.position, startposn, step);*//*
            chase = false;
            transform.parent.gameObject.GetComponent<infectconditionally>().speed = 0;
            transform.parent.gameObject.transform.position = Vector3.MoveTowards(transform.parent.gameObject.transform.position, transform.parent.gameObject.GetComponent<infectconditionally>().startposn, step);

            //audioSource.Stop();



        }*/


    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && infected)
        {
            Vector3 directionToPlayer = (other.transform.position - bodyOfNPC.transform.position).normalized * 10;
            RaycastHit hit;
            if (Physics.Raycast(bodyOfNPC.transform.position, directionToPlayer, out hit))
            {
                if(hit.collider.CompareTag("Player"))
                {
                    canSee = true;
                    if (!isAudioOn)
                    {
                        audioSource.Play();
                        isAudioOn = true;
                    }
                    step = 2.5f * Time.deltaTime;
                    transform.parent.gameObject.transform.GetChild(0).gameObject.transform.position = Vector3.MoveTowards(transform.parent.gameObject.transform.GetChild(0).gameObject.transform.position, other.gameObject.transform.position, step);
                    transform.position = Vector3.MoveTowards(transform.position, other.gameObject.transform.position, step);
                    Debug.DrawRay(transform.position, directionToPlayer.normalized * hit.distance, Color.red);
                }
                else
                {
                    canSee = false;
                }
            }
            
            
            

        }

    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && endpoint1.transform.GetComponent<EndGoalManager>().secondHalf)
        {
            step = 0;
            /*transform.parent.gameObject.transform.GetChild(0).gameObject.transform.position = Vector3.MoveTowards(transform.parent.gameObject.transform.GetChild(0).gameObject.transform.position, startposncyl, step);
            transform.position = Vector3.MoveTowards(transform.position, startposn, step);*/
            transform.parent.gameObject.GetComponent<infectconditionally>().speed = 0;
            transform.parent.gameObject.transform.position = Vector3.MoveTowards(transform.parent.gameObject.transform.position, transform.parent.gameObject.GetComponent<infectconditionally>().startposn, step);

            audioSource.Stop();
            isAudioOn = false;
        }
    }
    

}
