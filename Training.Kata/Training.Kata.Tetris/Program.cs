using Training.Kata.ConsoleGui;
using Training.Kata.Tetris;
using Timer = System.Timers.Timer;

var canvas = new Canvas();
var rectangle = new Rectangle(12, 22, canvas);
var oShape = new OShape(new Block(3, 3), canvas);
var allBlacks = new List<IHaveBlocks>() {rectangle};
var collider = new Collider();

var timer = new Timer(250);
timer.Elapsed += (sender, eventArgs) =>
{
    rectangle.Draw();
    oShape.Erase();
    var nextPosition = oShape.GetNextPosition(MoveDirection.Down).ToList();
    var doesItCollide = collider.DoesItCollide(nextPosition, allBlacks);
    if (!doesItCollide)
    {
        oShape.Move(MoveDirection.Down);    
    }
    else
    {
        allBlacks.Add(oShape.Clone());
        oShape = new OShape(new Block(3, 3), canvas);
        // TODO: Make allBlacks visible
    }
    
    oShape.Draw();
    canvas.Redraw();
};

ConsoleKey key = ConsoleKey.NoName;
timer.Start();
while (key != ConsoleKey.Q)
{
    key = Console.ReadKey().Key;
}