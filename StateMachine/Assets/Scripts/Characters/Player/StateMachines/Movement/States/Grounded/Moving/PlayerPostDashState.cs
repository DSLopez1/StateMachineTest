using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPostDashState : PlayerMovingState
{
    private PlayerPostDashData _postDashData;
    private float _startTime;
    private bool _keepDashing;
    
    public PlayerPostDashState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {
        _postDashData = _movementData.PostDashData;
    }

    public override void EnterState()
    {
        base.EnterState();

        _startTime = Time.time;
        _stateMachine.stateReuseData.MovementSpeedMod = _postDashData.SpeedMod;
    }

    public override void Update()
    {
        base.Update();

        if (_keepDashing)
            return;

        if (Time.time >= _startTime + _postDashData.PostDashToRunTime)
            return;

        StopPostDash();
    }

    public override void ExitState()
    {
        base.ExitState();

        _keepDashing = false;
    }

    private void StopPostDash()
    {
        if (_stateMachine.stateReuseData.MovementInput == Vector2.zero)
        {
            _stateMachine.ChangeState(_stateMachine.idleState);
            return;
        }

        _stateMachine.ChangeState(_stateMachine.sprintState);
    }

    protected override void OnMovementCanceled(InputAction.CallbackContext ctx)
    {
        _stateMachine.ChangeState(_stateMachine.hardStoppingState);
    }

    protected override void AddInputCallBacks()
    {
        base.AddInputCallBacks();

        _stateMachine.player.Inputs.PlayerActions.PostDashSprint.performed += OnPostSprintPerformed;
    }

    protected override void RemoveInputCallBacks()
    {
        base.RemoveInputCallBacks();

        _stateMachine.player.Inputs.PlayerActions.PostDashSprint.performed -= OnPostSprintPerformed;
    }

    private void OnPostSprintPerformed(InputAction.CallbackContext ctx)
    {
        _keepDashing = true;
    }
}
