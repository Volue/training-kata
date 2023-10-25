using Spectre.Console;

namespace Training.Kata.Tetris;

public abstract class AbstractShape
{
    public readonly Guid Id = Guid.NewGuid();
    public List<Block> Blocks { get; set; }
    protected Canvas _canvas;
    
    public AbstractShape(Canvas canvas)
    {
        _canvas = canvas;
    }
    
    public abstract void Rotate(Rotation rotation);

    public void Erase()
    {
        Blocks.ForEach(block => _canvas.SetPixel(block.X, block.Y, Color.Black));
    }

    public void Draw()
    {
        Blocks.ForEach(block => _canvas.SetPixel(block.X, block.Y, Color.Aquamarine3));
    }

    public IEnumerable<Block> GetNextPosition(MoveDirection moveDirection)
    {
        var nextPosition = new List<Block>();
        if (moveDirection == MoveDirection.Down)
        {
            Blocks.ForEach(block =>
            {
                nextPosition.Add(new Block(block.X, block.Y + 1));
            });
        }
        
        if (moveDirection == MoveDirection.Left)
        {
            Blocks.ForEach(block =>
            {
                nextPosition.Add(new Block(block.X -1, block.Y));
            });
        }
        
        if (moveDirection == MoveDirection.Right)
        {
            Blocks.ForEach(block =>
            {
                nextPosition.Add(new Block(block.X + 1, block.Y));
            });
        }

        return nextPosition;
    }
    
    public void Move(MoveDirection moveDirection)
    {
        Blocks.Clear();
        Blocks.AddRange(GetNextPosition(moveDirection));
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
    
    public override void Rotate(Rotation rotation)
    {
        
    }
}

