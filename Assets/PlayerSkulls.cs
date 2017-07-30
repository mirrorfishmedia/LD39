using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSkulls : MonoBehaviour {

	public int currentSkulls;
	public int maxSkulls = 100;
	public Text skullAmount;

	public PoweredObject powered;

	void OnCollisionEnter(Collision col)
	{
		Skull skull = col.collider.GetComponent<Skull> ();
		if (skull != null) 
		{
			if (skull.collected == false) 
			{
				//CountSkulls (skull.skullValue);

				powered.ChangePower (+1);
			}

			col.gameObject.SetActive (false);


			skull.collected = true;
		}
	}

	void CountSkulls(int skullValue)
	{
		currentSkulls += skullValue;
		skullAmount.text = currentSkulls.ToString ();
	}

}
