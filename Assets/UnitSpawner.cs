using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawner : MonoBehaviour {

	public GameObject[] objectsToSpawn;
	public int maxEnemiesInWave;
	public float spawnFrequency;
	public Transform[] spawnPoints;
	public Transform startTarget;
	private WaitForSeconds wait;
	private int currentEnemyCount = 0;


	// Use this for initialization
	void Start () {
		wait = new WaitForSeconds(spawnFrequency);
		StartCoroutine (SpawnSingle ());
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

}
