namespace SubmarineTcrKata.Domain;

public record Submarine(int Depth, int Position, int Aim) : ISubmarine
{
    public Submarine() : this(0, 0, 0)
    {
    }

    public void ExecuteCommand(string commandDescription)
    {
        var command = Command.New(commandDescription);

        switch (command.Name)
        {
            case "forward":
                Position += command.Value;
                Depth += Aim * command.Value;
                break;
            case "down":
                Aim += command.Value;
                break;
            case "up":
                Aim -= command.Value;
                break;
        }
    }


    public int Aim { get; private set; } = Aim;

    public int Position { get; private set; } = Position;

    public int Depth { get; private set; } = Depth;
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
}