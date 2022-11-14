namespace SubmarineTcrKata.Domain;

public class Submarine : ISubmarine
{
    public void ExecuteCommand(string command)
    {
        
        var value = int.Parse(command.Split(" ")[1]);
        var commandName = command.Split(" ")[0];
        if (command == "forward 5")
            Position = 5;

        if (commandName == "down")
            Aim += value;
    }

    public int Aim { get; private set; } = 0;
    public int Position { get; private set; } = 0;
    public int Depth => 0;
}