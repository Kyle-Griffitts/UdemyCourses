using Godot;
using System;

public partial class GameCamera : Camera2D
{
	private Player.Player player = null;


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
		player = GetNode<Player.Player>("Player");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void Setup_Camera(Player.Player _player)
	{
		if (player != null)
		{
			player = _player;
		}
	}

	public override void _PhysicsProcess(double delta)
	{
		if (player != null)
		{
			GlobalPosition = new Vector2(GlobalPosition.X, player.GlobalPosition.Y);
		}
	}

}
