namespace Training.Kata.Snake;

public class SnakeSegment
{
    public int X;
    public int Y;
    public int Number;

    public SnakeSegment Copy()
    {
        return new SnakeSegment
        {
            X = X,
            Y = Y,
            Number = Number
        };
    }
}