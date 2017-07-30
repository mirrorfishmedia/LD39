using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructureDispenser : MonoBehaviour 
{
	public int structureCost = -10;

	public bool readyToDispense = true;
	public bool dispenseRandom = false;
	public PlaceObject.PlacementStructure structureType;

	void OnTriggerEnter(Collider other)
	{

//		Debug.Log ("trigger");
			PlaceObject placeObject = other.GetComponentInChildren<PlaceObject> ();
		PoweredObject powered = other.GetComponentInChildren<PoweredObject> ();
			if (placeObject != null) 
			{

		//	Debug.Log ("placeobject not null");
				if (powered != null) 
				{

				//Debug.Log ("got powered");
				if (powered.currentPower >= structureCost) 
				{
					//Debug.Log ("got past cost");
					powered.ChangePower (-structureCost);
					if (dispenseRandom) 
					{
						placeObject.PickupRandomStructure ();
					} 
					else 
					{
						placeObject.SetStructureToPlace (structureType);	
					}


					placeObject.structureDispenser = this;

					readyToDispense = false;
				}
					
				}
				//structurePoints--;
			}

	}
}
