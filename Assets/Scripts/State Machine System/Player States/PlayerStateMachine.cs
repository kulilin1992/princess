using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{

    // public PlayerStateIdle idleState;
    // public PlayerStateRun runState;

    [SerializeField] PlayerState[] playerStates;
    Animator animator;

    PlayerInput playerInput;

    PlayerController playerController;

    void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        statesTable = new Dictionary<Type, IState>(playerStates.Length);
        // idleState.Initialize(animator, this);
        // runState.Initialize(animator, this);
        playerInput = GetComponent<PlayerInput>();
        playerController = GetComponent<PlayerController>();
    

        foreach (var state in playerStates)
        {
            state.Initialize(animator, playerInput, playerController, this);
            statesTable.Add(state.GetType(), state);
        }
    }

    void Start()
    {
        SetState(statesTable[typeof(PlayerStateIdle)]);
    
    }

}
