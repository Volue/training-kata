using Spectre.Console;

namespace Training.Kata.Snake;

public class GameEngine
{
    private CollisionChecker _collisionChecker;
    private Canvas _canvas;
    private Snake _snake;

    public GameEngine(Canvas canvas, Snake snake, CollisionChecker collisionChecker)
    {
        _snake = snake;
        _canvas = canvas;
        _collisionChecker = collisionChecker;
    }

    public bool HasSnakeDied(int nextX, int nextY)
    {
        var collisionType = _collisionChecker.Check(nextX, nextY);
        return collisionType is CollisionType.Border or CollisionType.Snake;
    }

    public void Draw()
    {
        Console.Clear();
        AnsiConsole.Write(_canvas);
    }

    public void Update(SnakeDirection snakeDirection)
    {
        var head = _snake.GetHead();
        var nextX = head.X;
        var nextY = head.Y;
        switch (snakeDirection)
        {
            case SnakeDirection.Up:
                nextY = head.Y - 1;
                break;
            case SnakeDirection.Down:
                nextY = head.Y + 1;
                break;
            case SnakeDirection.Left:
                nextX = head.X - 1;
                break;
            case SnakeDirection.Right:
                nextX = head.X + 1;
                break;
            case SnakeDirection.None:
                Draw();
                return;
        }
    
        var hasSnakeDied = HasSnakeDied(nextX, nextY);
        if (hasSnakeDied)
        {
            Environment.Exit(0);
        }
        _snake.Update(nextX, nextY);
        Draw();
    }
}