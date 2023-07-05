namespace SubmarineTcrKata.Domain;

public record Submarine(int Depth, int Position, int Aim) : ISubmarine
{
    public Submarine() : this(0, 0, 0)
    {
    }

    public void ExecuteCommand(string command)
    {
        var commandParts = command.Split(" ");
        var commandName = commandParts[0];
        var commandValue = int.Parse(commandParts[1]);

        switch (commandName)
        {
            case "forward":
                Position += commandValue;
                Depth += Aim * commandValue;
                break;
            case "down":
                Aim += commandValue;
                break;
        }
    }

    public int Aim { get; private set; } = Aim;

    public int Position { get; private set; } = Position;

    public int Depth { get; private set; } = Depth;
}