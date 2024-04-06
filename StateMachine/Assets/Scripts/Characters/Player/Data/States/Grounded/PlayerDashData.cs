using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]

public class PlayerDashData
{
    [field: SerializeField][field: Range(0, 2)] public float TimeToBeConsideredConsecutive { get; private set; } = 1f;
    [field: SerializeField][field: Range(1, 10)] public int ConsecutiveDashLimit { get; private set; } = 2;

    [field: SerializeField][field: Range(0, 5)] public float DashLimitCoolDown { get; private set; } = 1.75f;

    [field: SerializeField] [field: Range(1, 3)] public float SpeedMod { get; private set; } = 2;

}
