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
    private CharacterController characterController;

    private bool initialized;

    void Awake()
    {
        if (!initialized) Init();
    }

    void Init()
    {
        movementStateMachine = GetComponent<MovementStateMachine>().StateMachine;
        fsm = StateMachine<PlayerStates>.Initialize(this, startingState);
        characterController = player.GetComponent<CharacterController>();
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
