using Spectre.Console;

namespace Training.Kata.Snake;

public class GameEngine
{
    private CollisionChecker _collisionChecker;
    private Canvas _canvas;
    private Snake _snake;
    private Food _food;
    private Random _random = new Random();

    public GameEngine(Canvas canvas, Snake snake, Food food, CollisionChecker collisionChecker)
    {
        _snake = snake;
        _canvas = canvas;
        _food = food;
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
            var newSegment = new SnakeSegment
            {
                X = lastSnakeSegment.X,
                Y = lastSnakeSegment.Y,
                Number = lastSnakeSegment.Number + 1
            };
            _snake.Update(nextX, nextY);
            _snake.Body.Add(newSegment);
            _snake.Draw();
            
            GenerateNewFoodXY();
            _food.Draw();
        }

        if (collisionType == CollisionType.None)
        {
            _snake.Update(nextX, nextY);
        }
        
        Draw();
    }

    private void GenerateNewFoodXY()
    {
        var foodPlacementFound = false;
        while (foodPlacementFound == false)
        {
            var foodX = _random.Next(1, 18);
            var foodY = _random.Next(1, 18);
            var check = _collisionChecker.Check(foodX, foodY);
            if (check == CollisionType.None)
            {
                _food.X = foodX;
                _food.Y = foodY;
                foodPlacementFound = true;
            }    
        }
    }
}