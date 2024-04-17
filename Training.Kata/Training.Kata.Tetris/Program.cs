using Training.Kata.ConsoleGui;
using Training.Kata.Tetris;
using Training.Kata.Tetris.Abstract;
using Training.Kata.Tetris.Enums;
using Training.Kata.Tetris.Factories;
using Training.Kata.Tetris.Models;
using Training.Kata.Tetris.Shapes;
using Timer = System.Timers.Timer;

var canvas = new Canvas();
var rectangle = new Rectangle(12, 22, canvas);
var shapeFactory = new ShapeFactory(canvas);
AbstractShape currentShape = shapeFactory.CreateRandom();
var allBlacks = new List<IHaveBlocks>() {rectangle};
var collider = new Collider();

var timer = new Timer(500);
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
        var staticShapeFromCurrentShape = new StaticShape(canvas, clonedBlocksList, currentShape.Color);
        allBlacks.Add(staticShapeFromCurrentShape);
        currentShape = shapeFactory.CreateRandom();
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

    if (key == ConsoleKey.Spacebar)
    {
        var nextPosition = currentShape.GetRotation().ToList();
        if (!collider.DoesItCollide(nextPosition, allBlacks))
        {
            currentShape.Erase();
            currentShape.Rotate();
            currentShape.Draw();
        }
        continue;
    }

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