namespace SubmarineTcrKata.Domain;

public record Submarine : ISubmarine
{

    
    public Submarine(int aim = 0, int position = 0, int depth = 0)
    {
        Aim = aim;
        Position = position;
        Depth = depth;
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

    public int Aim { get; set; } = 0;

    public int Position { get; set; } = 0;

    public int Depth { get; set; } = 0;
}