// See https://aka.ms/new-console-template for more information

using Spectre.Console;
using Training.Kata.Snake;
using Timer = System.Timers.Timer;


var canvas = new Canvas(20, 20);

for (var i = 0; i < 20; i++)
{
    canvas.SetPixel(i, 0, Color.White);
    canvas.SetPixel(i, 19, Color.White);
    canvas.SetPixel(0, i, Color.White);
    canvas.SetPixel(19, i, Color.White);
}

var snake = new Snake(canvas, new List<SnakeSegment>
{
    new SnakeSegment
    {
        X = 5,
        Y = 5,
        Number = 0
    },
    new SnakeSegment
    {
        X = 4,
        Y = 5,
        Number = 1
    },
    new SnakeSegment
    {
        X = 3,
        Y = 5,
        Number = 2
    },
    new SnakeSegment
    {
        X = 2,
        Y = 5,
        Number = 3
    },
    new SnakeSegment
    {
        X = 1,
        Y = 5,
        Number = 4
    }
});

snake.Draw(Color.Pink1);

var food = new Food(13, 4, canvas);
food.Draw();

var collisionChecker = new CollisionChecker(snake, food);

var timer = new Timer(TimeSpan.FromSeconds(1));

ConsoleKey key = ConsoleKey.NoName;
timer.Elapsed += (sender, eventArgs) =>
{
    var head = snake.GetHead();
    var collisionType = CollisionType.None;
    switch (key)
    {
        case ConsoleKey.UpArrow:
            collisionType = collisionChecker.Check(head.X, head.Y - 1);
            if (collisionType == CollisionType.Snake)
            {
                Environment.Exit(0);
            }
            snake.Update(head.X, head.Y - 1);
            break;
        case ConsoleKey.DownArrow:
            collisionType = collisionChecker.Check(head.X, head.Y + 1);
            if (collisionType == CollisionType.Snake)
            {
                Environment.Exit(0);
            }
            snake.Update(head.X, head.Y + 1);
            break;
        case ConsoleKey.LeftArrow:
            collisionType = collisionChecker.Check(head.X - 1, head.Y);
            if (collisionType == CollisionType.Snake)
            {
                Environment.Exit(0);
            }
            snake.Update(head.X - 1, head.Y);
            break;
        case ConsoleKey.RightArrow:
            collisionType = collisionChecker.Check(head.X + 1, head.Y);
            if (collisionType == CollisionType.Snake)
            {
                Environment.Exit(0);
            }
            snake.Update(head.X + 1, head.Y);
            break;
    }

    Console.Clear();
    AnsiConsole.Write(canvas);
};

timer.Start();

while (key != ConsoleKey.Q)
{
    key = Console.ReadKey().Key;
}