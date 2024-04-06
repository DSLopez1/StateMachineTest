using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStoppingState : PlayerGroundedState
{
    public PlayerStoppingState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {
    }

    public override void EnterState()
    {
        base.EnterState();

        _stateMachine.stateReuseData.MovementSpeedMod = 0;
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        if (!IsMovingHorizontally())
            return;

        DecelerateHorizontally();
    }

    protected override void AddInputCallBacks()
    {
        base.AddInputCallBacks();

        _stateMachine.player.Inputs.PlayerActions.Move.started += OnMovementStarted;
    }

    protected override void RemoveInputCallBacks()
    {
        base.RemoveInputCallBacks();

        _stateMachine.player.Inputs.PlayerActions.Move.started -= OnMovementStarted;
    }

    public override void OnAnimationTransitionEvent()
    {
        _stateMachine.ChangeState(_stateMachine.idleState);
    }

    protected override void OnMovementCanceled(InputAction.CallbackContext ctx)
    {
    }

    private void OnMovementStarted(InputAction.CallbackContext ctx)
    {
        OnMove();
    }
}