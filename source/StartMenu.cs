using Godot;

namespace PrototypeSurvivor;

public partial class StartMenu : Control
{
	public void StartGame()
	{
		GetTree().ChangeSceneToFile("res://main.tscn");
	}

	public void ExitGame()
	{
		GetTree().Quit();
	}
}
