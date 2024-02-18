using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonExterior : MonoBehaviour
{

    public UnityEvent onPressed, onReleased;
    public GameObject exteriorOri;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Button")
        {
            onPressed?.Invoke();
            GameObject exteriorClone = Instantiate(exteriorOri);
            exteriorClone.transform.position = exteriorOri.transform.position;
        }
    }
}
