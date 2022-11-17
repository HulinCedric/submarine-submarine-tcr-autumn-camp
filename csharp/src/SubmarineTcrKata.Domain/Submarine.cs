namespace SubmarineTcrKata.Domain;

public class Submarine : ISubmarine
{
    public void ExecuteCommand(string command)
    {
    }

    public int Aim => throw new NotImplementedException();
    public int Position => 0;
    public int Depth => throw new NotImplementedException();
}