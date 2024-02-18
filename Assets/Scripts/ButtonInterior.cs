using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonInterior : MonoBehaviour
{

    public UnityEvent onPressed, onReleased;
    public GameObject interiorOri;
    public float deadtime = 5.0f;
    private bool _deadtimeactive = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!_deadtimeactive)
        {
            onPressed?.Invoke();
            GameObject interiorClone = Instantiate(interiorOri);
            interiorClone.transform.position = new Vector3(1.4f, 1.4f, .1f);
            Debug.Log("Button Pressed");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!_deadtimeactive)
        {
            onReleased?.Invoke();
            Debug.Log("Button Released");
            StartCoroutine(WaitForDeadTime());
        }
    }

    IEnumerator WaitForDeadTime()
    {
        _deadtimeactive = true;
        yield return new WaitForSeconds(deadtime);
        _deadtimeactive = false;
    }
}
