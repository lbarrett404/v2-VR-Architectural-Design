using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonExterior : MonoBehaviour
{

    public UnityEvent onPressed, onReleased;
    public GameObject exteriorOri;
    public GameObject platform1;
    public GameObject platform2;
    public float deadtime = 5.0f;
    private bool _deadtimeactive = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!_deadtimeactive)
        {
            onPressed?.Invoke();

            Vector3 platformPosition = platform1.transform.position;
            Vector3 platformPosition2 = platform2.transform.position;

            // Extract the X, Y, and Z coordinates
            float platformX = platformPosition.x;
            float platformY = platformPosition.y + 1f; // Add 0.5 to the Y position
            float platformZ = platformPosition.z;

            float platform2X = platformPosition2.x;
            float platform2Y = platformPosition2.y + 1f; // Add 0.5 to the Y position
            float platform2Z = platformPosition2.z;

            GameObject exteriorClone = Instantiate(exteriorOri);
            exteriorClone.transform.position = new Vector3(platformX, platformY, platformZ);

            GameObject exteriorClone2 = Instantiate(exteriorOri);
            exteriorClone2.transform.position = new Vector3(platform2X, platform2Y, platform2Z);

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

