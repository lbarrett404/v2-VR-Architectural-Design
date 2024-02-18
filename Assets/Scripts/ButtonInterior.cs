using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonInterior : MonoBehaviour
{

    public UnityEvent onPressed, onReleased;
    public GameObject interiorOri;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Button")
        {
            onPressed?.Invoke();
            GameObject interiorClone = Instantiate(interiorOri);
            interiorClone.transform.position = interiorOri.transform.position;
        }
    }
}
