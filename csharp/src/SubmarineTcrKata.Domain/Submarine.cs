namespace SubmarineTcrKata.Domain;

public record Submarine(int Depth, int Position, int Aim) : ISubmarine
{
    public Submarine() : this(0, 0, 0)
    {
    }

    public void ExecuteCommand(string commandDescription)
    {
        Command.New(commandDescription).ExecuteCommand(this);
    }

    public int Aim { get; private set; } = Aim;

    public int Position { get; private set; } = Position;

    public int Depth { get; private set; } = Depth;

    public void MoveUp(int value)
        => Aim -= value;

    public void MoveDown(int value)
        => Aim += value;

    public void MoveForward(int value)
    {
        Position += value;
        Depth += Aim * value;
    }
}