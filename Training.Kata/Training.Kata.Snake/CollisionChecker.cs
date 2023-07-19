namespace Training.Kata.Snake;

public class CollisionChecker
{
    private readonly Snake _snake;
    private readonly Food _food;

    public CollisionChecker(Snake snake, Food food)
    {
        _snake = snake;
        _food = food;
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

        return CollisionType.None;
    }
}