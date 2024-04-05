using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "Custom/Character/Player")]

public class playerSO : ScriptableObject
{
    [field: SerializeField] public PlayerGroundedData GroundedData { get; private set; }
}
