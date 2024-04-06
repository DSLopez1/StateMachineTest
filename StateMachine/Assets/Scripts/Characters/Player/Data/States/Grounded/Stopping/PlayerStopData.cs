using System;
using UnityEngine;

[Serializable]

public class PlayerStopData
{
    [field: SerializeField][field: Range(0, 15f)] public float LightDecelForce { get; private set; } = 5;
    [field: SerializeField][field: Range(0, 15f)] public float MedDecelForce { get; private set; } = 6.5f;
    [field: SerializeField][field: Range(0, 15f)] public float HardDecelForce { get; private set; } = 5f;
}
