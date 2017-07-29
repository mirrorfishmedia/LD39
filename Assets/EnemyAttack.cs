using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

	public Transform attackPoint;
	public float attackFrequency = .1f;
	public float attackRange = .5f;
	public int attackDmg = -1;
	public LayerMask playerStuff;

	void OnDisable()
	{
		CancelInvoke ();
	}

	void Start()
	{
		InvokeRepeating ("Attack", 0, attackFrequency);
	}

	void Attack()
	{
		RaycastHit hit;
		Debug.DrawRay (attackPoint.position, attackPoint.forward * attackRange, Color.red);
		if (Physics.Raycast (attackPoint.position, attackPoint.forward, out hit, attackRange, playerStuff)) 
		{
			DamageableObject dmgObj = hit.collider.GetComponent<DamageableObject> ();
			Debug.Log ("attacking");
			if (dmgObj != null) 
			{
				Debug.Log ("dmgObj != null " + dmgObj.gameObject);

				Debug.Log ("dmgObj.isEnemy: " + dmgObj.isEnemy);
				if (dmgObj.isEnemy == false) 
				{
					Debug.Log ("!dmgObj.isEnemy");
					dmgObj.ChangeHealth (attackDmg);
				}

			}
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
