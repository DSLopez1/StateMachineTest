using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDashState : PlayerGroundedState
{

    private PlayerDashData _dashData;
    private float _startDashTime;
    private int _consecutiveDashUsed;

    public PlayerDashState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {
        _dashData = _movementData.DashData;
    }

    public override void EnterState()
    {
        base.EnterState();

        _stateMachine.stateReuseData.MovementSpeedMod = _movementData.DashData.SpeedMod;

        AddForceOnTransitionFromStationaryState();

        UpdateConsecutiveDashes();

        _startDashTime = Time.time;
    }

    private void AddForceOnTransitionFromStationaryState()
    {
        if (_stateMachine.stateReuseData.MovementInput != Vector2.zero)
            return;

        Vector3 chararcterRotationDir = _stateMachine.player.transform.forward;

        chararcterRotationDir.y = 0;

        _stateMachine.player.rb.velocity = chararcterRotationDir * GetMoveSpeed();
    }

    private void UpdateConsecutiveDashes()
    {
        if (!IsConsecutive())
        {
            _consecutiveDashUsed = 0;
        }
        ++_consecutiveDashUsed;

        if (_consecutiveDashUsed == _dashData.ConsecutiveDashLimit)
        {
            _consecutiveDashUsed = 0;

            _stateMachine.player.Inputs.DisableActionFor(_stateMachine.player.Inputs.PlayerActions.Dash, _dashData.DashLimitCoolDown);
        }
    }

    private bool IsConsecutive()
    {
        return Time.time < _startDashTime + _dashData.TimeToBeConsideredConsecutive;
    }
    public override void OnAnimationTransitionEvent()
    {

        if (_stateMachine.stateReuseData.MovementInput != Vector2.zero)
        {
            _stateMachine.ChangeState(_stateMachine.hardStoppingState);
            return;
        }

        _stateMachine.ChangeState(_stateMachine.sprintState);
    }

    protected override void OnDashStarted(InputAction.CallbackContext ctx)
    {
    }

    protected override void OnMovementCanceled(InputAction.CallbackContext ctx)
    {
        _stateMachine.ChangeState(_stateMachine.hardStoppingState);
    }
}
