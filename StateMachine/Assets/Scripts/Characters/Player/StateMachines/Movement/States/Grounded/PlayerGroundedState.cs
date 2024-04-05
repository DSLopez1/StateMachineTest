using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerGroundedState : PlayerMovementState
{
    public PlayerGroundedState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
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
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    protected virtual void OnMove()
    {
        if (_stateMachine.stateReuseData.ShouldWalk)
            _stateMachine.ChangeState(_stateMachine.walkingState);
        else
            _stateMachine.ChangeState(_stateMachine.sprintState);
    }

    protected override void AddInputCallBacks()
    {
        base.AddInputCallBacks();

        _stateMachine.player.Inputs.PlayerActions.SprintToggle.canceled += OnMovementCanceled;
    }

    protected override void RemoveInputCallBacks()
    {
        base.RemoveInputCallBacks();

        _stateMachine.player.Inputs.PlayerActions.SprintToggle.canceled -= OnMovementCanceled;
    }

    protected virtual void OnMovementCanceled(InputAction.CallbackContext ctx)
    {
        _stateMachine.ChangeState(_stateMachine.idleState);
    }
}
