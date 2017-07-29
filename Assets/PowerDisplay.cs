using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerDisplay : MonoBehaviour {

	public Renderer[] renderers;
	public Material lit;
	public Material off;

	public void UpdateDisplay(int currentPower)
	{
		for (int i = 0; i < renderers.Length; i++) 
		{
			if (i < currentPower) {
				renderers [i].material = lit;
			} else 
			{
				renderers [i].material = off;
			}
		}
	}


}
