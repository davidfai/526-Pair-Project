using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOV : MonoBehaviour
{
    public GameObject endpoint1;
    public bool infected = false;
    public float step;
    public Vector3 startposn;
    public Vector3 startposncyl;
    public AudioSource audioSource;
    public AudioClip clip;
    public bool chase=false;
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

            audioSource.Play();
            step = 4 * Time.deltaTime;
            transform.parent.gameObject.transform.GetChild(0).gameObject.transform.position = Vector3.MoveTowards(transform.parent.gameObject.transform.GetChild(0).gameObject.transform.position, other.gameObject.transform.position, step);
            transform.position = Vector3.MoveTowards(transform.position, other.gameObject.transform.position, step);




        }


    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && infected)
        {
           
            step = 4 * Time.deltaTime;
            transform.parent.gameObject.transform.GetChild(0).gameObject.transform.position = Vector3.MoveTowards(transform.parent.gameObject.transform.GetChild(0).gameObject.transform.position, other.gameObject.transform.position, step);
            transform.position = Vector3.MoveTowards(transform.position, other.gameObject.transform.position, step);
            
            
            

        }

    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && endpoint1.transform.GetComponent<EndGoalManager>().secondHalf)
        {
            step = 0;
            /*transform.parent.gameObject.transform.GetChild(0).gameObject.transform.position = Vector3.MoveTowards(transform.parent.gameObject.transform.GetChild(0).gameObject.transform.position, startposncyl, step);
            transform.position = Vector3.MoveTowards(transform.position, startposn, step);*/
            chase = false;
            transform.parent.gameObject.GetComponent<infectconditionally>().speed = 0;
            transform.parent.gameObject.transform.position = Vector3.MoveTowards(transform.parent.gameObject.transform.position, transform.parent.gameObject.GetComponent<infectconditionally>().startposn, step);

            audioSource.Stop();
        }
    }
    

}
