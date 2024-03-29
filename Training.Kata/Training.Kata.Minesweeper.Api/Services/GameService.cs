using Training.Kata.Minesweeper.Api.Models;

namespace Training.Kata.Minesweeper.Api.Services;

public class GameService
{
    public bool WasFirstMoveMade;
    public List<Field> GameBoard = new();
    public Random Random = new Random();
    public GameStateEnum GameState;

    public GameService()
    {
        NewGame();
    }

    public void MakeMove(int x, int y)
    {
        if (!WasFirstMoveMade)
        {
            MakeFirstMove(x, y);
        }

        var field = GameBoard.Single(field => field.X == x & field.Y == y);
        if (field.IsBomb)
        {
            GameState = GameStateEnum.Lost;
            GameBoard.ForEach(field => field.IsVisible = true);
        }

        field.IsMarked = false;
        field.IsVisible = true;
        // Zatrzymaj grę po odkryciu miny!
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
            var xMax = bombField.X + 1;
            var xMin = bombField.X - 1;
            var yMax = bombField.Y + 1;
            var yMin = bombField.Y - 1;

            for (var xIndex = xMin; xIndex <= xMax; xIndex++)
            {
                for (var yIndex = yMin; yIndex <= yMax; yIndex++)
                {
                    var field = GameBoard.SingleOrDefault(boardField => boardField.X == xIndex & boardField.Y == yIndex);
                    if (field is null) continue;
                    field.BombedNeighbours++;
                }
            }
        }
        
        WasFirstMoveMade = true;
    }

    private void PlaceBomb(int x, int y)
    {
        var field = GameBoard.Single(field => field.X == x & field.Y == y);
        if (!field.IsVisible)
        {
            field.IsBomb = true;
            // field.IsVisible = true; // TYMCZASOWE
        }
    }

    public bool FlagBomb(int x, int y)
    {
        var field = GameBoard.Single(field => field.X == x & field.Y == y);
        if (field.IsVisible)
        {
            return false;
        }
        field.IsMarked = true;
        return true;
    }

    public void NewGame()
    {
        GameBoard = new List<Field>();
        GameState = GameStateEnum.InProgress;
        WasFirstMoveMade = false;
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

    public void IsGameAVictory()
    {
        var areBombsMarked = GameBoard.Where(field => field.IsBomb && field.IsMarked).Count() == 6;
        var areAllNonBombedFieldsVisible = !GameBoard.Any(field => !field.IsVisible && !field.IsBomb);
        if (areBombsMarked && areAllNonBombedFieldsVisible)
        {
            GameState = GameStateEnum.Won;
            GameBoard.Where(field => field.IsBomb).ToList().ForEach(field => field.ShowVictory = true);
        }
    }
}