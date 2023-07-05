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
    private int _depth;
    private int _position;
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

    public SubmarineTestBuilder WithPosition(int position)
    {
        _position = position;

        return this;
    }

    public SubmarineTestBuilder WithDepth(int depth)
    {
        _depth = depth;

        return this;
    }
}

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
        var submarine = Submarine().WithAim(5).Build();

        submarine.ExecuteCommand("down 5");

        submarine.Should().BeEquivalentTo(Submarine().WithAim(10).Build());
    }

    [Fact]
    public void Move_on_depth_depending_on_aim_with_forward_command()
    {
        var submarine = Submarine().WithDepth(0).WithPosition(5).WithAim(5).Build();

        submarine.ExecuteCommand("forward 8");

        submarine.Should().BeEquivalentTo(Submarine().WithDepth(40).WithPosition(13).WithAim(5).Build());
    }
}