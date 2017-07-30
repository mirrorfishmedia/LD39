using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skull : MonoBehaviour {

	private Rigidbody rb;
	private Collider skullCollider;
	public int skullValue = 1;
	public GameObject collectedParticle;


	private Material skullMaterial;
	private Renderer myRenderer;

	public bool collected;

	void Awake()
	{
		rb = GetComponent<Rigidbody> ();
		skullCollider = GetComponent<Collider> ();
		myRenderer = GetComponentInChildren<Renderer> ();

		skullMaterial = myRenderer.material;
	}

	public void OnDeath()
	{
		transform.SetParent (null);
		rb.isKinematic = false;
		skullCollider.enabled = true;
		myRenderer.material = skullMaterial;
	}

	public void CollectForPower()
	{
		collectedParticle.transform.SetParent (null);
		collectedParticle.SetActive (true);
	}

}
