using System.Reflection;
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
var allBlocks = new List<IHaveBlocks>() {rectangle};
var collider = new Collider();

var timer = new Timer(500);
timer.Elapsed += (sender, eventArgs) =>
{
    rectangle.Draw();
    currentShape.Erase();
    var nextPosition = currentShape.GetNextPosition(MoveDirection.Down).ToList();
    var doesItCollide = collider.DoesItCollide(nextPosition, allBlocks);
    if (!doesItCollide)
    {
        currentShape.Move(MoveDirection.Down);
    }
    else
    {
        var clonedBlocksList = currentShape.Blocks.Select(x => x.Clone()).ToList();
        allBlocks.Add(new StaticShape(canvas, clonedBlocksList, currentShape.Color));
        
        // Usuń linię??
        var fullRows = allBlocks.SelectMany(x => x.Blocks)
            .Where(b => b.Y != 0 & b.Y != 22)
            .Where(b => b.X != 0 & b.X != 12)
            .GroupBy(x => x.Y)
            .Select(x => (x.Key, x.Count() >= 11))
            .Where<(int row, bool isFull)>(x => x.isFull)
            .ToList();

        if (fullRows.Any())
        {
            foreach (var row in fullRows)
            {
                allBlocks.ForEach(b =>
                {
                    var blocksToRemove = b.Blocks.Where(bb => bb.Y == row.row & bb.X != 0 & bb.X != 12).ToList();
                    blocksToRemove.ForEach(bb =>
                    {
                        b.Erase();
                        b.Blocks.Remove(bb);
                    });
                });
            }

            var highiestRowToDelete = fullRows.Min(x => x.row);
            allBlocks.ForEach(b =>
            {
                // START HERE
                
                var blocksToMove = b.Blocks.Where(bb => bb.Y < highiestRowToDelete).ToList();
                blocksToMove.ForEach(bb =>
                {
                    
                });
            });
        }

        currentShape = shapeFactory.CreateRandom();
    }
    
    currentShape.Draw();
    allBlocks.ForEach(x => x.Draw());
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
        if (!collider.DoesItCollide(nextPosition, allBlocks))
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
        if (!collider.DoesItCollide(nextPosition, allBlocks))
        {
            currentShape.Erase();
            currentShape.Move(moveDirection);
            currentShape.Draw();
        }
        moveDirection = MoveDirection.None;
    }
}