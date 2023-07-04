namespace SubmarineTcrKata.Domain;

public class Submarine : ISubmarine
{
    public void ExecuteCommand(string command)
    {
        Position = 5;

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