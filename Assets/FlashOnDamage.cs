using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashOnDamage : MonoBehaviour {

	public Material[] originalMaterials;
	public Material flashMaterial;
	public float flashDuration = .1f;
	private Renderer[] renderers;

	private WaitForSeconds wait;

	// Use this for initialization
	void Start () 
	{
		renderers = GetComponentsInChildren<Renderer> ();
		originalMaterials = new Material[renderers.Length];
		for (int i = 0; i < renderers.Length; i++) 
		{
			originalMaterials [i] = renderers [i].material;
		}
		wait = new WaitForSeconds (flashDuration);	
	}

	IEnumerator Flash()
	{
		for (int i = 0; i < renderers.Length; i++) 
		{
			renderers [i].material = flashMaterial;	
		}
		yield return wait;
		for (int i = 0; i < renderers.Length; i++) 
		{
			renderers [i].material = originalMaterials [i];	
		}
	}

	public void DamageFlash()
	{
		StartCoroutine (Flash ());
	}

	}
