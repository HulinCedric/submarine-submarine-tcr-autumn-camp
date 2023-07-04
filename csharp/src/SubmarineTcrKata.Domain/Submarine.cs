namespace SubmarineTcrKata.Domain;

public class Submarine : ISubmarine
{
    public Submarine()
    {
        Position = 0;
        Aim = 0;
        Depth = 0;
    }
    
public Submarine(int position, int aim, int depth)
    {
        Position = position;
        Aim = aim;
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

    public int Aim { get; private set; }

    public int Position { get; private set; }

    public int Depth { get; private set; }
}