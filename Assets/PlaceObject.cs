using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceObject : MonoBehaviour {

	public GameObject objectToPlace;
	public float raycastDownDistance = 3f;
	public LayerMask layerToCheckRay;
	public LayerMask layerToCheckForObjects;
	public GameObject highlightQuad;
	public bool objectPlacementMode;

	public Vector3 offset = new Vector3 (0, .5f,0);

	private Collider[] collidersInTargetLoc = new Collider[1];
	private Vector3 targetSpawnPos;

	// Use this for initialization
	void Start () 
	{
		highlightQuad.transform.SetParent (null);	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (objectPlacementMode) 
		{
			HighlightGround ();
			if (Input.GetButtonDown ("Fire1")) 
			{
				PlaceAtHighlight ();
			}
		}

	}

	void PlaceAtHighlight()
	{
		int objectsFound = Physics.OverlapSphereNonAlloc (targetSpawnPos + offset, .5f, collidersInTargetLoc, layerToCheckForObjects);
		Debug.Log ("objects found : " + objectsFound);
		if (objectsFound == 0) {
			GameObject clone = Instantiate (objectToPlace, targetSpawnPos, Quaternion.identity) as GameObject;
			EventManager.TriggerEvent ("bake");
		} else 
		{
			Debug.Log ("can't spawn there");
		}

	}

	void HighlightGround()
	{
	
		RaycastHit hit;
		Debug.DrawRay (transform.position, -transform.up * raycastDownDistance, Color.red);
		if (Physics.Raycast (transform.position, -transform.up, out hit, raycastDownDistance, layerToCheckRay))
		{
			targetSpawnPos = hit.collider.transform.position + offset;
			highlightQuad.transform.position = targetSpawnPos;
		}
			
	}

}
