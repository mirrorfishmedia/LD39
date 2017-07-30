﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageableObject : MonoBehaviour {

	public int hpMax;
	public GameObject deathEffect;
	public Skull skull;
	public bool isEnemy = true;
	public bool isStructure;

	private int currentHp;

	// Use this for initialization
	void Start () 
	{
		currentHp = hpMax;	
	}
	
	public void ChangeHealth(int healthChange)
	{
		currentHp += healthChange;

		CheckDeath ();

		if (currentHp > hpMax) 
		{
			currentHp = hpMax;
		}

	}



	void CheckDeath()
	{
		if (currentHp <= 0) 
		{
			Die ();
		}
	}

	void Die()
	{
		if (skull != null) 
		{
			skull.OnDeath ();
		}

		if (isStructure) 
		{
			EventManager.TriggerEvent ("bake");
		}
		deathEffect.SetActive (true);
		deathEffect.transform.SetParent (null);
		gameObject.SetActive (false);

	}
}