using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopFace : MonoBehaviour
{
    // Start is called before the first frame update
    public Material topFaceMaterial;
    void Start()
    {
        MeshRenderer renderer = GetComponent<MeshRenderer>();

        if (renderer != null && topFaceMaterial != null)
        {
            Material[] materials = renderer.materials;

            if (materials.Length > 5) // Check if the cube has at least 6 materials (one for each face).
            {
                // Assign the new material to the top face (index 4).
                materials[4] = topFaceMaterial;
                renderer.materials = materials;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
