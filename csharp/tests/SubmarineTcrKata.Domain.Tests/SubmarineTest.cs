using FluentAssertions;
using Xunit;

namespace SubmarineTcrKata.Domain.Tests;

public class SubmarineTest
{
    private readonly Submarine _submarine;

    public SubmarineTest() => _submarine = new Submarine();

    [Fact]
    public void SomeFakeTest() => _submarine.Should().NotBeNull();

    [Fact]
    public void InitialStatePosition()
    {
        _submarine.Position.Should().Be(0);
        _submarine.Depth.Should().Be(0);
        _submarine.Aim.Should().Be(0);
    }

    [Fact]
    public void TestForward()
    {
        _submarine.ExecuteCommand("forward 5");

        _submarine.Position.Should().Be(5);
        _submarine.Depth.Should().Be(0);
        _submarine.Aim.Should().Be(0);
    }
    
    [Fact]
    public void GivenForwardAndThenDownCommandShouldBeUpdatePositionAndAim()
    {
        _submarine.ExecuteCommand("forward 5");
        _submarine.ExecuteCommand("down 5");

        _submarine.Depth.Should().Be(0);
        _submarine.Position.Should().Be(5);
        _submarine.Aim.Should().Be(5);
    }

    [Fact]
    public void TestDown()
    {
        _submarine.ExecuteCommand("down 8");
        _submarine.Aim.Should().Be(8);
    }
    
    [Fact]
    public void TestDown2()
    {
        _submarine.ExecuteCommand("down 8");
        _submarine.ExecuteCommand("down 8");
        _submarine.Aim.Should().Be(16);
    }
}