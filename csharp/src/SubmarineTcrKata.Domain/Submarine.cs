namespace SubmarineTcrKata.Domain;

public class Submarine : ISubmarine
{
    public void ExecuteCommand(string command)
    {
        switch (command)
        {
            case "forward 5":
                Position = 5;
                break;
            case "up 1":
                Aim = -1;
                break;
            case "down 5":
                Aim = 5;
                break;
        }
    }

    public int Aim { get; private set; }

    public int Position { get; private set; }

    public int Depth
        => 0;
}