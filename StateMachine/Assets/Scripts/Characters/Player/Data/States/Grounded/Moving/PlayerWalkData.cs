using System;
using UnityEngine;

[Serializable]
public class PlayerWalkData
{

    [field: SerializeField] [field: Range(0, 1f)] public float SpeedMod { get; private set; } = 0.5f;
}
