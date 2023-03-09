using Godot;

namespace PrototypeSurvivor;

public partial class Player : CharacterBody2D
{
    [Signal]
    public delegate void CurrentHealthChangedEventHandler(int value);

    [Export]
    public float Speed { get; set; }

    [Export(PropertyHint.Range, "0, 1000, 1, or_greater")]
    public int MaxHealth { get; set; } = 100;

    public int CurrentHealth
    {
        get => _currentHealth;
        private set
        {
            _currentHealth = value;
            EmitSignal(SignalName.CurrentHealthChanged, CurrentHealth);
        }
    }

    private int _currentHealth;

    public override void _Ready()
    {
        CurrentHealth = MaxHealth;
    }

    public override void _PhysicsProcess(double delta)
    {
        var moveDirection = Input.GetVector(InputActions.MoveLeft,
                                            InputActions.MoveRight,
                                            InputActions.MoveUp,
                                            InputActions.MoveDown);

        Velocity = moveDirection * Speed;

        if (MoveAndSlide())
        {
            RegisterHit();
        }
    }

    private void RegisterHit()
    {
        CurrentHealth -= 1;
    }
}
