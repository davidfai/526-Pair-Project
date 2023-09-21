using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1up : MonoBehaviour
{
    public bool infected = false;
    public GameObject endpoint1;
    public GameObject player;
    public GameObject livecounter;
    public float step = 10;
    public float key = 10;
    public Material markNPC;
    // Start is called before the first frame update
    void Start()
    {
        endpoint1 = GameObject.Find("endPoint1");
        player = GameObject.Find("player");
        livecounter = GameObject.Find("health");
        step = Time.deltaTime * key;
    }

    // Update is called once per frame
    void Update()
    {
       if (infected && endpoint1.transform.GetComponent<EndGoalManager>().secondHalf)
        {
            transform.parent.GetComponent<infectconditionally>().infected = true;
        }


    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("infection"))
        {
            infected = true;
            transform.GetComponent<Renderer>().material = markNPC;
        }
        if(endpoint1.transform.GetComponent<EndGoalManager>().secondHalf && infected && other.CompareTag("Player"))
        {
            player.transform.position = Vector3.MoveTowards(player.transform.position, endpoint1.transform.position, step);
            livecounter.GetComponent<Livecounter>().lives -= 1;
            
        }
    }



}