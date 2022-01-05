using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetMaterial : MonoBehaviour
{

    public Material newMaterial;
    
    // Start is called before the first frame update
    void Start()
    {
        Renderer[] children = transform.GetComponentsInChildren<Renderer>();

        foreach (Renderer child in children)
        {
            child.material = newMaterial;
        }
        
    }

}
