using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundTriggered : MonoBehaviour {


	private AudioSource source;

	public float minPitch = .5f;
	public float maxPitch = 1f;

	public float volumeMin = .75f;
	public float volumeMax = 1f;

	public AudioClip[] clips;

	// Use this for initialization
	void Awake () 
	{
		source = GetComponent<AudioSource> ();	

	}

	public void TriggerSound()
	{
		source = GetComponent<AudioSource> ();	
		AudioClip clipSelected = clips [Random.Range (0, clips.Length)];
 
		source.pitch = Random.Range (minPitch, maxPitch);
		source.PlayOneShot (clipSelected, Random.Range(volumeMin, volumeMax));
	}
}
