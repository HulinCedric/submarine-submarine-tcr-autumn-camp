using FluentAssertions;
using Xunit;

namespace SubmarineTcrKata.Domain.Tests;

public class SubmarineShould
{
    private readonly Submarine _submarine;

    public SubmarineShould()
        => _submarine = new Submarine();

    [Fact]
    public void Be_at_default_position()
    {
        VerifyStatus(_submarine);
    }

    public static void VerifyStatus(ISubmarine submarine)
    {
        submarine.Position.Should().Be(0);
        submarine.Aim.Should().Be(0);
        submarine.Depth.Should().Be(0);
    }

    [Fact]
    public void Move_on_with_forward_command()
    {
        _submarine.ExecuteCommand("forward 5");
        
        _submarine.Position.Should().Be(5);
        _submarine.Aim.Should().Be(0);
        _submarine.Depth.Should().Be(0);
    }
    
    [Fact]
    public void Move_on_aim_with_down_command()
    {
        _submarine.ExecuteCommand("forward 5");
        _submarine.ExecuteCommand("down 5");
        
        _submarine.Position.Should().Be(5);
        _submarine.Aim.Should().Be(5);
        _submarine.Depth.Should().Be(0);
    }
}