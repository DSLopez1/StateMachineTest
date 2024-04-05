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

        sprintMod = 0;
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
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
