using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        NextButton.buttonListener = true;
    }
}
