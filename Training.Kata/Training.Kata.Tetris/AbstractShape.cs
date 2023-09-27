using Spectre.Console;

namespace Training.Kata.Tetris;

public abstract class AbstractShape
{
    public List<Block> Blocks { get; set; }
    protected Canvas _canvas;
    
    public AbstractShape(Canvas canvas)
    {
        _canvas = canvas;
    }
    
    public abstract void Move(MoveDirection moveDirection);
    public abstract void Rotate(Rotation rotation);

    public void Draw()
    {
        Blocks.ForEach(block => _canvas.SetPixel(block.X, block.Y, Color.Aquamarine3));
    }
}

public class OShape : AbstractShape
{
    public OShape(Block topLeftBlock, Canvas canvas) : base(canvas)
    {
        Blocks = new List<Block>();
        Blocks.Add(topLeftBlock);
        Blocks.Add(new Block(topLeftBlock.X + 1, topLeftBlock.Y));
        Blocks.Add(new Block(topLeftBlock.X, topLeftBlock.Y + 1));
        Blocks.Add(new Block(topLeftBlock.X + 1, topLeftBlock.Y + 1));
    }
    
    public override void Move(MoveDirection moveDirection)
    {
        if (moveDirection == MoveDirection.Down)
        {
            Blocks.ForEach(block =>
            {
                block.Y += 1;
            });
        }
        
        if (moveDirection == MoveDirection.Left)
        {
            Blocks.ForEach(block =>
            {
                block.X -= 1;
            });
        }
        
        if (moveDirection == MoveDirection.Right)
        {
            Blocks.ForEach(block =>
            {
                block.X += 1;
            });
        }
    }

    public override void Rotate(Rotation rotation)
    {
        
    }
}

