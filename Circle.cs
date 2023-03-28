using Godot;

namespace PrototypeSurvivor;

public partial class Circle : Node2D
{
	[Export]
	public int RotationSpeed { get; set; }
	
	[Export]
	public int Radius { get; set; }
	
	[Export]
	public int PushBackDistance { get; set; }

	public override void _Ready()
	{
		var area = GetChild<Area2D>(0);
		area.Position = Vector2.Right * Radius;
		area.BodyEntered += OnBodyEntered;
	}

	public override void _PhysicsProcess(double delta)
	{
		RotationDegrees += RotationSpeed * (float)delta;
	}

	private void OnBodyEntered(Node2D body)
	{
		if (body is not Enemy enemy)
		{
			return;
		}

		var pushBack = PushBackDistance * GlobalPosition.DirectionTo(enemy.GlobalPosition);
		enemy.MoveAndCollide(pushBack);
	}
}
