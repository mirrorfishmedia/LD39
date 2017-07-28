using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildGround : MonoBehaviour {

	public GameObject gridPrefab;

	public int gridSizeX = 20;
	public int gridSizeY = 20;
	// Use this for initialization
	void Start () 
	{
		BuildGrid ();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void BuildGrid()
	{
		for (int i = 0; i < gridSizeX; i++) 
		{
			for (int j = 0; j < gridSizeY; j++) 
			{
				Instantiate (gridPrefab, new Vector3 (i, Random.Range(0.5f,1f), j), Quaternion.identity);
			}	
		}
	}
}
