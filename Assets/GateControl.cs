using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateControl : MonoBehaviour {

	public GameObject litSurface;
	public bool spawning;

	// Use this for initialization
	void Start () 
	{
		litSurface.SetActive (false);	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StartSpawning()
	{
		spawning = true;
		litSurface.SetActive (true);
	}
}
