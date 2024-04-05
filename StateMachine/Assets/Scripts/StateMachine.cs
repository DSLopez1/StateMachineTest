using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine 
{
    protected IState CurrentState;

    public void ChangeState(IState newState)
    {
        CurrentState?.ExitState();

        CurrentState = newState;
        CurrentState.EnterState();
    }

    public void HandleInput()
    {
        CurrentState?.HandleInput();
    }

    public void Update()
    {
        CurrentState?.Update();
    }

    public void PhysicsUpdate()
    {
        CurrentState?.PhysicsUpdate();
    }
}
