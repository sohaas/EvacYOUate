using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compliance : MonoBehaviour
{
    public int id;
    public int degree;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            EventManager.instance.Complied(id, degree);
        }
    }
}
