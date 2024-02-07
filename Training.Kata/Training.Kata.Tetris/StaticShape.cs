using Training.Kata.ConsoleGui;

namespace Training.Kata.Tetris;

public class StaticShape : AbstractShape
{
    public StaticShape(Canvas canvas, List<Block> blocks) : base(canvas)
    {
        Blocks = blocks;
    }

    public override void Rotate(Rotation rotation)
    {
    }
}