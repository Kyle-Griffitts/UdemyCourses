using DungeonRPG.Scripts.General;
using Godot;
using System;

//need partial keyword so we can define the same keyword multiple times i.e. two classes with the same name
// at runtime, these get meshed into one class. This allows them to be split into multiple cs files.
// inheritence & composition is a better solution to partial but Godot requires partial for code analysis
public partial class Player : CharacterBody3D
{
    // exporting attributes so we can modify them, AnimationPlayer is the Animation we set up
    // created a variable to it can be modified
    [ExportGroup("Required Nodes")]
    [Export] public AnimationPlayer animPlayerNode;
    [Export] public Sprite3D spriteNode;
    [Export] public StateMachine stateMachineNode;
    
    // creating a private Vector2 to a 0,0 initialization
    public Vector2 direction = new();


 


    public override void _Input(InputEvent @event)
    {
        // initialized direction gets updated by the Input from the WASD that was mapped in Project Settings -> Input Map 
        direction = Input.GetVector(
            GameConstants.INPUT_MOVE_LEFT, GameConstants.INPUT_MOVE_RIGHT, 
            GameConstants.INPUT_MOVE_FORWARD, GameConstants.INPUT_MOVE_BACKWARD);

    }

    // private method created to Flip the animation when character moves left
    public void Flip()
    {
        bool isNotMovingHorizontally = Velocity.X == 0; // checks to see if player is moving
       
        if (isNotMovingHorizontally)
        {
            return;
        }
        
        bool isMovingLeft = Velocity.X < 0; // if velocity of X is negative than they are left
        spriteNode.FlipH = isMovingLeft;
        
    }


}
