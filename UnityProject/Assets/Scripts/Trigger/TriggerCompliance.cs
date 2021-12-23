using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCompliance : MonoBehaviour
{
    public int id;
    public int degree;

    private void OnTriggerEnter(Collider other)
    {
        // TODO: Tag for Player
        if (other.gameObject.tag != "Robot")
        {
            EventManager.instance.Complied(id, degree);
        }
    }
}
