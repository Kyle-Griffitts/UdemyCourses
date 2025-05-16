using Godot;
using System;
using System.Xml;

namespace Player
{
	public partial class Player : CharacterBody2D
	{
		float speed = 5.0f;
		float jump_velocity = -800.0f;
		float gravity = 15.0f;
		float max_fall_velocity = 1000.0f; // set the max fall velocity
		public Vector2 velocity = Vector2.Zero; // create a velocity variable and initialize it to zero. It is a Vector2 type.
		private AnimationPlayer animator; // create an animator variable for later use.

		// Called when the node enters the scene tree for the first time.  
		public override void _Ready()
		{
			base._Ready();
			var viewport_Size = GetViewportRect().Size;
			animator = GetNode<AnimationPlayer>("AnimationPlayer"); // need this to get the animators from Godot
		}

		// Called every frame. 'delta' is the elapsed time since the previous frame.  
		public override void _Process(double delta)
		{
			// Changing the animation based on action
			if (velocity.Y > 0)
			{	if (animator.CurrentAnimation != "fall")
				{
					animator.Play("fall");
				}
			}
			if(velocity.Y < 0)
			{
				if (animator.CurrentAnimation != "jump")
				{ 
					animator.Play("jump");
				}
			}
		}

		// moves the character left and right  
		public override void _PhysicsProcess(double delta)
		{
			if (Input.IsKeyPressed(Key.A) || Input.IsKeyPressed(Key.Left))
			{
				this.Position += new Vector2(-speed, 0);
			}

			if (Input.IsKeyPressed(Key.D) || Input.IsKeyPressed(Key.Right))
			{
				this.Position += new Vector2(speed, 0);
			}

			MoveAndSlide();

			//moves the character from one side of the screent to the other
			var viewport_Size = GetViewportRect().Size;
			var marigin = 20;
			if (this.Position.X > viewport_Size.X + marigin) // Right side
			{
				var newPosition = this.Position;
				newPosition.X = -marigin;
				this.Position = newPosition;
			}
			if (this.Position.X < -marigin) // Left side
			{
				var newPositionX = this.Position;
				newPositionX.X = viewport_Size.X + marigin;
				this.Position = newPositionX;
			}

			// Create gravity
			velocity.Y += gravity;
			if (velocity.Y > max_fall_velocity)
			{
				velocity.Y = max_fall_velocity;
			}
			Position += velocity * (float)delta;


		}

		public void Jump()
		{ 
			velocity.Y = jump_velocity;
		}

	}
}
