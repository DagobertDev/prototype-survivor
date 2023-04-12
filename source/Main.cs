using Godot;

namespace PrototypeSurvivor;

public partial class Main : Node
{
	[Signal]
	public delegate void GameOverEventHandler();

	public override void _Ready()
	{
		GameOver += () => GetTree().Paused = true;
	}

	public void OnPlayerGotDamaged(int remainingHP)
	{
		if (remainingHP == 0)
		{
			EmitSignal(SignalName.GameOver);
		}
	}
}
