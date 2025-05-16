using Godot;
using System;


public partial class Game : Node2D
{
	PackedScene cameraScene = (PackedScene)ResourceLoader.Load("res://scenes/game_camera.tscn");
	private Camera2D camera = null;

	public override void _Ready()
	{
		camera = new Camera2D();
		var player = GetNode<Player.Player>("Player");
		if (player != null)
		{
			camera.MakeCurrent();
			camera.Position = player.Position;
		}
		AddChild(camera);
	}
	public override void _Process(double delta)
	{
	}
}
