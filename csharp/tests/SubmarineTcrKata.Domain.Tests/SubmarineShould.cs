using FluentAssertions;
using Xunit;
using static SubmarineTcrKata.Domain.Tests.SubmarineTestBuilder;

namespace SubmarineTcrKata.Domain.Tests;

public class SubmarineShould
{
    [Fact]
    public void Be_at_default_position()
    {
        var submarine = Submarine().Build();

        submarine.Should().BeEquivalentTo(Submarine().WithAim(0).WithAim(0).WithDepth(0).Build());
    }

    [Theory]
    [InlineData("forward 5", 5)]
    [InlineData("forward 8", 8)]
    public void Move_X_on_position_like_ine_forward_X_command(string command, int expectedPosition)
    {
        var submarine = Submarine().Build();

        submarine.ExecuteCommand(command);

        submarine.Should().BeEquivalentTo(Submarine().WithPosition(expectedPosition).Build());
    }
    
    [Fact]
    public void Move_multiple_of_aim_and_X_on_depth_like_in_forward_X_command()
    {
        var submarine = Submarine().WithDepth(0).WithPosition(5).WithAim(5).Build();

        submarine.ExecuteCommand("forward 8");

        submarine.Should().BeEquivalentTo(Submarine().WithDepth(40).WithPosition(13).WithAim(5).Build());
    }

    [Fact]
    public void Be_equal_on_value()
    {
        var submarine = Submarine()
            .WithAim(5)
            .Build();

        var equivalentSubmarine = Submarine()
            .WithAim(5)
            .Build();

        submarine.Should().Be(equivalentSubmarine);
    }

    [Fact]
    public void Move_on_aim_with_down_command()
    {
        var submarine = Submarine().WithAim(5).Build();

        submarine.ExecuteCommand("down 5");

        submarine.Should().BeEquivalentTo(Submarine().WithAim(10).Build());
    }

   
}