namespace SubmarineTcrKata.Domain;

public class Submarine : ISubmarine
{
    public void ExecuteCommand(string command)
    {
        if (command == "forward 5")
            Position = 5;
    }

    public int Aim => 0;
    public int Position { get; private set; } = 0;
    public int Depth => 0;
}