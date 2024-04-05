using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class PlayerMovementState : IState
{
    protected PlayerMovementStateMachine _stateMachine;

    protected Vector2 _input;

    protected float baseSpeed = 5f;
    protected float sprintMod = 1f;

    
    //Rotation variables for smoothing
    protected Vector3 currentTargetRotaton;
    protected Vector3 timeToRotate;
    protected Vector3 dampTargetRotCurrentVel;
    protected Vector3 dampedTargetRotPassedTime;

    public PlayerMovementState(PlayerMovementStateMachine playerMovementStateMachine)
    {
        _stateMachine = playerMovementStateMachine;

        InitializeRotationVariables();
    }

    private void InitializeRotationVariables()
    {
        timeToRotate.y = 0.14f;
    }

    public virtual void EnterState()
    {
        Debug.Log("State" + GetType().Name);
    }

    public virtual void ExitState()
    {
    }

    public virtual void HandleInput()
    {
        ReadMovementInput();
    }

    public virtual void Update()
    {
    }

    public virtual void PhysicsUpdate()
    {
        Move();
    }

    private void ReadMovementInput()
    {
        _input = _stateMachine.player.inputs.playerActions.Move.ReadValue<Vector2>();
    }

    private void Move()
    {
        if (_input == Vector2.zero || sprintMod == 0)
            return;

        Vector3 moveDir = GetMoveDirection();

        float targetRotationY = Rotate(moveDir);

        Vector3 targetRotDir = GettargetRotationDirection(targetRotationY);

        float moveSpeed = GetMoveSpeed();

        Vector3 currentPlayerVel = GetPlayerHorizontalVelocity();

        _stateMachine.player.rb.AddForce(moveSpeed * targetRotDir - currentPlayerVel, ForceMode.VelocityChange);
    }

    private float Rotate(Vector3 direction)
    {
        float dirAngle = UpdateTargetRotation(direction);

        RotatePlayerToTarget();

        return dirAngle;
    }

    private void UpdateRotationVariables(float targetAngle)
    {
        currentTargetRotaton.y= targetAngle;

        dampedTargetRotPassedTime.y = 0;
    }

    #region ReusableMethods

    protected Vector3 GettargetRotationDirection(float targetAngle)
    {
        return Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
    }

    protected float UpdateTargetRotation(Vector3 direction, bool considerCamRot = true)
    {
        float dirAngle = GetDirAngle(direction);

        if (considerCamRot)
        {
            dirAngle = AddCameraRotationToAngle(dirAngle);
        }

        if (dirAngle != currentTargetRotaton.y)
        {
            UpdateRotationVariables(dirAngle);
        }

        return dirAngle;
    }

    protected void RotatePlayerToTarget()
    {
        float currentYAngle = _stateMachine.player.rb.rotation.eulerAngles.y;

        if (currentYAngle  == currentTargetRotaton.y)
        {
            return;
        }

        float smothedYAngle = Mathf.SmoothDampAngle(currentYAngle, currentTargetRotaton.y, ref dampTargetRotCurrentVel.y, timeToRotate.y - dampedTargetRotPassedTime.y);

        dampedTargetRotPassedTime.y += Time.deltaTime;

        Quaternion targetRotation = Quaternion.Euler(0, smothedYAngle, 0);

        _stateMachine.player.rb.MoveRotation(targetRotation);
    }

    protected float GetDirAngle(Vector3 direction)
    {
        float dirAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

        if (dirAngle < 0f)
        {
            dirAngle += 360f;
        }

        return dirAngle;
    }

    private float AddCameraRotationToAngle(float angle)
    {
        angle += _stateMachine.player.playerCamera.eulerAngles.y;

        if (angle > 360f)
        {
            angle -= 360f;
        }
        return angle;
    }

    protected Vector3 GetMoveDirection()
    {
        return new Vector3(_input.x, 0, _input.y);
    }

    protected float GetMoveSpeed()
    {
        return baseSpeed * sprintMod;
    }

    protected Vector3 GetPlayerHorizontalVelocity()
    {
        Vector3 playerVel = _stateMachine.player.rb.velocity;
        playerVel.y = 0;
        return playerVel;
    }

    protected void ResetVelocity()
    {
        _stateMachine.player.rb.velocity = Vector3.zero;
    }

    #endregion

}
