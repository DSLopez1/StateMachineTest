using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateReuseData
{
    public Vector2 MovementInput { get; set; }

    public float MovementSpeedMod { get; set; }

    public float MovementOnSlopeSpeedMod { get; set; } = 1;

    public float movementDecelForce { get; set; } = 1;

    public bool ShouldWalk { get; set; }

    private Vector3 _currentTargetRotation;
    private Vector3 _timeToReachTargetRotation;
    private Vector3 _dampedTargetRotationCurrentVelocity;
    private Vector3 _dampedTargetRotationPassTime;

    public ref Vector3 CurrentTargetRotation
    {
        get
        {
            return ref _currentTargetRotation;
        }
    }

    public ref Vector3 TimeToReachTargetRotation
    {
        get
        {
            return ref _timeToReachTargetRotation;
        }
    }

    public ref Vector3 DampedTargetRotationCurrentVelocity
    {
        get
        {
            return ref _dampedTargetRotationCurrentVelocity;
        }
    }

    public ref Vector3 DampedTargetRotationPassTime
    {
        get
        {
            return ref _dampedTargetRotationPassTime;
        }
    }

}
