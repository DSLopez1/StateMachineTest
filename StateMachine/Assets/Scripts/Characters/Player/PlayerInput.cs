using Unity.VisualScripting;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public PlayerControls inputs { get; private set; }

    public PlayerControls.PlayerActionsActions playerActions { get; private set; }

    private void Awake()
    {
        inputs = new PlayerControls();

        playerActions = inputs.PlayerActions;
    }

    private void OnEnable ()
    {
        inputs.Enable();
    }

    private void OnDisable()
    {
        inputs.Disable();
    }
}
