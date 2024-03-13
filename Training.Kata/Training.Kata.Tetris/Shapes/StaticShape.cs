using Training.Kata.ConsoleGui;
using Training.Kata.Tetris.Abstract;
using Training.Kata.Tetris.Enums;
using Training.Kata.Tetris.Models;

namespace Training.Kata.Tetris.Shapes;

public class StaticShape : AbstractShape
{
    public StaticShape(Canvas canvas, List<Block> blocks, ConsoleColor color) : base(canvas, color)
    {
        Blocks = blocks;
    }
    
    public override IEnumerable<Block> GetRotation()
    {
        return new List<Block>();
    }
    
    public override void Rotate()
    {
    }
}