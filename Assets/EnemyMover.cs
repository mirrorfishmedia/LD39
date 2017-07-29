using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyMover : EventBehaviour {

	public Transform chaseTarget;

	private NavMeshAgent agent;

	// Use this for initialization
	void Awake () 
	{
		agent = GetComponent<NavMeshAgent> ();

		Init ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		agent.destination = chaseTarget.position;	
	}

	public override void OnAction ()
	{
		
	}
}
