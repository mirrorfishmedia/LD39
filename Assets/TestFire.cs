using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFire : MonoBehaviour {

	public string eventToTriggerString;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetButtonDown ("Jump")) 
		{
			EventManager.TriggerEvent (eventToTriggerString);
		}	
	}
}
