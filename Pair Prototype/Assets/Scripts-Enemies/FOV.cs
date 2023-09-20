using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOV : MonoBehaviour
{
    
    public bool infected = false;
    public float step;
    public Vector3 startposn;
    public Vector3 endposn;
    // Start is called before the first frame update
    void Start()
    {
        
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
    
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            step = 4 * Time.deltaTime;
            transform.parent.gameObject.transform.GetChild(0).gameObject.transform.position= Vector3.MoveTowards(transform.parent.gameObject.transform.GetChild(0).gameObject.transform.position, other.gameObject.transform.position, step);
            transform.position = Vector3.MoveTowards(transform.position, other.gameObject.transform.position, step);
        }
        
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            transform.parent.gameObject.transform.position =Vector3.MoveTowards(transform.parent.gameObject.transform.position, transform.parent.gameObject.GetComponent<infectconditionally>().startposn,step);
            
        }
    }

}
