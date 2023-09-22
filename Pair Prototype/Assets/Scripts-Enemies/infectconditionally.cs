using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class infectconditionally : MonoBehaviour
{
    public bool infected = false;
    public Material infectedmaterial;
    public Material myMaterial;
    public float counter = 0;
    public Vector3 startposn;
    public Vector3 endposn;
    public float speed = 5;
    public float step = 1;
    public float timerange = 10;
    public GameObject endpoint1;
    public Material markNPC;
    public bool circle=false;
    public Vector3 posn1;
    public bool still = false;
    public Vector3 posn2;
    public Vector3 posn3;
    public Vector3 posn4;
   
    public int ink = 1;
    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
        endpoint1 = GameObject.Find("endPoint1");
    }

    // Update is called once per frame
    void Update()
    {
        if (!still)
        {
            if (!circle)
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
            }
            else
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
        

        if (infected)
        {
            gameObject.transform.GetChild(0).gameObject.GetComponent<Renderer>().material = infectedmaterial;
            gameObject.transform.GetChild(1).gameObject.transform.localScale = new Vector3(5, 0.05f, 5);
            gameObject.transform.GetChild(1).gameObject.tag = "Infected";

        }
        else if(!infected && endpoint1.transform.GetComponent<EndGoalManager>().secondHalf)
        {
            gameObject.transform.GetChild(0).gameObject.GetComponent<Renderer>().material = myMaterial;
            gameObject.transform.GetChild(1).gameObject.transform.localScale = new Vector3(5, 0.05f, 5);
            gameObject.transform.GetChild(1).gameObject.tag = "NPC";
        }
    



    }
}
