using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonsterLove.StateMachine;

public class SelectionWheelAnimationController : MonoBehaviour {

	public bool animPause;
	public bool animEnd;

	public void AnimPause() 
	{
		this.GetComponent<Animator> ().speed = 0;
		animPause = true;
		this.GetComponent<Animator> ().Play ("Selection Wheel Anim", -1, 0.5f);
		Cursor.visible = true;
	}

	public void AnimEnd() 
	{
		animEnd = true;
		Cursor.lockState = CursorLockMode.Locked;
	}
}
