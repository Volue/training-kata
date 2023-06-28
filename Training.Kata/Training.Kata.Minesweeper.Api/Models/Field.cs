namespace Training.Kata.Minesweeper.Api.Models;

public class Field
{
    public int X;
    public int Y;
    public bool IsVisible;
    public bool IsMarked;
    public bool IsBomb;
    public int BombedNeighbours;
    public bool ShowVictory;

    public override string ToString()
    {
        if (ShowVictory)
        {
            return "[🏆]";
        }
        
        if (IsMarked) //3
        {
            return "[🚩]";
        }
        
        if (!IsVisible) //1
        {
            return "[ ]";
        }

        if (IsBomb) //2
        {
            return "[☠]";
        }

        if (BombedNeighbours > 0)
        {
            return $"[{BombedNeighbours}]";
        }
        
        return "[_]";
    }
}