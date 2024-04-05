using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerGroundedState
{
    public PlayerIdleState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {
    }

    public override void EnterState()
    {
        base.EnterState();

        _stateMachine.stateReuseData.MovementSpeedMod = 0;
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

        if (_stateMachine.stateReuseData.MovementInput == Vector2.zero)
            return;

        OnMove();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
