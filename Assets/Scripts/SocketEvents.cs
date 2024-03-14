using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

using UnityEngine.XR.Interaction.Toolkit;

public class SocketEvents : MonoBehaviour
{
	[SerializeField] private XRSocketInteractor socketInteractor;
	[SerializeField] private UnityEvent socketUsed;
	[SerializeField] private UnityEvent socketFree;

	private void Start()
	{
		socketInteractor.selectEntered.AddListener(UsedSocket);
		socketInteractor.selectExited.AddListener(UnUsedSocket);
	}

	private void OnDestroy()
	{
		socketInteractor.selectEntered.RemoveListener(UsedSocket);
		socketInteractor.selectExited.RemoveListener(UnUsedSocket);
	}

	void UsedSocket(SelectEnterEventArgs args)
	{
		args.interactableObject.transform.GetComponent<ISocketable>().SocketOn();
		transform.parent.GetComponent<Sockatable>().socketedObj = args.interactableObject.transform.GetComponent<Sockatable>();
		socketUsed.Invoke();
	}
	
	void UnUsedSocket(SelectExitEventArgs args)
	{
		args.interactableObject.transform.GetComponent<ISocketable>().SocketOff();
		transform.parent.GetComponent<Sockatable>().socketedObj = null;
		socketFree.Invoke();
	}
}
