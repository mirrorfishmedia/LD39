using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShoot : MonoBehaviour {

	public Transform attackPoint;
	public GameObject projectile;
	public float shootForce = 250f;
	public float detectionRadius;
	public float fireRate = .25f;
	public float detectionRate = .1f;
	public LayerMask layerToCheckSphere;
	public LayerMask layerToCheckRay;
	public Transform top;
	public PlaySoundTriggered playTriggered;

	private PoweredObject power;
	private float nextFire;
	private Transform fireTarget;
	private WaitForSeconds wait;
	private Collider[] detectedColliders = new Collider[16];

	// Use this for initialization
	void Awake () 
	{
		power = GetComponent<PoweredObject> ();
		wait = new WaitForSeconds (detectionRate);
		StartCoroutine (DetectTargets ());

	}

	IEnumerator DetectTargets()
	{
		while (true) 
		{
			int objectsFound = Physics.OverlapSphereNonAlloc (attackPoint.position, detectionRadius, detectedColliders, layerToCheckSphere);

			for (int i = 0; i < objectsFound; i++) 
			{


					Vector3 toPotentialTarget = detectedColliders[i].transform.position - (attackPoint.position + new Vector3 (0,-.5f,0));
					RaycastHit hit;
					Debug.DrawRay (attackPoint.position, toPotentialTarget * detectionRadius, Color.red);
					if (Physics.Raycast (attackPoint.position, toPotentialTarget, out hit, detectionRadius, layerToCheckRay)) 
					{
						DamageableObject dmgObj = detectedColliders [i].GetComponent<DamageableObject> ();
						if (dmgObj != null) 
						{
							LockTarget (dmgObj.transform, toPotentialTarget);
						}
						
					} else 
					{
						detectedColliders.Initialize ();
					}

				
			}

			yield return wait;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (fireTarget != null) 
		{
			top.LookAt (fireTarget.position);
		}


	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere (attackPoint.position, detectionRadius);
	}

	void LockTarget(Transform target, Vector3 fireDir)
	{
		fireTarget = target.transform;
		if (fireTarget.gameObject.activeSelf == false) 
		{
			fireTarget = null;
			return;
		}

		Fire (fireDir);
	}

	void Fire(Vector3 dir)
	{
		if (power.currentPower > 0) 
		{
			if (Time.time > nextFire + fireRate) 
			{
				playTriggered.TriggerSound ();
				power.ChangePower (-1);
				nextFire = Time.time + fireRate;
				GameObject clone = Instantiate (projectile, attackPoint.position, transform.rotation) as GameObject;
				Rigidbody cloneRb = clone.GetComponent<Rigidbody> ();
				cloneRb.AddForce (dir.normalized * shootForce);
				fireTarget = null;

			}
		}


	}
}
