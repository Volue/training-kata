using Training.Kata.Minesweeper.Api.Models;

namespace Training.Kata.Minesweeper.Api.Services;

public class GameService
{
    public bool WasFirstMoveMade;
    public List<Field> GameBoard = new();
    public Random Random = new Random();

    public GameService()
    {
        foreach (var i in Enumerable.Range(0, 5))
        {
            foreach (var j in Enumerable.Range(0, 5))
            {
                GameBoard.Add(new Field
                {
                    X = i,
                    Y = j
                });
            }
        }
    }

    public void MakeMove(int x, int y)
    {
        if (!WasFirstMoveMade)
        {
            MakeFirstMove(x, y);
        }
    }

    private void MakeFirstMove(int x, int y)
    {
        GameBoard.Single(field => field.X == x & field.Y == y).IsVisible = true;
        while (GameBoard.Where(field => field.IsBomb).Count() < 6)
        {
            PlaceBomb(Random.Next(0, 4), Random.Next(0, 4));
        }
        
        foreach (var bombField in GameBoard.Where(field => field.IsBomb))
        {
            // TU SKONCZYLISMY OSTATNIO
        }
        
        WasFirstMoveMade = true;
    }

    private void PlaceBomb(int x, int y)
    {
        var field = GameBoard.Single(field => field.X == x & field.Y == y);
        if (!field.IsVisible)
        {
            field.IsBomb = true;
            field.IsVisible = true; // TYMCZASOWE
        }
    }
}