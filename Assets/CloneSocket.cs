using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class CloneSocket : MonoBehaviour
{

    [SerializeField] GameObject clonePrefab;

	public void CloneInteractable(SelectExitEventArgs args)
	{
		XRBaseInteractor socket = args.interactor;
		GameObject gameObjectClone = Instantiate(clonePrefab, socket.transform.position, socket.transform.rotation);
		socket.GetComponent<XRSocketInteractor>().StartManualInteraction(gameObjectClone.GetComponent<XRBaseInteractable>());
	}
}
