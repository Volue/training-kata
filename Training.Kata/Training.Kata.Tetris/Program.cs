using Training.Kata.ConsoleGui;
using Training.Kata.Tetris;
using Timer = System.Timers.Timer;

var canvas = new Canvas();
var rectangle = new Rectangle(12, 22, canvas);
var oShape = new OShape(new Block(3, 3), canvas);
var allShapes = new List<AbstractShape>() {oShape};

var timer = new Timer(1000);
 timer.Elapsed += (sender, eventArgs) =>
{
    rectangle.Draw();
    oShape.Erase();
    oShape.Move(MoveDirection.Down);
    oShape.Draw();
    canvas.Redraw();
};

ConsoleKey key = ConsoleKey.NoName;
timer.Start();
while (key != ConsoleKey.Q)
{
    key = Console.ReadKey().Key;
}