namespace SubmarineTcrKata.Domain;

public class Submarine : ISubmarine
{
    private int position = 0;
    
    public void ExecuteCommand(string command)
    {
        position += 1;
    }

    public int Aim => throw new NotImplementedException();
    public int Position => position;
    public int Depth => throw new NotImplementedException();
}