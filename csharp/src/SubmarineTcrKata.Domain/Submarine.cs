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

    public int Aim { get; internal set; } = Aim;

    public int Position { get; internal set; } = Position;

    public int Depth { get; internal set; } = Depth;

    public void MoveUp(int value)
        => this.Aim -= value;

    public void MoveDown(int value)
        => this.Aim += value;

    public void MoveForward(int value)
    {
        this.Position += value;
        this.Depth += this.Aim * value;
    }
}