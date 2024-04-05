using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovementStateMachine : StateMachine
{
    public Player player { get; }

    public PlayerMovementState idleState { get; }

    public PlayerMovementState walkingState { get; }


    public PlayerMovementState sprintState { get; }

    public PlayerMovementStateMachine(Player player) 
    {
        this.player = player;
        idleState = new PlayerIdleState(this);

        walkingState = new PlayerWalkingState(this);
        sprintState = new PlayerSprintState(this);
    }
}
