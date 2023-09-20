using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1up : MonoBehaviour
{
    public bool infected = false;
    public GameObject endpoint1;
    public GameObject player;
    public float step =10;
    public float key = 10;
    // Start is called before the first frame update
    void Start()
    {
       endpoint1= GameObject.Find("endPoint1");
        player = GameObject.Find("player");
        step = Time.deltaTime * key;
    }

    // Update is called once per frame
    void Update()
    {
       if (infected && endpoint1.transform.GetComponent<EndGoalManager>().secondhalf)
        {
            transform.parent.GetComponent<infectconditionally>().infected = true;
        }


    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("infection"))
        { 
            infected = true;
        }
        if(endpoint1.transform.GetComponent<EndGoalManager>().secondhalf && infected && other.CompareTag("Player"))
        {
            player.transform.position = Vector3.MoveTowards(player.transform.position, endpoint1.transform.position, step); ;
        }
    }



}