using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSprintState : PlayerMovingState
{
    public PlayerSprintState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {
    }

    public override void EnterState()
    {
        base.EnterState();

        _stateMachine.stateReuseData.MovementSpeedMod = _movementData.RunData.SpeedMod;
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

        if (_stateMachine.stateReuseData.MovementInput == Vector2.zero)
            _stateMachine.ChangeState(_stateMachine.idleState);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    protected override void OnSprintToggle(InputAction.CallbackContext ctx)
    {
        base.OnSprintToggle(ctx);

        _stateMachine.ChangeState(_stateMachine.walkingState);
    }
}
