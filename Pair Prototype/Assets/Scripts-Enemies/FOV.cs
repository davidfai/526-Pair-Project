using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOV : MonoBehaviour
{
    public float counter = 0;
    public Vector3 startposn;
    public Vector3 endposn;
    public float speed = 5;
    public float step = 1;
    public float timerange = 10;
    public bool infected = false;
    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        step = speed * Time.deltaTime;
        counter += Time.deltaTime;
        if (counter < timerange / 2)
        {
            transform.position = Vector3.MoveTowards(transform.position, endposn, step);

        }
        if (counter >= timerange / 2)
        {
            transform.position = Vector3.MoveTowards(transform.position, startposn, step);
        }
        if (counter >= timerange)
        {
            counter = 0;
        }
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
    
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            step = 5 * Time.deltaTime;
            transform.parent.gameObject.transform.GetChild(0).gameObject.transform.position= Vector3.MoveTowards(transform.parent.gameObject.transform.GetChild(0).gameObject.transform.position, other.gameObject.transform.position, step);
            transform.position = Vector3.MoveTowards(transform.position, other.gameObject.transform.position, step);
        }
        
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            transform.parent.gameObject.transform.GetChild(0).gameObject.transform.position =Vector3.MoveTowards(transform.parent.gameObject.transform.GetChild(0).gameObject.transform.position, transform.parent.gameObject.transform.GetChild(0).gameObject.GetComponent<Enemy1up>().startposn,step);
            transform.position = Vector3.MoveTowards(transform.position, startposn, step); 
        }
    }

}
