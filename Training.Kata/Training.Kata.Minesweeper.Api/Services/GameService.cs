using Training.Kata.Minesweeper.Api.Models;

namespace Training.Kata.Minesweeper.Api.Services;

public class GameService
{
    public List<Field> GameBoard = new();

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
}