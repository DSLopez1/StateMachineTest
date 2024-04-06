using System.Collections;
using System.Collections.Generic;
using Unity.Android.Types;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerGroundedState : PlayerMovementState
{

    private SlopeData _slopeData;

    public PlayerGroundedState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {
        _slopeData = _stateMachine.player.ColliderUtility.SlopeData;
    }

    public override void EnterState()
    {
        base.EnterState();
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
        Float();
    }   

    private void Float()
    {
        Vector3 capsuleColliderInWorldSpace = _stateMachine.player.ColliderUtility.CapsuleColliderData.Collider.bounds.center;

        Ray downWardRayFromCapsuleCenter = new Ray(capsuleColliderInWorldSpace, Vector3.down);

        if (Physics.Raycast(downWardRayFromCapsuleCenter, out RaycastHit hit, _slopeData.FloatRayDist, _stateMachine.player.LayerData.GroundLayer, QueryTriggerInteraction.Ignore))
        {
            float groundAngle = Vector3.Angle(hit.normal, -downWardRayFromCapsuleCenter.direction);

            float slopeSpeedMod = SetSlopeSpeedModOnAngle(groundAngle);

            if (slopeSpeedMod == 0f)
                return;

            float distToFoatPoint = _stateMachine.player.ColliderUtility.CapsuleColliderData.ColliderCenterInLocalSpace.y * _stateMachine.player.transform.localScale.y - hit.distance;

            if (distToFoatPoint == 0)
                return;

            float amountToLift = distToFoatPoint * _slopeData.StepReachForce - GetPlayerVerticalVelocity().y;

            Vector3 liftForce = new Vector3(0, amountToLift, 0);

            _stateMachine.player.rb.AddForce(liftForce, ForceMode.VelocityChange);
        }
    }

    private float SetSlopeSpeedModOnAngle(float angle)
    {
        float slopeSpeedMod = _movementData.SlopeSpeedAngles.Evaluate(angle);

        _stateMachine.stateReuseData.MovementOnSlopeSpeedMod = slopeSpeedMod;

        return slopeSpeedMod;
    }

    protected virtual void OnMove()
    {
        if (_stateMachine.stateReuseData.ShouldWalk)
            _stateMachine.ChangeState(_stateMachine.walkingState);
        else
            _stateMachine.ChangeState(_stateMachine.sprintState);
    }

    protected override void AddInputCallBacks()
    {
        base.AddInputCallBacks();

        _stateMachine.player.Inputs.PlayerActions.SprintToggle.canceled += OnMovementCanceled;

        _stateMachine.player.Inputs.PlayerActions.Dash.started += OnDashStarted;
    }

    protected override void RemoveInputCallBacks()
    {
        base.RemoveInputCallBacks();

        _stateMachine.player.Inputs.PlayerActions.SprintToggle.canceled -= OnMovementCanceled;
        _stateMachine.player.Inputs.PlayerActions.Dash.started -= OnDashStarted;

    }

    protected virtual void OnMovementCanceled(InputAction.CallbackContext ctx)
    {
        _stateMachine.ChangeState(_stateMachine.idleState);
    }

    protected virtual void OnDashStarted(InputAction.CallbackContext ctx)
    {
        _stateMachine.ChangeState(_stateMachine.dashState);
    }
}
