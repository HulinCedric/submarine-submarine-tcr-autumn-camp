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

    public int Aim { get; set; } = Aim;

    public int Position { get; set; } = Position;

    public int Depth { get; set; } = Depth;
}

public record Command(string Name, int Value)
{
    public static Command New(string commandDescription)
    {
        var commandParts = commandDescription.Split(" ");
        var commandName = commandParts[0];
        var commandValue = int.Parse(commandParts[1]);
        return new Command(commandName, commandValue);
    }

    public void ExecuteCommand(Submarine submarine)
    {
        switch (Name)
        {
            case "forward":
                submarine.Position += Value;
                submarine.Depth += submarine.Aim * Value;
                break;
            case "down":
                submarine.Aim += Value;
                break;
            case "up":
                submarine.Aim -= Value;
                break;
        }
    }
}