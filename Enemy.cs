using System;
using System.Collections.ObjectModel;
using Godot;

namespace PrototypeSurvivor;

public partial class Enemy : CharacterBody2D
{
	[Export]
	public float Speed { get; set; }

	private Node2D _player;
	
	private Vector2 destination;

	public override void _Ready()
	{
		_player = GetNode<Node2D>("../Player");
		UpdateDestination();
	}

	public override void _PhysicsProcess(double delta)
	{
		var direction = GlobalPosition.DirectionTo(destination);
		Velocity = direction * Speed;
		MoveAndSlide();
	}

	public void UpdateDestination()
	{
		destination = _player.GlobalPosition;
		destination.X += Random.Shared.Next(-100, 100);
		destination.Y += Random.Shared.Next(-100, 100);
	}
}
