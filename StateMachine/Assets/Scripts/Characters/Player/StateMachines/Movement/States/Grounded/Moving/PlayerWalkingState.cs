using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerWalkingState : PlayerMovingState
{
    public PlayerWalkingState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {
    }

    public override void EnterState()
    {
        base.EnterState();

        _stateMachine.stateReuseData.MovementSpeedMod = _movementData.WalkData.SpeedMod;
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

    protected override void OnSprintToggle(InputAction.CallbackContext ctx)
    {
        base.OnSprintToggle(ctx);

        _stateMachine.ChangeState(_stateMachine.sprintState);
    }
}   
