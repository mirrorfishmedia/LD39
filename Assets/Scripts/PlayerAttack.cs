using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

	public Transform spawnPoint;
	public GameObject weaponProjectile;
	public GameObject skullProjectile;
	public float shootForce = 250f;
	public float attackRate = .1f;

	public PoweredObject playerPower;

	public PlaceObject placeObject;

	public PlaySoundTriggered playTriggered;

	private float nextAttackTime;

	// Update is called once per frame
	void Update () 
	{
		if (GameMan.instance.gameStarted) 
		{
			if (placeObject.objectPlacementMode) 
			{
				return;
			}
			if (Input.GetButtonDown ("Fire1")) 
			{
				Fire (weaponProjectile);
			}	

			if (Input.GetButtonDown ("Fire2")) 
			{
				FireSkull ();
			}

		}

	

	}

	void FireSkull()
	{

		if (playerPower.currentPower > 0) 
		{
			playerPower.ChangePower (-1);
			Fire (skullProjectile);
		}
		playTriggered.TriggerSound ();
	}

	void Fire(GameObject toFire)
	{

		GameObject clone = Instantiate (toFire, spawnPoint.position, transform.rotation) as GameObject;
		Rigidbody cloneRb = clone.GetComponent<Rigidbody> ();
		cloneRb.AddForce (transform.forward * shootForce);
		playTriggered.TriggerSound ();


	}

}
