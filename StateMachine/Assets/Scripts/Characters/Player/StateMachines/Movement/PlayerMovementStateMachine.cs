using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovementStateMachine : StateMachine
{
    public Player player { get; }
    public PlayerStateReuseData stateReuseData { get; }

    public PlayerMovementState idleState { get; }

    public PlayerDashState dashState { get; }

    public PlayerMovementState walkingState { get; }

    public PlayerMovementState sprintState { get; }

    public PlayerPostDashState postDashState { get; }

    public PlayerStoppingState stoppingState { get; }

    public PlayerHardStoppingState hardStoppingState { get; }

    public PlayerMedStoppingState medStoppingState { get; }

    public PlayerLightStoppingState lightStoppingState { get; }

    public PlayerMovementStateMachine(Player player) 
    {
        this.player = player;
        stateReuseData = new PlayerStateReuseData();
        idleState = new PlayerIdleState(this);
        dashState = new PlayerDashState(this);
        walkingState = new PlayerWalkingState(this);
        sprintState = new PlayerSprintState(this);
        postDashState = new PlayerPostDashState(this);
        stoppingState = new PlayerStoppingState(this);
        hardStoppingState = new PlayerHardStoppingState(this);
        medStoppingState = new PlayerMedStoppingState(this);
        lightStoppingState = new PlayerLightStoppingState(this);

    }
}
