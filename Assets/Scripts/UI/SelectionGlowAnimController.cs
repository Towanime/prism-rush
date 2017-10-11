using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonsterLove.StateMachine;

public class SelectionGlowAnimController : MonoBehaviour {

	public bool animEnd;

	public void AnimEnd() 
	{
		animEnd = true;
	}
}
