using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class infectconditionally : MonoBehaviour
{
    public bool infected = true;
    public Material infectedmaterial;
    public Material myMaterial;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (infected)
        {
            gameObject.transform.GetChild(0).gameObject.GetComponent<Renderer>().material = infectedmaterial;
            gameObject.transform.GetChild(1).gameObject.transform.localScale = new Vector3(5,0.05f,5);
            gameObject.transform.GetChild(1).gameObject.tag = "Infected";
           
        }
        else
        {
            gameObject.transform.GetChild(0).gameObject.GetComponent<Renderer>().material = myMaterial;
            gameObject.transform.GetChild(1).gameObject.transform.localScale = new Vector3(0, 0, 0);
            gameObject.transform.GetChild(1).gameObject.tag = null;

        }

    }
}
