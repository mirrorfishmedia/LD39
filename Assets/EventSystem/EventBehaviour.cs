using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class EventBehaviour : MonoBehaviour {

	public string onActionString = "actionTest";
	private UnityAction action;

	protected void InitEvent()
	{
		action = new UnityAction (OnAction);
	}

	void OnEnable()
	{
		EventManager.StartListening (onActionString, action);
	}

	void OnDisable()
	{
		EventManager.StopListening (onActionString, action);
	}

	public abstract void OnAction ();
}
