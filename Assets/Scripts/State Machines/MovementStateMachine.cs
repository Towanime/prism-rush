using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonsterLove.StateMachine;

public class MovementStateMachine : MonoBehaviour {
    public PlayerInput playerInput;
    public PlayerController playerController;

    private StateMachine<MovementStates> fsm;

    void Default_Enter()
    {
    }

    void Default_Update()
    {
        playerController.Move(playerInput.direction);
    }

    void Default_FixedUpdate()
    {
        playerController.MoveUpdate();
    }

    void MovementDisabled_Enter()
    {
    }

    void MovementDisabled_Update()
    {
    }

    void Disabled_Enter()
    {
    }

    public StateMachine<MovementStates> StateMachine
    {
        get {
            if (fsm == null)
            {
                fsm = StateMachine<MovementStates>.Initialize(this, MovementStates.Default);
            }
            return fsm;
        }
    }
}
