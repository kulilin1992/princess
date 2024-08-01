using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    IState currentState;

    protected Dictionary<Type, IState> statesTable;
    void Update()
    {
        currentState.OnUpdate();
    }
    void FixedUpdate()
    {
        currentState.OnFixedUpdate();   
    }

    protected void SetState(IState newState)
    {
        currentState = newState;
        currentState.OnEnter();
    
    }
    public void ChangeState(IState newState)
    {
        currentState.OnExit();
        SetState(newState);  
    }

    public void ChangeState(Type newStateType)
    {
        SetState(statesTable[newStateType]);
    }
}
