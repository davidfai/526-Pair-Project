using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemycircle : MonoBehaviour
{
    public Vector3 posn1;

    public Vector3 posn2;
    public Vector3 posn3;
    public Vector3 posn4;
    public float speed;
    public float step;
    public int ink = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        step = Time.deltaTime * speed;

        if (transform.position == posn1)
        {

            ink = 1;

        }
        if (transform.position == posn2)
        {
            ink = 2;

        }
        if (transform.position == posn3)
        {
            ink = 3;

        }
        if (transform.position == posn4)
        {
            ink = 4;

        }

        switch (ink)
        {
            case 1:
                transform.position = Vector3.MoveTowards(transform.position, posn2, step);
                break;
            case 2:
                transform.position = Vector3.MoveTowards(transform.position, posn3, step);
                break;
            case 3:
                transform.position = Vector3.MoveTowards(transform.position, posn4, step);
                break;
            default:
                transform.position = Vector3.MoveTowards(transform.position, posn1, step);
                break;
        }
    }
}
