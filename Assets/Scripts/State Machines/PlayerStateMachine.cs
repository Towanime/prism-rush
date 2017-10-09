using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonsterLove.StateMachine;

public class PlayerStateMachine : MonoBehaviour {
    
    public PlayerInput playerInput;
    public GameObject player;
    public PhotonShot photonShot;
    public Flash flash;
    public PlayerStates startingState = PlayerStates.Default;

    private StateMachine<PlayerStates> fsm;
    private StateMachine<MovementStates> movementStateMachine;
    private StateMachine<AimStates> aimingStateMachine;

    private bool initialized;

    void Awake()
    {
        if (!initialized) Init();
    }

    void Init()
    {
        movementStateMachine = GetComponent<MovementStateMachine>().StateMachine;
        aimingStateMachine = GetComponent<AimingStateMachine>().StateMachine;
        fsm = StateMachine<PlayerStates>.Initialize(this, startingState);
        initialized = true;
    }

    void Inactive_Enter()
    {
        movementStateMachine.ChangeState(MovementStates.Disabled);
        aimingStateMachine.ChangeState(AimStates.Disabled);
    }

    void Default_Enter()
    {
        movementStateMachine.ChangeState(MovementStates.Default);
        aimingStateMachine.ChangeState(AimStates.Default);
    }

    void Default_Update()
    {
        if (playerInput.action)
        {
            //photonShot.Fire();
            fsm.ChangeState(PlayerStates.Flash);
        }
    }

    void Flash_Enter()
    {
        // disable movement and enable dash component
        movementStateMachine.ChangeState(MovementStates.Disabled);
        aimingStateMachine.ChangeState(AimStates.Disabled);
        flash.Begin();
    }

    void Flash_Update()
    {
        if (flash.Finished)
        {
            fsm.ChangeState(PlayerStates.Default);
        }
    }

    void Flash_Exit()
    {
    }

    public StateMachine<PlayerStates> FSM
    {
        get {
            if (!initialized)
            {
                Init();
            }
            return fsm; }
    }
}
