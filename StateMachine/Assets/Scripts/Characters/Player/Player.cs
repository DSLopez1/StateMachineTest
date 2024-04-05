using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]

public class Player : MonoBehaviour
{

    [field: Header("---References---")]
    [field: SerializeField] public playerSO Data { get; private set; }
    public Rigidbody rb { get; private set; }

    public Transform playerCamera { get; private set; }

    private PlayerMovementStateMachine _movementStateMachine;

    public PlayerInput Inputs { get; private set; }

    private void Awake()
    {
        Inputs = GetComponent<PlayerInput>();
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
