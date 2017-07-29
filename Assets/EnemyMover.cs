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
		if (chaseTarget != null) 
		{
			agent.destination = chaseTarget.position;
			agent.isStopped = false;
			Debug.Log ("agent.destination: " + agent.destination);
		}

	}

	public override void OnAction ()
	{
		
	}
}
