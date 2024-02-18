using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RotateWall : MonoBehaviour
{
    public UnityEvent onPressed, onReleased;
    //public string socketParent = "SocketGroup";
    public GameObject socket;
    public float deadtime = 1.0f;
    private bool _deadtimeactive = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!_deadtimeactive)
        {
            onPressed?.Invoke();
            socket.transform.Rotate(0f, 90f, 0f);
            Debug.Log("get rotated bozo");
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
