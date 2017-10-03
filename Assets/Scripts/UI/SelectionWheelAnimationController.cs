using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonsterLove.StateMachine;

public class SelectionWheelAnimationController : MonoBehaviour {

	public GameObject selectionWheel;
	public Vector3 selectionWheelPosition;

	public bool animPause;
	public bool animEnd;

	public void AnimPause() 
	{
		this.GetComponent<Animator> ().speed = 0;
		animPause = true;
		this.GetComponent<Animator> ().Play ("Selection Wheel Anim", 1, 0.5f);
		this.GetComponent<Animator> ().Play ("Selection Fade Anim", 1, 0.5f);
		selectionWheelPosition = selectionWheel.GetComponent<RectTransform> ().position;
		selectionWheelPosition.x = 0f;
		selectionWheelPosition.y = 0f;
		selectionWheel.GetComponent<RectTransform> ().position = selectionWheelPosition;
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.lockState = CursorLockMode.None;
	}

	public void AnimEnd() 
	{
		animEnd = true;
		this.GetComponent<Animator> ().Play ("Selection Wheel Anim", 1, 0);
		this.GetComponent<Animator> ().Play ("Selection Fade Anim", 1, 0);
	}
}
