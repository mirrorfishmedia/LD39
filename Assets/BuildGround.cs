using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BuildGround : EventBehaviour {

	public GameObject[] gridPrefabs;
	private NavMeshSurface surface;

	public int gridSizeX = 20;
	public int gridSizeY = 20;
	// Use this for initialization

	void Awake()
	{
		base.Init ();
		surface = GetComponent<NavMeshSurface> ();
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

	void Start () 
	{
		BuildGrid ();	

	}

	void BuildGrid()
	{
		for (int i = 0; i < gridSizeX; i++) 
		{
			for (int j = 0; j < gridSizeY; j++) 
			{
				Instantiate (gridPrefabs[Random.Range(0,gridPrefabs.Length)], new Vector3 (i, Random.Range(0.0f,0.0f), j), CubeFacing());
			}	
		}

		for (int i = 0; i < gridSizeX; i++) 
		{
			Instantiate (gridPrefabs[Random.Range(0,gridPrefabs.Length)], new Vector3 (i, 1+ Random.Range(0.0f,0.1f), 0), CubeFacing());
		}

		for (int i = 0; i < gridSizeX; i++) 
		{
			Instantiate (gridPrefabs[Random.Range(0,gridPrefabs.Length)], new Vector3 (i, 1+ Random.Range(0.0f,0.1f), gridSizeX), CubeFacing());
		}

		for (int i = 0; i < gridSizeY; i++) 
		{
			Instantiate (gridPrefabs[Random.Range(0,gridPrefabs.Length)], new Vector3 (gridSizeY, 1+ Random.Range(0.0f,0.1f), i), CubeFacing());
		}

		for (int i = 0; i < gridSizeY; i++) 
		{
			Instantiate (gridPrefabs[Random.Range(0,gridPrefabs.Length)], new Vector3 (0, 1+ Random.Range(0.0f,0.1f), i), CubeFacing());
		}
	}

	Quaternion CubeFacing()
	{
		int diceRoll = Random.Range (5, 7);
		Quaternion newFacing = new Quaternion();
		switch (diceRoll) {

		case 1:
			newFacing = Quaternion.Euler (0, 0, 0);
			break;
		case 2:
			newFacing = Quaternion.Euler (90, 0, 0);
			break;
		case 3:
			newFacing = Quaternion.Euler (180, 0, 0);
			break;
		case 4:
			newFacing = Quaternion.Euler (270, 0, 0);
			break;
		case 5:
			newFacing = Quaternion.Euler (0, 90, 0);
			break;
		case 6:
			newFacing = Quaternion.Euler (0, 180, 0);
			break;
		case 7:
			newFacing = Quaternion.Euler (0, 270, 0);
			break;
		case 8:
			newFacing = Quaternion.Euler (0, 0, 90);
			break;
		case 9:
			newFacing = Quaternion.Euler (0, 0, 180);
			break;
		case 10:
			newFacing = Quaternion.Euler (0, 0, 270);
			break;

		default:
			break;
		}
		return newFacing;
	}
}
