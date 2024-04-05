using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSprintState : PlayerMovementState
{
    public PlayerSprintState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {
    }

    public override void EnterState()
    {
        base.EnterState();

        _sprintMod = 1f;
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
            _stateMachine.ChangeState(_stateMachine.idleState);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
    protected override void AddInputCallBacks()
    {
        base.AddInputCallBacks();

        _stateMachine.player.inputs.playerActions.SprintToggle.canceled += OnMovementCanceled;
    }

    protected override void RemoveInputCallBacks()
    {
        base.RemoveInputCallBacks();

        _stateMachine.player.inputs.playerActions.SprintToggle.canceled -= OnMovementCanceled;
    }

    protected void OnMovementCanceled(InputAction.CallbackContext ctx)
    {
        _stateMachine.ChangeState(_stateMachine.idleState);
    }

    protected override void OnSprintToggle(InputAction.CallbackContext ctx)
    {
        base.OnSprintToggle(ctx);

        _stateMachine.ChangeState(_stateMachine.walkingState);
    }
}
