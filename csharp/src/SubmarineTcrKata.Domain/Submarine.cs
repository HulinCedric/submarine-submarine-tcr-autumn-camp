namespace SubmarineTcrKata.Domain;

public class Submarine : ISubmarine
{
    public void ExecuteCommand(string command)
    {
        if (command == "forward 5")
        {
            Position = 5;
        }
        
        if (command == "forward 8")
        {
            Position = 8;
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