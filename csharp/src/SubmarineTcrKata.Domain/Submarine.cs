namespace SubmarineTcrKata.Domain;

public class Submarine : ISubmarine
{
    private int position;
    private int aim;

    public void ExecuteCommand(string command)
    {
        if (command.Equals("forward 5"))
        {
            position = 5;
        }
        
        if (command.Equals("up 1"))
        {
            aim = -1;
        }
        
        if (command.Equals("down 5"))
        {
            aim = 5;
        }
    }

    public int Aim
        => aim;

    public int Position
        => position;

    public int Depth
        => 0;
}