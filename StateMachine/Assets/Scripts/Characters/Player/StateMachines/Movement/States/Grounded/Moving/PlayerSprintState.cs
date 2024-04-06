using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSprintState : PlayerMovingState
{

    private float _startTime;
    private PlayerPostDashData _postDashData;

    public PlayerSprintState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {
        _postDashData = _movementData.PostDashData;
    }

    public override void EnterState()
    {
        base.EnterState();
        _startTime = Time.time;
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

        if (!_stateMachine.stateReuseData.ShouldWalk)
            return;

        if (Time.time > _startTime + _postDashData.RunToWalkTime)
            return;

        StopSprint();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    protected override void OnMovementCanceled(InputAction.CallbackContext ctx)
    {
        _stateMachine.ChangeState(_stateMachine.medStoppingState);
    }

    private void StopSprint()
    {
        if (_stateMachine.stateReuseData.MovementInput == Vector2.zero)
        {
            _stateMachine.ChangeState(_stateMachine.idleState);
            return;
        }

        _stateMachine.ChangeState(_stateMachine.walkingState);
    }

    protected override void OnSprintToggle(InputAction.CallbackContext ctx)
    {
        base.OnSprintToggle(ctx);

        _stateMachine.ChangeState(_stateMachine.walkingState);
    }
}
