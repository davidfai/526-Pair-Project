using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float hinp;
    private float vinp;
    public float speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hinp=Input.GetAxis("Horizontal");
        vinp = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * Time.deltaTime * vinp * speed);
        transform.Translate(Vector3.right* Time.deltaTime * hinp * speed);
    }
}
