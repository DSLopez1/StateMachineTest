using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]

public class SlopeData
{
    [field: SerializeField] [field: Range(0, 1)] public float StepHeightPercentage { get; private set; } = 0.25f;
    [field: SerializeField][field: Range(0, 5)] public float FloatRayDist { get; private set; } = 2.5f;

    [field: SerializeField][field: Range(0, 50)] public float StepReachForce { get; private set; } = 25f;


}
