using Training.Kata.ConsoleGui;

namespace Training.Kata.Tetris;

public class StaticShape : AbstractShape
{
    public StaticShape(Canvas canvas, List<Block> blocks, ConsoleColor color) : base(canvas)
    {
        Blocks = blocks;
        Color = color;
    }
    
    public override void Rotate(Rotation rotation)
    {
    }
}