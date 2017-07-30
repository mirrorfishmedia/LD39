using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour {

	public int damageAmount = -1;
	public GameObject collisionEffect;
	public bool playerOwned = true;

	void OnCollisionEnter(Collision col)
	{
		DamageableObject dmgObj = col.collider.GetComponent<DamageableObject> ();
		if (dmgObj != null) 
		{
			if (dmgObj.isEnemy) {
				dmgObj.ChangeHealth (damageAmount);
			}



		}


		collisionEffect.SetActive (true);
		collisionEffect.transform.SetParent (null);
		gameObject.SetActive (false);
	}
}
