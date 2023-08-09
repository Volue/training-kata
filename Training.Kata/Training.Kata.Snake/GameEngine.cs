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

    public bool HasSnakeDied(CollisionType collisionType)
    {
        return collisionType is CollisionType.Wall or CollisionType.Snake;
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
    
        var collisionType = _collisionChecker.Check(nextX, nextY);
        if (HasSnakeDied(collisionType))
        {
            Environment.Exit(0);
        }

        if (collisionType == CollisionType.Food)
        {
            var lastSnakeSegment = _snake.Body.Single(segment => segment.Number == _snake.Body.Count - 1);
            _snake.Update(nextX, nextY);
            _snake.Body.Add(new SnakeSegment
            {
                X = lastSnakeSegment.X,
                Y = lastSnakeSegment.Y,
                Number = lastSnakeSegment.Number + 1
            });
            _snake.Draw();
        }
        
        _snake.Update(nextX, nextY);
        
        Draw();
    }
}