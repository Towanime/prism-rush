using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonsterLove.StateMachine;

public class GameStateMachine : MonoBehaviour {

    public PlayerInput playerInput;
    public PlayerStateMachine playerStateMachine;

    private GameObject player;
    private bool initialized;
    private StateMachine<GameStates> fsm;

    void Start()
    {
        if (!initialized) Init();
    }

    void Init()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        fsm = StateMachine<GameStates>.Initialize(this, GameStates.Running);
        initialized = true;
    }

    void Running_Enter()
    {
        playerStateMachine.FSM.ChangeState(PlayerStates.Default);
    }

    void Running_Update()
    {
    }
}
