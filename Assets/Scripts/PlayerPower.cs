using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPower : MonoBehaviour {

	public int currentPower;
	public int maxPower = 10;

	public Transform powerCastPoint;
	public float powerGiveRange;
	public LayerMask layerToCheckForPoweredObject;
	public PowerDisplay powerDisplay;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		/*
		if (Input.GetButtonDown ("Fire2")) 
		{
			RaycastHit hit;


			Debug.DrawRay (powerCastPoint.position, powerCastPoint.forward * powerGiveRange, Color.red);
			if (Physics.Raycast (powerCastPoint.position,  powerCastPoint.forward, out hit, powerGiveRange, layerToCheckForPoweredObject)) 
			{
				PoweredObject poweredObj = hit.collider.GetComponent<PoweredObject> ();
				if (poweredObj != null) 
				{
					GivePower (poweredObj);
				}
					
			}

			powerDisplay.UpdateDisplay (currentPower);
		}
		*/
	}

	private void GivePower(PoweredObject powered)
	{
		if (currentPower > 0) 
		{
			currentPower--;
			powered.ChangePower (+1);
			if (currentPower < 0) 
			{
				currentPower = 0;
			}
		}

	}
}
