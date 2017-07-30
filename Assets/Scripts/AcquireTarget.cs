using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcquireTarget : MonoBehaviour {

	public bool hasTarget;
	public Transform eyePoint;
	public float detectionRadius;
	public float detectionRate = .1f;
	public LayerMask layerToCheckSphere;
	public LayerMask layerToCheckRay;

	private EnemyMover mover;
	private WaitForSeconds wait;
	private Collider[] detectedColliders = new Collider[16];

	// Use this for initialization
	void Awake () 
	{
		wait = new WaitForSeconds (detectionRate);
		StartCoroutine (DetectTargets ());
		mover = GetComponent<EnemyMover> ();
//		Debug.Log ("mover1: " + mover);

	}

	IEnumerator DetectTargets()
	{
		while (!hasTarget) 
		{
			int objectsFound = Physics.OverlapSphereNonAlloc (eyePoint.position, detectionRadius, detectedColliders, layerToCheckSphere);

			for (int i = 0; i < objectsFound; i++) 
			{


				Vector3 toPotentialTarget = detectedColliders[i].transform.position - (eyePoint.position + new Vector3 (0,-.5f,0));
				RaycastHit hit;
				Debug.DrawRay (eyePoint.position, toPotentialTarget * detectionRadius, Color.red);
				if (Physics.Raycast (eyePoint.position, toPotentialTarget, out hit, detectionRadius, layerToCheckRay)) 
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

	private void LockTarget(Transform target, Vector3 fireDir)
	{
//		Debug.Log ("locktarget: " + target);
		if (target.gameObject.activeSelf == true) {
			hasTarget = true;
//			Debug.Log ("mover2: " + mover);
//			Debug.Log ("target: " + target);
//			mover.chaseTarget = target;
//			Debug.Log ("mover.chaseTarget: " + mover.chaseTarget);
		} else 
		{
			hasTarget = false;
		}

	}
}
