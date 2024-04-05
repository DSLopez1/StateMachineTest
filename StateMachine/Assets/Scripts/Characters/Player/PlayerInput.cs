using Unity.VisualScripting;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public PlayerControls Inputs { get; private set; }

    public PlayerControls.PlayerActionsActions PlayerActions { get; private set; }

    private void Awake()
    {
        Inputs = new PlayerControls();

        PlayerActions = Inputs.PlayerActions;
    }

    private void OnEnable ()
    {
        Inputs.Enable();
    }

    private void OnDisable()
    {
        Inputs.Disable();
    }
}
