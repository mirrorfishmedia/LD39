using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavBuilder : EventBehaviour{

	private NavMeshSurface surface;

	void Awake()
	{
		base.Init ();
		surface = GetComponent<NavMeshSurface> ();

	}

	// Use this for initialization
	void Start () {
		UpdateNav ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void OnAction ()
	{
		UpdateNav ();
	}

	void UpdateNav()
	{
		surface.BuildNavMesh ();
		Debug.Log ("baking");
	}
}
