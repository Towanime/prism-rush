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
	}

	public void AnimEnd() 
	{
		animEnd = true;
	}
}
