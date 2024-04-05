using UnityEngine;

[RequireComponent(typeof(PlayerInput))]

public class Player : MonoBehaviour
{
    public Rigidbody rb { get; private set; }

    public Transform playerCamera { get; private set; }

    private PlayerMovementStateMachine _movementStateMachine;

    public PlayerInput inputs { get; private set; }

    private void Awake()
    {
        inputs = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();

        playerCamera = Camera.main.transform;

        _movementStateMachine = new PlayerMovementStateMachine(this);

    }

    private void Start()
    {
        _movementStateMachine.ChangeState(_movementStateMachine.idleState);
    }

    private void Update()
    {
        _movementStateMachine.HandleInput();
        _movementStateMachine.Update();
    }

    private void FixedUpdate()
    {
        _movementStateMachine.PhysicsUpdate();
    }
}
