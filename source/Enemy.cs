using System;
using Godot;

namespace PrototypeSurvivor;

public partial class Enemy : CharacterBody2D
{
	[Export]
	public float Speed { get; set; }

	private Node2D _player;

	private Vector2 _destination;

	public override void _Ready()
	{
		_player = GetNode<Node2D>("../Player");
		UpdateDestination();
	}

	public override void _PhysicsProcess(double delta)
	{
		var direction = GlobalPosition.DirectionTo(_destination);
		Velocity = direction * Speed;
		MoveAndSlide();
	}

	public void UpdateDestination()
	{
		_destination = _player.GlobalPosition;
		_destination.X += Random.Shared.Next(-100, 100);
		_destination.Y += Random.Shared.Next(-100, 100);
	}
}
