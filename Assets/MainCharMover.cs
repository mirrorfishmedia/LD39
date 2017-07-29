using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MainCharMover : MonoBehaviour {

	public float distance = 5f;
	private Rigidbody rb;
	private NavMeshAgent agent;
	public float speed = 10f;
	public float turnSpeed = 10f;

	float h;
	float v;


	// Use this for initialization
	void Awake () 
	{
		rb = GetComponent<Rigidbody> ();	
		agent = GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		h = Input.GetAxis ("Horizontal");
		v = Input.GetAxis ("Vertical");



		//Vector3 move = new Vector3 (h, 0, v);

//		rb.MoveRotation (transform.rotation + new Vector3 (0, h * turnSpeed, 0));

//		rb.MovePosition ( transform.position + (v * transform.forward * speed));
	}

	void FixedUpdate()
	{
		agent.updateRotation = false;
		agent.destination = (transform.position + (transform.forward * v));

		Quaternion delta = Quaternion.Euler (Vector3.up * h * turnSpeed * Time.deltaTime);
		rb.MoveRotation (delta * transform.rotation);
	}

	void OnTriggerEnter()
	{
		
	}
}
