namespace SubmarineTcrKata.Domain.Tests;

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