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
        
        _submarine.Position.Should().Be(0);
        _submarine.Aim.Should().Be(0);
        _submarine.Depth.Should().Be(0);
    }
}