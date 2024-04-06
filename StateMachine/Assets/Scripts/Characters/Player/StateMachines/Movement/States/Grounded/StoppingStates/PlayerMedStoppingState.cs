using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMedStoppingState : PlayerStoppingState
{
    public PlayerMedStoppingState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {
    }

    public override void EnterState()
    {
        base.EnterState();

        _stateMachine.stateReuseData.movementDecelForce = _movementData.StopData.MedDecelForce;
    }


}


