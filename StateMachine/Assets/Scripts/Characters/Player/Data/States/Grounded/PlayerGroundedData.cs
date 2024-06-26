using System;
using UnityEngine;

[Serializable]
public class PlayerGroundedData 
{
    [field: SerializeField][field: Range(0, 25f)] public float BaseSpeed { get; private set; }

    [field: SerializeField] public AnimationCurve SlopeSpeedAngles { get; private set; }

    [field: SerializeField] public PlayerRotationData RotationData { get; private set; }

    [field: SerializeField] public PlayerWalkData WalkData { get; private set; }

    [field: SerializeField] public PlayerRunData RunData { get; private set; }

    [field: SerializeField] public PlayerPostDashData PostDashData { get; private set; }

    [field: SerializeField] public PlayerDashData DashData { get; private set; }

    [field: SerializeField] public PlayerStopData StopData { get; private set; }

}
