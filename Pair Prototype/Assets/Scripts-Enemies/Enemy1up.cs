using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1up : MonoBehaviour
{
    public float counter = 0;
    public Vector3 startposn;
    public Vector3 endposn;
    public float speed = 5;
    public float step = 1;
    public float timerange = 10;
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
        if (counter<timerange/2)
        {
            transform.position = Vector3.MoveTowards(transform.position, endposn, step);

        }
        if (counter >= timerange/2)
        {
            transform.position = Vector3.MoveTowards(transform.position, startposn, step);
        }
        if (counter >= timerange)
        {
            counter = 0;
        }
        
    }
}
