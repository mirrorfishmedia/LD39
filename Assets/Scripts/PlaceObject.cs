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
	public Structure[] placeableStructures;
	public Structure currentStructure;
	public bool hasStructureToPlace = false;
	public StructureDispenser structureDispenser;
	public PlaySoundTriggered playTriggered;

	public enum PlacementStructure { turret, teleporter,  cauldronBattery, teleporterExit, blockerBox};

	public PlacementStructure lastPlacedStructure;

	public Vector3 offset = new Vector3 (0, .5f,0);

	private GameObject objectToPlaceDisplay;
	private Collider[] collidersInTargetLoc = new Collider[1];
	private Vector3 targetSpawnPos;
	private Teleport lastTeleportEntrance;



	// Use this for initialization
	void Start () 
	{
		highlightQuad.transform.SetParent (null);	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetButtonDown ("Jump")) 
		{
			if (objectPlacementMode == true) 
			{
				objectPlacementMode = false;
				Debug.Log ("toggle mode 1" + objectPlacementMode);
			} else 
			{
				objectPlacementMode = true;
				Debug.Log ("toggle mode 2" + objectPlacementMode);
			}


		}

		if (objectPlacementMode) 
		{
			if (hasStructureToPlace) 
			{
				HighlightGround ();
			}



			if (objectToPlaceDisplay != null && objectToPlaceDisplay.activeSelf == false) 
			{
				objectToPlaceDisplay.SetActive(true);
			}

			if (Input.GetButtonDown ("Fire1")) 
			{
				PlaceAtHighlight ();
			}
		} 

		else 
		{

			if (objectToPlaceDisplay != null) 
			{
				objectToPlaceDisplay.SetActive(false);

			}

			highlightQuad.SetActive (false);
		}		
	}


	void HighlightGround()
	{
		highlightQuad.SetActive (true);
		RaycastHit hit;
		Debug.DrawRay (transform.position, -transform.up * raycastDownDistance, Color.red);
		if (Physics.Raycast (transform.position, -transform.up, out hit, raycastDownDistance, layerToCheckRay))
		{
			targetSpawnPos = hit.collider.transform.position + offset;
			highlightQuad.transform.position = targetSpawnPos;
		}

	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.blue;
		Gizmos.DrawWireSphere (targetSpawnPos + offset, .25f);
	}


	void PlaceAtHighlight()
	{
		
		int objectsFound = Physics.OverlapSphereNonAlloc (targetSpawnPos + offset, .25f, collidersInTargetLoc, layerToCheckForObjects);
		if (objectsFound == 0) 
		{
			GameObject clone = Instantiate (objectToPlace, targetSpawnPos, Quaternion.identity) as GameObject;
			EventManager.TriggerEvent ("bake");
			structureDispenser.readyToDispense = true;
			playTriggered.TriggerSound ();
			if (lastPlacedStructure == PlacementStructure.teleporter) {
				Teleport teleporterEntrance = clone.GetComponent<Teleport> ();
				lastTeleportEntrance = teleporterEntrance;
				PlaceGateAfterTeleporter ();
			} 
			else
			
			{
				if (lastPlacedStructure == PlacementStructure.teleporterExit) 
				{
					lastTeleportEntrance.gateExit = clone.transform;
					lastTeleportEntrance = null;
				}

				Destroy (objectToPlaceDisplay);
				//Debug.Log ("objectToPlaceDisplay: " + objectToPlaceDisplay);
				hasStructureToPlace = false;
				highlightQuad.SetActive (false);
				objectPlacementMode = false;
				//Debug.Log ("setting inactive after placement");
			}

		} else 
		{
			Debug.Log ("can't spawn there");
		}


	}

	void PlaceGateAfterTeleporter()
	{
		SetStructureToPlace (PlacementStructure.teleporterExit);
	}



	public void PickupRandomStructure()
	{
		
		int randomRoll = Random.Range (0, 4);
		PlacementStructure randomStructure = (PlacementStructure)randomRoll;
		if (randomStructure == PlacementStructure.teleporterExit) 
		{
			randomStructure = PlacementStructure.blockerBox;
		}
		SetStructureToPlace (randomStructure);

	}

	public void SetStructureToPlace(PlacementStructure structureToPlace)
	{
		hasStructureToPlace = true;

		switch (structureToPlace) 
		{
		case PlacementStructure.turret:
			currentStructure = placeableStructures [0];
			break;

		case PlacementStructure.teleporter:
			currentStructure = placeableStructures [1];
			break;


		case PlacementStructure.teleporterExit:
			currentStructure = placeableStructures [2];
			break;

		case PlacementStructure.blockerBox:
			currentStructure = placeableStructures [3];
			Debug.Log ("blockerBox");
			break;

		case PlacementStructure.cauldronBattery:
			currentStructure = placeableStructures [4];
			Debug.Log ("blockerBox");
			break;

		

			currentStructure = placeableStructures [0];
			default:

				break;
		}
			
		ChangeDisplayedObject ();


	}

	void ChangeDisplayedObject()
	{
		if (objectToPlaceDisplay != null) 
		{
			Destroy (objectToPlaceDisplay);
		}
		Debug.Log ("currentStructure: " + currentStructure);
		Debug.Log ("currentStructure.displayObject: " + currentStructure.displayObject);
		objectToPlaceDisplay = Instantiate (currentStructure.displayObject, transform.position, transform.rotation);
		objectToPlaceDisplay.SetActive (true);
		objectToPlaceDisplay.transform.SetParent (transform);
		objectToPlace = currentStructure.toSpawn;
		lastPlacedStructure = currentStructure.placementStructureType;
		objectPlacementMode = true;
	}

}
