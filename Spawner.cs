using Godot;

namespace PrototypeSurvivor;

public partial class Spawner : Node
{
    [Export]
    public PackedScene EnemyScene { get; set; }

    public void SpawnEnemy()
    {
        SpawnEnemy(Vector2.Zero);
    }

    public void SpawnEnemy(Vector2 position)
    {
        var enemy = EnemyScene.Instantiate<Node2D>();
        enemy.Position = position;
        GetNode("../").AddChild(enemy);
    }
}