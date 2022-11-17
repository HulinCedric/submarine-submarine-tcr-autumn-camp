namespace SubmarineTcrKata.Domain;

public class Submarine : ISubmarine
{
    private int position = 0;
    
    public void ExecuteCommand(string command)
    {
        position += 1;
    }

    public int Aim => 0;
    public int Position => position;
    public int Depth => throw new NotImplementedException();
}