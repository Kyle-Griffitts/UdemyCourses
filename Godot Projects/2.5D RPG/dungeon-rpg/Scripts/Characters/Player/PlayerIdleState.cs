using DungeonRPG.Scripts.General;
using Godot;
using System;
using System.Transactions;

public partial class PlayerIdleState : PlayerState
{


    public override void _PhysicsProcess(double delta)
    {
        if (characterNode.direction != Vector2.Zero)
        {
            characterNode.stateMachineNode.SwitchState<PlayerMoveState>();
        }
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

        characterNode.animPlayerNode.Play(GameConstants.ANIM_IDLE);
    }

}
