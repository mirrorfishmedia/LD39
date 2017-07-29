using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

	public Transform spawnPoint;
	public GameObject projectile;
	public float shootForce = 250f;

	public PoweredObject playerPower;
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetButtonDown ("Fire1")) 
		{
			Fire ();
		}	
	}

	void Fire()
	{
		if (playerPower.currentPower > 0) {
		
			playerPower.ChangePower (-1);
			GameObject clone = Instantiate (projectile, spawnPoint.position, transform.rotation) as GameObject;
			Rigidbody cloneRb = clone.GetComponent<Rigidbody> ();
			cloneRb.AddForce (transform.forward * shootForce);

		}

	}

}
