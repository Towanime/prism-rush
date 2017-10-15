﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargeBar : MonoBehaviour {

	public PlayerInput playerInput;
	public GameObject r1Button;
	public GameObject prismPartyText;
	public GameObject chargeBar;

	public SelectionWheelAnimationController selectWheelAnim;
	public SelectionWheelAnimationController bigXAnim;
	public DDRStateMachine ddrStateMachine;
	public Timer timer;

	public int maxCharge;
	public int abilitySuccess;
	private Slider slider;


	void Start () {
		maxCharge = 100;
		slider = chargeBar.GetComponent<Slider> ();
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.LeftControl)) 
		{
			slider.value += 10;
		}

		if (slider.value >= maxCharge) {
			slider.value = maxCharge;
			if (selectWheelAnim.animPause == false) {
				r1Button.SetActive (true);
				prismPartyText.SetActive (true);
				chargeBar.SetActive (false);
			}
		}

		if (slider.value >= maxCharge && selectWheelAnim.animPause == true) {
			
			r1Button.SetActive (false);
			prismPartyText.SetActive (false);

			if (abilitySuccess == 1) 
			{
				Debug.Log ("Pass");
				slider.value -= 100;
				abilitySuccess = 0;
				timer.timerOn = false;
				timer.timesUp = false;
				timer.slider.value += 100;
				ddrStateMachine.ddrFail = false;
				ddrStateMachine.ddrActive = false;
			}

			if (abilitySuccess == 2 && bigXAnim.animEnd == true) {
				Debug.Log ("Fail");
				ddrStateMachine.ddrFail = false;
				ddrStateMachine.ddrActive = false;
				slider.value -= 70;
				abilitySuccess = 0;
				bigXAnim.animEnd = false;
			}
		}
	}
}
