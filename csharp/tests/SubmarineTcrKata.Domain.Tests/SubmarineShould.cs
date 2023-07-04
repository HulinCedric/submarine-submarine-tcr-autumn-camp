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
    [Fact]
    public void Be_at_default_position()
    {
        var submarine = new Submarine();

        submarine.StatusShouldBe(0, 0, 0);
    }

    [Theory]
    [InlineData("forward 5", 5)]
    [InlineData("forward 8", 8)]
    public void Move_on_with_forward_command(string command, int expectedPosition)
    {
        var submarine = new Submarine();


        submarine.ExecuteCommand(command);

        submarine.StatusShouldBe(expectedPosition, 0, 0);
    }


    [Fact]
    public void Move_on_aim_with_down_command()
    {
        var submarine = new Submarine();

        submarine.ExecuteCommand("down 5");

        submarine.StatusShouldBe(0, 5, 0);
    }

    [Fact]
    public void Move_on_depth_depending_on_aim_with_forward_command()
    {
        var submarine = new Submarine();

        submarine.ExecuteCommand("forward 5");
        submarine.ExecuteCommand("down 5");
        submarine.ExecuteCommand("forward 8");

        submarine.StatusShouldBe(13, 5, 40);
    }
}