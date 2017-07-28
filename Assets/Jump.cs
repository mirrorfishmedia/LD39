using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : EventBehaviour {

	private Rigidbody rb;

	// Use this for initialization
	void Awake () 
	{
		base.InitEvent ();
		rb = GetComponent<Rigidbody> ();
	}

	public override void OnAction ()
	{
		DoJump ();
	}

	void DoJump()
	{
		rb.AddForce(Vector3.up * 2000f);
	}
}
