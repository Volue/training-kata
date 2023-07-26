namespace Training.Kata.Snake;

public class InputController
{
    public SnakeDirection LastDirection;

    public SnakeDirection ReadInput(ConsoleKey newDirection)
    {
        switch (newDirection)
        {
            case ConsoleKey.UpArrow:
                return LastDirection == SnakeDirection.Down
                    ? LastDirection
                    : SnakeDirection.Up;
            case ConsoleKey.DownArrow:
                return LastDirection == SnakeDirection.Up
                    ? LastDirection
                    : SnakeDirection.Down;
            case ConsoleKey.LeftArrow:
                return LastDirection == SnakeDirection.Right
                    ? LastDirection
                    : SnakeDirection.Left;
            case ConsoleKey.RightArrow:
                return LastDirection == SnakeDirection.Left
                    ? LastDirection
                    : SnakeDirection.Right;
            default:
                return SnakeDirection.None;
        }
    }
}