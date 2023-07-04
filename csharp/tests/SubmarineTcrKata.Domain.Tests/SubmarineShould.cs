using FluentAssertions;
using Xunit;

namespace SubmarineTcrKata.Domain.Tests;

public static class SubmarineVerificationExtensions
{
    public static void StatusShouldBe(this ISubmarine submarine, int position, int aim, int depth)
    {
        submarine.Position.Should().Be(position);
        submarine.Aim.Should().Be(aim);
        submarine.Depth.Should().Be(depth);
    }
}

public class SubmarineShould
{
    private readonly Submarine _submarine;

    public SubmarineShould()
        => _submarine = new Submarine();

    [Fact]
    public void Be_at_default_position()
        => _submarine.StatusShouldBe(0, 0, 0);


    [Theory]
    [InlineData("forward 5",5)]
    [InlineData("forward 8",8)]
    public void Move_on_with_forward_command(string command, int expectedPosition)
    {
        _submarine.ExecuteCommand(command);

        _submarine.StatusShouldBe(expectedPosition, 0, 0);
    }

    [Fact]
    public void Move_on_aim_with_down_command()
    {
        _submarine.ExecuteCommand("forward 5");
        _submarine.ExecuteCommand("down 5");

        _submarine.StatusShouldBe(5, 5, 0);

    }
}