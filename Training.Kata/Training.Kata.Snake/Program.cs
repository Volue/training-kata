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
    }
});

snake.Draw(Color.Pink1);

canvas.SetPixel(13, 4, Color.Green);

var timer = new Timer(TimeSpan.FromSeconds(1));

ConsoleKey key = ConsoleKey.NoName;
timer.Elapsed += (sender, eventArgs) =>
{
    var head = snake.GetHead();
    switch (key)
    {
        case ConsoleKey.UpArrow:
            snake.Update(head.X, head.Y - 1);
            break;
        case ConsoleKey.DownArrow:
            snake.Update(head.X, head.Y + 1);
            break;
        case ConsoleKey.LeftArrow:
            snake.Update(head.X - 1, head.Y);
            break;
        case ConsoleKey.RightArrow:
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