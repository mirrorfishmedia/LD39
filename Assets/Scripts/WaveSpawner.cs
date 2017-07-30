using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WaveSpawner : MonoBehaviour {


	public GateSequence[] gateSequences;
	public float timeBetweenGates;
	public int gateSequenceIndex = 0;
	public GateControl[] gateControls;

	private GateSequence currentGateSequence;
	private float nextGateTime;

	// Use this for initialization
	void Start () 
	{
		
		currentGateSequence = gateSequences [Random.Range(0, gateSequences.Length)];
	}

	void ActivateNextGate()
	{
		if (gateSequenceIndex < currentGateSequence.gates.Length) 
		{
			gateControls [currentGateSequence.gates[gateSequenceIndex]].ActivateGate ();
		}
		gateSequenceIndex++;

	}


	
	// Update is called once per frame
	void Update () 
	{
		if (Time.time > nextGateTime) 
		{
			nextGateTime = Time.time + timeBetweenGates;
			ActivateNextGate ();
		}
	}
}
