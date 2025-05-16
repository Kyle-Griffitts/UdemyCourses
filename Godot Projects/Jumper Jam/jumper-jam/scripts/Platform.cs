using Godot;
using System;


namespace Platform
{
	public partial class Platform : Area2D
	{
		// use _on_body_entered to detect when the player enters the platform
		// you have to used Node <name> to interact with the player in C#
		private void _on_body_entered(Node body)
		{
			// Check if the body is a Player instance
			if (body is Player.Player player)
			{

				// Check if the player's velocity.Y is greater than 0 (falling)
				if (player.velocity.Y >= 0)
				{
					// Trigger the player's jump
					player.Jump();
				}
			}
		}
	}
}
