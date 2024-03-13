using Training.Kata.ConsoleGui;
using Training.Kata.Tetris.Abstract;
using Training.Kata.Tetris.Enums;
using Training.Kata.Tetris.Models;

namespace Training.Kata.Tetris.Shapes;

public class IShape : AbstractShape
{
    private Orientation _orientation;
    
    public IShape(Block topLeftBlock, Canvas canvas) : base(canvas, ConsoleColor.Green)
    {
        Blocks = new List<Block>();
        Blocks.Add(topLeftBlock);
        Blocks.Add(new Block(topLeftBlock.X + 1, topLeftBlock.Y));
        Blocks.Add(new Block(topLeftBlock.X + 2, topLeftBlock.Y));
        Blocks.Add(new Block(topLeftBlock.X + 3, topLeftBlock.Y));
        _orientation = Orientation.Horizontal;
    }

    public override IEnumerable<Block> GetRotation()
    {
        var minX = Blocks.Min(b => b.X);
        var minY = Blocks.Min(b => b.Y);
        return _orientation switch
        {
            Orientation.Horizontal => new List<Block>
            {
                new(minX, minY), 
                new(minX, minY + 1), 
                new(minX, minY + 2), 
                new(minX, minY + 3)
            },
            Orientation.Vertical => new List<Block>
            {
                new(minX, minY), 
                new(minX + 1, minY), 
                new(minX + 2, minY), 
                new(minX + 3, minY)
            },
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    public override void Rotate()
    {
        Blocks = GetRotation().ToList();
        _orientation = _orientation switch
        {
            Orientation.Horizontal => Orientation.Vertical,
            Orientation.Vertical => Orientation.Horizontal,
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}