namespace SubmarineTcrKata.Domain;

public class Submarine : ISubmarine
{
    public void ExecuteCommand(string command)
    {
        Position = 5;
    }

    public int Aim
        => 0;

    public int Position { get; private set; }

    public int Depth
        => 0;
}