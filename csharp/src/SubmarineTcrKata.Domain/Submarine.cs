namespace SubmarineTcrKata.Domain;

public record Submarine : ISubmarine
{
    
    public Submarine(): this(0,0,0)
    {
    }

    public Submarine(int depth, int position, int aim)
    {
        Depth = depth;
        Position = position;
        Aim = aim;
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

    public int Aim { get; set; }

    public int Position { get; set; }

    public int Depth { get; set; }
}