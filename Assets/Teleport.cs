using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {

	public Transform gateExit;

	void OnTriggerEnter(Collider other)
	{
		if (gateExit != null) 
		{
			other.transform.position = gateExit.position;
		}

	}
}
