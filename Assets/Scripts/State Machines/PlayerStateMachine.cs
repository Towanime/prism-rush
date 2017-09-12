using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonsterLove.StateMachine;

public class PlayerStateMachine : MonoBehaviour {
    
    public PlayerInput playerInput;
    public GameObject player;
    public PlayerStates startingState = PlayerStates.Default;

    private StateMachine<PlayerStates> fsm;
    private StateMachine<MovementStates> movementStateMachine;

    private bool initialized;

    void Awake()
    {
        if (!initialized) Init();
    }

    void Init()
    {
        movementStateMachine = GetComponent<MovementStateMachine>().StateMachine;
        fsm = StateMachine<PlayerStates>.Initialize(this, startingState);
        initialized = true;
    }

    void Inactive_Enter()
    {
        movementStateMachine.ChangeState(MovementStates.Disabled);
    }

    void Default_Enter()
    {
        movementStateMachine.ChangeState(MovementStates.Default);
    }

    void Default_Update()
    {
        if (playerInput.action)
        {
        }
    }

    void Flash_Enter()
    {
        // disable movement and enable dash component
        movementStateMachine.ChangeState(MovementStates.Disabled);
    }

    void Flash_Update()
    {

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
