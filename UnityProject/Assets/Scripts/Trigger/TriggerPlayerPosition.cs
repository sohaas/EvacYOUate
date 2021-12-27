using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPlayerPosition : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            EventManager.instance.LeftInteraction();
        }
    }
}
