using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHardStoppingState : PlayerStoppingState
{
    public PlayerHardStoppingState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {
    }

    public override void EnterState()
    {
        base.EnterState();

        _stateMachine.stateReuseData.movementDecelForce = _movementData.StopData.HardDecelForce;
    }

    protected override void OnMove()
    {
        if (_stateMachine.stateReuseData.ShouldWalk)
            return;

        _stateMachine.ChangeState(_stateMachine.sprintState);

    }
}
