using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class socketRotator : MonoBehaviour
{
    // Called when a collision occurs
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object is tagged as "Rotateable"
        if (collision.gameObject.tag == "Socket")
        {
            // Rotate the collided socket object
            RotateSocket(collision.gameObject);
        }
    }

    // Rotate a socket object
    private void RotateSocket(GameObject socket)
    {
        // Perform the rotation
        socket.transform.Rotate(0f, 90f, 0f);
        Debug.Log("rotated");
    }
}
