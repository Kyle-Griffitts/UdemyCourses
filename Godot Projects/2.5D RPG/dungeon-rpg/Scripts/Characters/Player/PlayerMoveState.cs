using DungeonRPG.Scripts.General;
using Godot;
using System;
using static Godot.TextServer;

public partial class PlayerMoveState : PlayerState
{

    // need to create a method for the character to move. This is the _PhysicsProcess in C#
    // override allows for two methods to have the same name
    // check to see if the player is NOT moving
    public override void _PhysicsProcess(double delta)
    {
        if (characterNode.direction == Vector2.Zero)
        {
            characterNode.stateMachineNode.SwitchState<PlayerIdleState>();
            return;
        }

        // Velocity is setting to a new instance of vector3 type, vector3 has to be created 
        // Y is used for vertical so it is remapped to the Z axis in a 2D game using 3D graphics.
        characterNode.Velocity = new(characterNode.direction.X, 0, characterNode.direction.Y);
        characterNode.Velocity *= 5; // increasing the movement speed

        characterNode.MoveAndSlide(); //physics to move and slide on impact rather than stop aburptly

        characterNode.Flip(); // calling the Flip method

    }

    public override void _Input(InputEvent @event)
    {
        if (Input.IsActionJustPressed(GameConstants.INPUT_DASH))
        {
            characterNode.stateMachineNode.SwitchState<PlayerDashState>();
        }
    }

    protected override void EnterState()
    {
        base.EnterState();

        characterNode.animPlayerNode.Play(GameConstants.ANIM_MOVE);
    }

}
