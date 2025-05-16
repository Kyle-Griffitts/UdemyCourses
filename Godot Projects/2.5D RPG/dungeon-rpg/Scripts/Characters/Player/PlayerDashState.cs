using DungeonRPG.Scripts.General;
using Godot;
using System;

public partial class PlayerDashState : PlayerState
{
    [Export] private Timer dashTimerNode;
    [Export] private float speed = 10f;

    public override void _Ready()
    {
        base._Ready(); // crucial to call the original Ready method 
        dashTimerNode.Timeout += HandleDashTimeout;

    }

    protected override void EnterState()
    {

            characterNode.animPlayerNode.Play(GameConstants.ANIM_DASH);
            characterNode.Velocity = new(
                characterNode.direction.X, 0 ,characterNode.direction.Y); // setting the velocity before the timer so direction can be determined before the dash
            
            if (characterNode.Velocity == Vector3.Zero)
            {
                characterNode.Velocity = characterNode.spriteNode.FlipH ?
                    Vector3.Left :
                    Vector3.Right;
            }
                        
            characterNode.Velocity *= speed; // sets the dash velocity to the speed of the dash
            dashTimerNode.Start();
    }

    // adding movement and update the character on every frame
    public override void _PhysicsProcess(double delta)
    {
        characterNode.MoveAndSlide();
        characterNode.Flip();
    }

    private void HandleDashTimeout()
    {
        characterNode.stateMachineNode.SwitchState<PlayerIdleState>();
        characterNode.Velocity = Vector3.Zero;
    }

    public override void _Input(InputEvent @event)
    {
        if (Input.IsActionPressed(GameConstants.INPUT_DASH))
        {
            characterNode.stateMachineNode.SwitchState<PlayerDashState>();
        }
    }


}
