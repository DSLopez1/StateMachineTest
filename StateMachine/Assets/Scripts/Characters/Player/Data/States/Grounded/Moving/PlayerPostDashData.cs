using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]

public class PlayerPostDashData
{
    [field: SerializeField][field: Range(0, 1)] public float SpeedMod { get; private set; } = 1.7f;

    [field: SerializeField][field: Range(0, 5)] public float PostDashToRunTime { get; private set; } = 1;

    [field: SerializeField][field: Range(0, 2)] public float RunToWalkTime { get; private set; } = 0.5f;
}
