namespace SubmarineTcrKata.Domain;

public record Submarine(int Depth, int Position, int Aim) : ISubmarine
{
    
    public Submarine(): this(0,0,0)
    {
    }

    public void ExecuteCommand(string command)
    {
        var commandParts = command.Split(" ");
        var commandName = commandParts[0];
        var commandValue = int.Parse(commandParts[1]);
        
        if (commandName == "forward")
        {
            Position += commandValue;
            Depth += Aim * commandValue;
        }

        if (commandName == "down")
        {
            Aim += commandValue;
        }
    }

    public int Aim { get; set; } = Aim;

    public int Position { get; set; } = Position;

    public int Depth { get; set; } = Depth;
}