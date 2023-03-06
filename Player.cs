using Godot;
using PrototypeSurvivor;

public partial class Player : CharacterBody2D
{
	[Export]
	public float Speed { get; set; }

	public override void _PhysicsProcess(double delta)
	{
		var moveDirection = Input.GetVector(InputActions.MoveLeft, InputActions.MoveRight, InputActions.MoveUp,
			InputActions.MoveDown);

		Velocity = moveDirection * Speed;
		MoveAndSlide();
	}
}
