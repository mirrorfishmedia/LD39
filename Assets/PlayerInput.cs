using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

	// Use this for initialization
	void Awake () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetButtonDown ("Fire1")) 
		{
			EventManager.TriggerEvent ("fire1");
		}

		if (Input.GetButtonDown ("Jump")) 
		{
			EventManager.TriggerEvent ("jump");
		}
	}
}
