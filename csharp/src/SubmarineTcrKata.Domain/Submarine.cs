namespace SubmarineTcrKata.Domain;

public record Submarine(int Depth, int Position, int Aim) : ISubmarine
{
    public Submarine() : this(0, 0, 0)
    {
    }

    public void ExecuteCommand(string commandDescription)
    {
        var command = Command.New(commandDescription);

        command.ExecuteCommand(this);
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
        switch (this.Name)
        {
            case "forward":
                submarine.Position += this.Value;
                submarine.Depth += submarine.Aim * this.Value;
                break;
            case "down":
                submarine.Aim += this.Value;
                break;
            case "up":
                submarine.Aim -= this.Value;
                break;
        }
    }
}