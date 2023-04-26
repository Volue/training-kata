namespace Training.Kata.Minesweeper.Api.Models;

public class Field
{
    public int X;
    public int Y;
    public bool IsVisible;
    public bool IsMarked;
    public bool IsBomb;
    public int BombedNeighbours;

    public override string ToString()
    {
        return $"{X},{Y}";
    }
}