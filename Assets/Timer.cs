using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	public Text minuteText;
	public Text secondsText;

	public float timeInRound;
	public bool countingTime;


	
	// Update is called once per frame
	void Update () 
	{
		if (countingTime) 
		{
			timeInRound += Time.deltaTime;
			SetCurrentTimeUI ();
		}

	}

	void SetCurrentTimeUI()
	{
		string minutes = Mathf.Floor ((int)timeInRound / 60).ToString ("00");
		string seconds = ((int)timeInRound % 60).ToString ("00");

		minuteText.text = minutes;
		secondsText.text = seconds;
	}
}

