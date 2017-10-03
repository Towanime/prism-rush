using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonsterLove.StateMachine;

public class SelectionWheelAnimationController : MonoBehaviour {

	public bool animPause;
	public bool animEnd;

	public void AnimPause() 
	{
		animPause = true;
		this.GetComponent<Animator> ().speed = 0;
		this.GetComponent<Animator> ().Play ("Selection Wheel Anim", 1, 0.05f);
		this.GetComponent<Animator> ().Play ("Selection Fade Anim", 1, 0.05f);
	}

	public void AnimEnd() 
	{
		animEnd = true;
		this.GetComponent<Animator> ().Play ("Selection Wheel Anim", 1, 0);
		this.GetComponent<Animator> ().Play ("Selection Fade Anim", 1, 0);
	}
}
