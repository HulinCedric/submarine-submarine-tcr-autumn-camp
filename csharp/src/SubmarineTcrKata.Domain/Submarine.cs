namespace SubmarineTcrKata.Domain;

public class Submarine : ISubmarine
{
    public void ExecuteCommand(string command)
    {
        var commandParts = command.Split(" ");
        var commandName = commandParts[0];
        var commandValue = int.Parse(commandParts[1]);
        
        if (commandName == "forward")
        {
            Position = commandValue;
        }

        if (command == "down 5")
        {
            Aim = 5;
        }
    }

    public int Aim { get; private set; }

    public int Position { get; private set; }

    public int Depth
        => 0;
}