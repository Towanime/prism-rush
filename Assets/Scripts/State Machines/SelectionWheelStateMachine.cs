using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonsterLove.StateMachine;

public class SelectionWheelStateMachine : MonoBehaviour {

	public PlayerInput playerInput;

	private StateMachine<AimStates> fsm;
	private bool triggerPressed;

	public StateMachine<WheelStates> StateMachine
	{
		get
		{
			if (fsm == null)
			{
				fsm = StateMachine<AimStates>.Initialize(this, AimStates.Default);
			}
			return fsm;
		}
	}
}
