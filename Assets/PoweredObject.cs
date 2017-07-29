using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoweredObject : MonoBehaviour {

	public int currentPower = 0;
	public int maxPower = 10;
	public PowerDisplay display;

	public void Start()
	{
		display.UpdateDisplay (currentPower);
	}

	public void ChangePower(int powerChange)
	{
		currentPower += powerChange;
		if (currentPower > maxPower) {
			currentPower = maxPower;
		}

		display.UpdateDisplay (currentPower);
	}
}
