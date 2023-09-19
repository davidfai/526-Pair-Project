using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemycircle : MonoBehaviour
{
    public float amplitude=5;
    public float frequency=5;
    public float xoffset=1;
    public float zoffset=1;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Mathf.Cos(Time.time * frequency)*amplitude;
        float y = transform.position.y;
        float z = Mathf.Sin(Time.time * frequency) * amplitude;
        transform.position = new Vector3(x + xoffset,y,z + zoffset);
    }
}
