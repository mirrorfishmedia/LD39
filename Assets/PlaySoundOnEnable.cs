using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnEnable : MonoBehaviour {


	private AudioSource source;

	public float minPitch = .5f;
	public float maxPitch = 1f;

	public AudioClip[] clips;

	// Use this for initialization
	void Awake () 
	{
		source = GetComponent<AudioSource> ();	

	}
	
	void OnEnable()
	{
		source.clip = clips [Random.Range (0, clips.Length)];
		source.pitch = Random.Range (minPitch, maxPitch);
		source.Play ();
	}
}
