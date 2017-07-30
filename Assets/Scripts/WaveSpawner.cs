using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WaveSpawner : MonoBehaviour {

	public GameObject[] objectsToSpawn;
	public int maxEnemiesInWave;
	public float spawnFrequency;
	public Transform[] spawnPoints;
	public Transform startTarget;
	public GateSequence[] gateSequences;
	public float timeBetweenGates;

	private GateSequence currentGateSequence;

	public float[] gateTimes;
	List<GateControl> gateList = new List<GateControl>();

	private float nextGateTime;
	private int currentEnemyCount = 0;
	private WaitForSeconds wait;

	// Use this for initialization
	void Start () 
	{
		wait = new WaitForSeconds(spawnFrequency);
		StartCoroutine (SpawnSingle ());
		currentGateSequence = gateSequences [Random.Range(0, gateSequences.Length)];
	}

	void ActivateRandomGate()
	{
			
	}

	IEnumerator SpawnSingle()
	{
		while (true) 
		{
			if (currentEnemyCount <= maxEnemiesInWave) {
				GameObject clonedEnemy = Instantiate (objectsToSpawn [0], spawnPoints [Random.Range (0, spawnPoints.Length)].position, Quaternion.identity) as GameObject;
				clonedEnemy.name = "enemy " + currentEnemyCount.ToString();
				EnemyMover mover = clonedEnemy.GetComponent<EnemyMover> ();
				mover.chaseTarget = startTarget;
				currentEnemyCount++;
			} else 
			{
				StopAllCoroutines ();
			}
			yield return wait;
		}
		
		}

	
	// Update is called once per frame
	void Update () 
	{
		if (Time.time > nextGateTime) 
		{
			nextGateTime = Time.time + timeBetweenGates;
			ActivateRandomGate ();
		}
	}
}
