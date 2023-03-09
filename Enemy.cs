using Godot;

namespace PrototypeSurvivor;

public partial class Enemy : CharacterBody2D
{
	[Export]
	public float Speed { get; set; }

	public override void _PhysicsProcess(double delta)
	{
		var player = GetNode<Node2D>("../Player");
		var direction = GlobalPosition.DirectionTo(player.GlobalPosition);
		Velocity = direction * Speed;
		MoveAndSlide();
	}
}
