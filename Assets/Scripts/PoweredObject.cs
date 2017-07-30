using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoweredObject : MonoBehaviour {

	public int currentPower = 0;
	public int maxPower = 10;
	public int skullValueMultiplier = 1;
	public PowerDisplay display;

	public void Start()
	{
		display.UpdateDisplay (currentPower);
	}

	public void ChangePower(int powerChange)
	{
		currentPower += powerChange;
		if (currentPower > maxPower) 
		{
			currentPower = maxPower;
		}

		if (currentPower < 0) 
		{
			currentPower = 0;
		}

		display.UpdateDisplay (currentPower);
	}

	void OnCollisionEnter(Collision col)
	{
		Skull skull = col.collider.GetComponent<Skull> ();

		if (skull != null) 
		{
			ChangePower (skull.skullValue * skullValueMultiplier);
			skull.gameObject.SetActive (false);
		}
	}
}
