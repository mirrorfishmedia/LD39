﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMan : MonoBehaviour {

	public bool gameStarted;
	public bool gameEnded;
	public Timer timer;
	public static GameMan instance = null;
	public GameObject gameOverScreen;
	public GameObject titleCam;

	void Awake()
	{
		if (instance == null) 
		{
			instance = this;
		} 
		else if (instance != this) 
		{
			Destroy (gameObject);
		}


	} 

	public void OnGameStart()
	{
		gameStarted = true;
		titleCam.SetActive (false);
		timer.countingTime = true;
		Debug.Log ("start game triggered");
	}

	public void OnGameEnd()
	{
		gameStarted = false;
		timer.countingTime = false;
		if (gameOverScreen != null) 
		{
			gameOverScreen.SetActive (true);
			StartCoroutine (ReloadGame ());
		}


	}

	IEnumerator ReloadGame()
	{
		yield return new WaitForSeconds (5);
		SceneManager.LoadScene ("Main");
	}

}
