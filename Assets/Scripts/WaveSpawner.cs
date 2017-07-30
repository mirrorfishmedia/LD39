using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WaveSpawner : MonoBehaviour {


	public GateSequence[] gateSequences;
	public float timeBetweenGates;
	public int gateSequenceIndex = 0;
	public GateControl[] gateControls;
	public UnitSpawner[] unitSpawners;

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
		for (int i = 0; i < unitSpawners.Length; i++) 
		{
			switch (gateSequenceIndex) 
			{
			case 0:
				unitSpawners [i].spawnFrequency = 5f;
				break;
			case 1:
				unitSpawners [i].spawnFrequency = 3.5f;
				break;
			case 2:
				unitSpawners [i].spawnFrequency = 2.5f;
				break;
			case 3:
				unitSpawners [i].spawnFrequency = 1f;
				break;
			}

		}
		gateSequenceIndex++;

	}


	
	// Update is called once per frame
	void Update () 
	{
		if (Time.time > nextGateTime && GameMan.instance.gameStarted) 
		{
			nextGateTime = Time.time + timeBetweenGates;
			ActivateNextGate ();
		}
	}
}
