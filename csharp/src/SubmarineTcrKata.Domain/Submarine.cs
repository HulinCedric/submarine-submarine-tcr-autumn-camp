namespace SubmarineTcrKata.Domain;

public class Submarine : ISubmarine
{
    public void ExecuteCommand(string command)
    {
        var commandName = command.Split(" ")[0];
        var commandValue = command.Split(" ")[1];
        if (commandName == "forward")
            Position = Convert.ToInt32(commandValue);
        else if (command == "up 1")
            Aim = -1;
        else if (command == "down 5")
            Aim = 5;
    }

    public int Aim { get; private set; }

    public int Position { get; private set; }

    public int Depth
        => 0;
}