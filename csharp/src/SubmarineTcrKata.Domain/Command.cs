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
                MoveForward(submarine);
                break;

            case "down":
                MoveDown(submarine);
                break;

            case "up":
                MoveUp(submarine);
                break;
        }
    }

    private void MoveUp(Submarine submarine)
        => submarine.Aim -= Value;

    private void MoveDown(Submarine submarine)
        => submarine.Aim += Value;

    private void MoveForward(Submarine submarine)
    {
        submarine.Position += Value;
        submarine.Depth += submarine.Aim * Value;
    }
}