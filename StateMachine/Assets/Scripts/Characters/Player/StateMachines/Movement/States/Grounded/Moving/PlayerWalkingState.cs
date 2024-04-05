using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerWalkingState : PlayerMovementState
{
    public PlayerWalkingState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {
    }

    public override void EnterState()
    {
        base.EnterState();

        _sprintMod = 0.5f;
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

        _stateMachine.ChangeState(_stateMachine.sprintState);
    }
}   
