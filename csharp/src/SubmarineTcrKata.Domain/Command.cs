namespace SubmarineTcrKata.Domain;

public record Command(string Name, int Value)
{
    public static Command New(string commandDescription)
    {
        var commandParts = commandDescription.Split(" ");
        
        var commandName = commandParts[0];
        var commandValue = int.Parse(commandParts[1]);
        
        return new Command(commandName, commandValue);
    }

    public void ExecuteCommand(Submarine submarine)
    {
        switch (Name)
        {
            case "forward":
                submarine.MoveForward(Value);
                break;

            case "down":
                submarine.MoveDown(Value);
                break;

            case "up":
                submarine.MoveUp(Value);
                break;
        }
    }
}