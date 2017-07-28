using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTwo : EventBehaviour{

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")) 
		{
			
		}
	}

	public override void OnAction ()
	{
		Debug.Log ("test two fired");
	}
}
