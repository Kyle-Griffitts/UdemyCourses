using Godot;
using System;

public partial class StateMachine : Node
{
    // using Node so we can switch states on demand
    [Export] private Node currentState;
    [Export] private Node[] states;

    public override void _Ready()
    {
        currentState.Notification(5001); // notifies the StateMachine Node that a State has been enabled
        // any arbitray number can work
    }

    public void SwitchState<T>() // creating a generic data type <T> for access to the PlayerStates
    {
        Node newState = null;

        // cycle through each state
        foreach (Node state in states)
        {
            if (state is T)
            {
                newState = state;
            }
        }

        if (newState == null) { return; }

        currentState.Notification(5002); // sending a disabling notification first to the previous state isn't lost
        currentState = newState;
        currentState.Notification(5001);
    }

}
