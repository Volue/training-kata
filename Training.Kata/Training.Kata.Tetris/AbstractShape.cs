using Training.Kata.ConsoleGui;

namespace Training.Kata.Tetris;

public abstract class AbstractShape : IHaveBlocks
{
    public readonly Guid Id = Guid.NewGuid();
    public List<Block> Blocks { get; set; }
    public ConsoleColor Color;
    protected Canvas Canvas;
    
    public AbstractShape(Canvas canvas)
    {
        Canvas = canvas;
    }
    
    public abstract void Rotate(Rotation rotation);
    
    public void Erase()
    {
        Blocks.ForEach(block => Canvas.SetCell(block.X, block.Y, ConsoleColor.Black));
    }

    public void Draw()
    {
        Blocks.ForEach(block => Canvas.SetCell(block.X, block.Y, Color));
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
        Color = ConsoleColor.Cyan;
    }

    private OShape(List<Block> blocks, Canvas canvas) : base(canvas)
    {
        Blocks = blocks;
    }

    public override void Rotate(Rotation rotation)
    {
    }
}

public class IShape : AbstractShape
{
    public IShape(Block topLeftBlock, Canvas canvas) : base(canvas)
    {
        Blocks = new List<Block>();
        Blocks.Add(topLeftBlock);
        Blocks.Add(new Block(topLeftBlock.X + 1, topLeftBlock.Y));
        Blocks.Add(new Block(topLeftBlock.X + 2, topLeftBlock.Y));
        Blocks.Add(new Block(topLeftBlock.X + 3, topLeftBlock.Y));
        Color = ConsoleColor.Green;
    }

    private IShape(List<Block> blocks, Canvas canvas) : base(canvas)
    {
        Blocks = blocks;
    }
    
    public override void Rotate(Rotation rotation)
    {
    }
}

public class LShape : AbstractShape
{
    public LShape(Block topLeftBlock, Canvas canvas) : base(canvas)
    {
        Blocks = new List<Block>();
        Blocks.Add(topLeftBlock);
        Blocks.Add(new Block(topLeftBlock.X + 1, topLeftBlock.Y));
        Blocks.Add(new Block(topLeftBlock.X + 2, topLeftBlock.Y));
        Blocks.Add(new Block(topLeftBlock.X + 2, topLeftBlock.Y - 1));
        Color = ConsoleColor.Magenta;
    }

    private LShape(List<Block> blocks, Canvas canvas) : base(canvas)
    {
        Blocks = blocks;
    }
    
    public override void Rotate(Rotation rotation)
    {
    }
}

public class JShape : AbstractShape
{
    public JShape(Block topLeftBlock, Canvas canvas) : base(canvas)
    {
        Blocks = new List<Block>();
        Blocks.Add(topLeftBlock);
        Blocks.Add(new Block(topLeftBlock.X, topLeftBlock.Y + 1));
        Blocks.Add(new Block(topLeftBlock.X + 1, topLeftBlock.Y + 1));
        Blocks.Add(new Block(topLeftBlock.X + 2, topLeftBlock.Y + 1));
        Color = ConsoleColor.Red;
    }

    private JShape(List<Block> blocks, Canvas canvas) : base(canvas)
    {
        Blocks = blocks;
    }
    
    public override void Rotate(Rotation rotation)
    {
    }
}

public class SShape : AbstractShape
{
    public SShape(Block topLeftBlock, Canvas canvas) : base(canvas)
    {
        Blocks = new List<Block>();
        Blocks.Add(topLeftBlock);
        Blocks.Add(new Block(topLeftBlock.X + 1, topLeftBlock.Y));
        Blocks.Add(new Block(topLeftBlock.X + 1, topLeftBlock.Y - 1));
        Blocks.Add(new Block(topLeftBlock.X + 2, topLeftBlock.Y - 1));
        Color = ConsoleColor.Yellow;
    }

    private SShape(List<Block> blocks, Canvas canvas) : base(canvas)
    {
        Blocks = blocks;
    }
    
    public override void Rotate(Rotation rotation)
    {
    }
}

public class ZShape : AbstractShape
{
    public ZShape(Block topLeftBlock, Canvas canvas) : base(canvas)
    {
        Blocks = new List<Block>();
        Blocks.Add(topLeftBlock);
        Blocks.Add(new Block(topLeftBlock.X + 1, topLeftBlock.Y));
        Blocks.Add(new Block(topLeftBlock.X + 1, topLeftBlock.Y + 1));
        Blocks.Add(new Block(topLeftBlock.X + 2, topLeftBlock.Y + 1));
        Color = ConsoleColor.DarkBlue;
    }

    private ZShape(List<Block> blocks, Canvas canvas) : base(canvas)
    {
        Blocks = blocks;
    }
    
    public override void Rotate(Rotation rotation)
    {
    }
}

