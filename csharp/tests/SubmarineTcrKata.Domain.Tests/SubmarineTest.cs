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
    public void SubmarineShouldBeAtInitialStartingLocation()
    {
        _submarine.Position.Should().Be(0);
        _submarine.Aim.Should().Be(0);
        _submarine.Depth.Should().Be(0);
    }
    
    [Theory]
    [InlineData(5)]
    [InlineData(8)]
    [InlineData(10)]
    public void MoveForward(int commandValue)
    {
        _submarine.ExecuteCommand($"forward {commandValue}");
        
        _submarine.Position.Should().Be(commandValue);
        _submarine.Aim.Should().Be(0);
        _submarine.Depth.Should().Be(0);
    }
   
    
    [Fact]
    public void MoveUp()
    {
        _submarine.ExecuteCommand("up 1");
        
        _submarine.Position.Should().Be(0);
        _submarine.Aim.Should().Be(-1);
        _submarine.Depth.Should().Be(0);
    }
    
    [Fact]
    public void MoveForwardAndDown()
    {
        // Arrange
        _submarine.ExecuteCommand("forward 5");
        
        // Act
        _submarine.ExecuteCommand("down 5");

        // Assert
        _submarine.Position.Should().Be(5);
        _submarine.Aim.Should().Be(5);
        _submarine.Depth.Should().Be(0);
    }
}