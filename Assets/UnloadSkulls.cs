using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnloadSkulls : MonoBehaviour {

	public GameObject collectibleSkull;
	public Transform spawnPoint;
	public PoweredObject powered;

	void OnCollisionEnter(Collision col)
	{
		Damager damager = col.gameObject.GetComponent<Damager> ();
		if (damager != null) 
		{
			if (damager.playerOwned) 
			{
				Unload ();
			}
		}

	}

	void Unload()
	{
		if (powered.currentPower > 0) 
		{

			powered.ChangePower (-1);
			Debug.Log ("currentPower: " + powered.currentPower);

			Quaternion randSkullDir = Quaternion.Euler(new Vector3(0, Random.Range(0,360),0));
			GameObject clone = Instantiate (collectibleSkull, spawnPoint.position, randSkullDir) as GameObject;
			Rigidbody cloneRb = clone.GetComponent<Rigidbody> ();
			cloneRb.AddForce (clone.transform.forward * 150);
		}


	}
}
