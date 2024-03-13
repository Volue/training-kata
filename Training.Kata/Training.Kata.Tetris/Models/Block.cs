namespace Training.Kata.Tetris.Models;

public class Block
{
    public int X { get; set; }
    public int Y { get; set; }

    public Block(int x, int y)
    {
        X = x;
        Y = y;
    }

    public Block Clone() => new(X, Y);
}