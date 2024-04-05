using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerMovementState
{
    public PlayerIdleState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {
    }

    public override void EnterState()
    {
        base.EnterState();

        _sprintMod = 0;
        ResetVelocity();
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void HandleInput()
    {
        base.HandleInput();
    }

    public override void Update()
    {
        base.Update();

        if (_input == Vector2.zero)
            return;

        OnMove();
    }

    private void OnMove()
    {
        if (_shouldWalk)
            _stateMachine.ChangeState(_stateMachine.walkingState);
        else
            _stateMachine.ChangeState(_stateMachine.sprintState);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
