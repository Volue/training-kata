using Training.Kata.ConsoleGui;
using Training.Kata.Tetris;
using Timer = System.Timers.Timer;

var canvas = new Canvas();
var rectangle = new Rectangle(12, 22, canvas);
AbstractShape currentShape = new OShape(new Block(3, 3), canvas);
var allBlacks = new List<IHaveBlocks>() {rectangle};
var collider = new Collider();

var timer = new Timer(250);
timer.Elapsed += (sender, eventArgs) =>
{
    rectangle.Draw();
    currentShape.Erase();
    var nextPosition = currentShape.GetNextPosition(MoveDirection.Down).ToList();
    var doesItCollide = collider.DoesItCollide(nextPosition, allBlacks);
    if (!doesItCollide)
    {
        currentShape.Move(MoveDirection.Down);
    }
    else
    {
        var clonedBlocksFromCurrentShape = currentShape.Blocks.Select(x => x.Clone());
        var clonedBlocksList = clonedBlocksFromCurrentShape.ToList();
        var staticShapeFromCurrentShape = new StaticShape(canvas, clonedBlocksList);
        allBlacks.Add(staticShapeFromCurrentShape);
        currentShape = new OShape(new Block(3, 3), canvas);
    }
    
    currentShape.Draw();
    allBlacks.ForEach(x => x.Draw());
    canvas.Redraw();
};

ConsoleKey key = ConsoleKey.NoName;
timer.Start();
var moveDirection = MoveDirection.None;
while (key != ConsoleKey.Q)
{
    key = Console.ReadKey().Key;

    moveDirection = key switch
    {
        ConsoleKey.RightArrow => MoveDirection.Right,
        ConsoleKey.LeftArrow => MoveDirection.Left,
        ConsoleKey.DownArrow => MoveDirection.Down,
        _ => moveDirection
    };

    if (moveDirection != MoveDirection.None)
    {
        var nextPosition = currentShape.GetNextPosition(moveDirection).ToList();
        if (!collider.DoesItCollide(nextPosition, allBlacks))
        {
            currentShape.Erase();
            currentShape.Move(moveDirection);
            currentShape.Draw();
        }
        moveDirection = MoveDirection.None;
    }
}