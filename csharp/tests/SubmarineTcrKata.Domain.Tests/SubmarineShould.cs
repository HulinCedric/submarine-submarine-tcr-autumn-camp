using FluentAssertions;
using Xunit;
using static SubmarineTcrKata.Domain.Tests.SubmarineTestBuilder;

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

public class SubmarineTestBuilder
{
    private readonly int _depth;
    private readonly int _position;
    private int _aim;

    private SubmarineTestBuilder()
    {
        _aim = 0;
        _position = 0;
        _depth = 0;
    }

    public static SubmarineTestBuilder Submarine()
        => new();

    public Submarine Build()
        => new(_depth, _position, _aim);

    public SubmarineTestBuilder WithAim(int aim)
    {
        _aim = aim;

        return this;
    }
}

public class SubmarineShould
{
    [Fact]
    public void Be_at_default_position()
    {
        var submarine = Submarine().Build();

        submarine.StatusShouldBe(0, 0, 0);
    }

    [Theory]
    [InlineData("forward 5", 5)]
    [InlineData("forward 8", 8)]
    public void Move_on_with_forward_command(string command, int expectedPosition)
    {
        var submarine = Submarine().Build();


        submarine.ExecuteCommand(command);

        submarine.StatusShouldBe(expectedPosition, 0, 0);
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
        var submarine = Submarine()
            .WithAim(5)
            .Build();

        submarine.ExecuteCommand("down 5");

        var expectedSubmarine = Submarine().WithAim(10).Build();
        
        submarine.Should().BeEquivalentTo(expectedSubmarine);
    }

    [Fact]
    public void Move_on_depth_depending_on_aim_with_forward_command()
    {
        var submarine = Submarine().Build();

        submarine.ExecuteCommand("forward 5");
        submarine.ExecuteCommand("down 5");
        submarine.ExecuteCommand("forward 8");

        submarine.StatusShouldBe(13, 5, 40);
    }
}