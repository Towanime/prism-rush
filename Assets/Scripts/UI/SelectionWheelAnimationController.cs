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
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}

	public void AnimEnd() 
	{
		animEnd = true;
		Cursor.visible = false;
	}
}
