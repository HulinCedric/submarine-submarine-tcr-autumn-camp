namespace SubmarineTcrKata.Domain;

public class Submarine : ISubmarine
{
    private int position = 0;
    private int aim;

    public void ExecuteCommand(string command)
    {
        aim = -1;
    }

    public int Aim => aim;
    public int Position => position;
    public int Depth => 0;
}