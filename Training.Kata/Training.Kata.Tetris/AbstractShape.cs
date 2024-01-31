using Training.Kata.ConsoleGui;

namespace Training.Kata.Tetris;

public abstract class AbstractShape : IHaveBlocks
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
        Blocks.ForEach(block => _canvas.SetCell(block.X, block.Y, ConsoleColor.Black));
    }

    public void Draw()
    {
        Blocks.ForEach(block => _canvas.SetCell(block.X, block.Y, ConsoleColor.Cyan));
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
        var nextPosition = GetNextPosition(moveDirection);
        Blocks.Clear();
        Blocks.AddRange(nextPosition);
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

    private OShape(List<Block> blocks, Canvas canvas) : base(canvas)
    {
        Blocks = blocks;
    }

    public OShape Clone()
    {
        return new OShape(Blocks.Select(block => block.Clone()).ToList(), _canvas);
    }
    
    public override void Rotate(Rotation rotation)
    {
        
    }
}

