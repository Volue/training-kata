using Training.Kata.ConsoleGui;
using Training.Kata.Tetris.Abstract;
using Training.Kata.Tetris.Enums;
using Training.Kata.Tetris.Models;

namespace Training.Kata.Tetris.Shapes;

public class LShape : AbstractShape
{
    private Orientation _orientation;
    
    //     #
    // # # #
    
    public LShape(Block topLeftBlock, Canvas canvas) : base(canvas, ConsoleColor.Magenta)
    {
        Blocks = new List<Block>();
        Blocks.Add(topLeftBlock);
        Blocks.Add(new Block(topLeftBlock.X + 1, topLeftBlock.Y));
        Blocks.Add(new Block(topLeftBlock.X + 2, topLeftBlock.Y));
        Blocks.Add(new Block(topLeftBlock.X + 2, topLeftBlock.Y - 1));
        _orientation = Orientation.Left;
    }

    //  left    up    right
    //          xy
    //     y    #
    // x # #    # #   xy # #    xy # 
    //                #            #
    //                             #
    
    public override IEnumerable<Block> GetRotation()
    {
        var minX = Blocks.Min(b => b.X);
        var minY = Blocks.Min(b => b.Y);
        return _orientation switch
        {
            Orientation.Up => new List<Block>
            {
                new(minX, minY + 2),
                new(minX + 1, minY + 2),
                new(minX + 2, minY + 2),
                new(minX, minY + 3),
            },
            Orientation.Right => new List<Block>
            {
                new(minX, minY),
                new(minX + 1, minY),
                new(minX + 1, minY + 1),
                new(minX + 1, minY + 2),
            },
            Orientation.Down => new List<Block>
            {
                new(minX - 1, minY),
                new(minX, minY),
                new(minX + 1, minY),
                new(minX + 1, minY - 1),
            },
            Orientation.Left => new List<Block>
            {
                new(minX + 1, minY - 1),
                new(minX + 1, minY),
                new(minX + 1, minY + 1),
                new(minX + 2, minY + 1),
            },
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    public override void Rotate()
    {
        Blocks = GetRotation().ToList();
        _orientation = _orientation switch
        {
            Orientation.Up => Orientation.Right,
            Orientation.Right => Orientation.Down,
            Orientation.Down => Orientation.Left,
            Orientation.Left => Orientation.Up,
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}