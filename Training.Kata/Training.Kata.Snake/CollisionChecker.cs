namespace Training.Kata.Snake;

public class CollisionChecker
{
    private readonly Snake _snake;
    private readonly Food _food;
    private readonly Wall _wall;

    public CollisionChecker(Snake snake, Food food, Wall wall)
    {
        _snake = snake;
        _food = food;
        _wall = wall;
    }

    public CollisionType Check(int newX, int newY)
    {
        if (_food.X == newX & _food.Y == newY)
        {
            return CollisionType.Food;
        }

        if (_snake.Body.Any(snakeSegment => snakeSegment.X == newX & snakeSegment.Y == newY))
        {
            return CollisionType.Snake;
        }

        if (_wall.Position.Any(segment => segment.X == newX & segment.Y == newY))
        {
            return CollisionType.Wall;
        }

        return CollisionType.None;
    }
}