using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	public SelectionWheelAnimationController selectWheelAnim;
	public SelectionWheelAnimationController bigXAnim;
	public DDRStateMachine ddrStateMachine;
	public ChargeBar chargeBar;

	public float speed;
	public int maxCharge;
	public int minCharge;
	public bool timerOn;
	public bool timesUp;
	public Slider slider;

	public GameObject timer;

	void Start () 
	{
		maxCharge = 100;
		minCharge = 0;
		slider = timer.GetComponent<Slider> ();
	}

	void Update ()
	{
		if (slider.value >= maxCharge) {
			slider.value = maxCharge;
		}

		if (timerOn == false) {
			slider.value += 100;
		}

		if (timerOn && slider.value <= minCharge) {
			timesUp = true;
			slider.value = minCharge;
		} else {
			slider.value -= speed * Time.deltaTime;
		}

		if (ddrStateMachine.ddrFail == true) {
			timerOn = false;
			timesUp = false;
			slider.value += 100;
		}
	}
}
