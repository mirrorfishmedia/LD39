using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

	public Transform attackPoint;
	public float attackFrequency = .1f;
	public float attackRange = .5f;
	public int attackDmg = -1;

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
		if (Physics.Raycast (attackPoint.position, transform.forward, out hit, attackRange)) 
		{
			DamageableObject dmgObj = hit.collider.GetComponent<DamageableObject> ();
			if (dmgObj != null) 
			{
				if (!dmgObj.isEnemy) 
				{
					dmgObj.ChangeHealth (attackDmg);
				}

			}
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
