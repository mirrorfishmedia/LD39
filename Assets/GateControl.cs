using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateControl : MonoBehaviour {

	public GameObject litSurface;
	public GameObject spawner;

	// Use this for initialization
	void Start () 
	{
	}


	public void ActivateGate()
	{
		spawner.SetActive (true);
		litSurface.SetActive (true);
	}
}
