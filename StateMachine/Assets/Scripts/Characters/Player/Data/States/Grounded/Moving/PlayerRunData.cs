using System;
using UnityEngine;

[Serializable]
public class PlayerRunData
{
    [field: SerializeField][field: Range(0, 2f)] public float SpeedMod { get; private set; } = 1f;

}
