using Godot;

public partial class Circle : Node2D
{
	[Export]
	public int RotationSpeed { get; set; }
	
	[Export]
	public int Radius { get; set; }

	public override void _Ready()
	{
		GetChild<Node2D>(0).Position = Vector2.Right * Radius;
	}

	public override void _PhysicsProcess(double delta)
	{
		RotationDegrees += RotationSpeed * (float)delta;
	}
}
