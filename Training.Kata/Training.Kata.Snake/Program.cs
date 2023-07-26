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

var inputController = new InputController();
var gameEngine = new GameEngine(canvas, snake, collisionChecker);

ConsoleKey key = ConsoleKey.NoName;
timer.Elapsed += (sender, eventArgs) =>
{
    var snakeDirection = inputController.ReadInput(key);
    gameEngine.Update(snakeDirection);
    inputController.LastDirection = snakeDirection;
};

timer.Start();
while (key != ConsoleKey.Q)
{
    key = Console.ReadKey().Key;
}