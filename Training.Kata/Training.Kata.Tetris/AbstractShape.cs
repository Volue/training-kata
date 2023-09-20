namespace Training.Kata.Tetris;

public abstract class AbstractShape
{
    public List<Block> Blocks { get; set; }
    
    public abstract void Move(MoveDirection moveDirection);
    public abstract void Rotate(Rotation rotation);
}

public class OShape : AbstractShape
{
    public OShape(Block topLeftBlock)
    {
        Blocks = new List<Block>();
        Blocks.Add(topLeftBlock);
        Blocks.Add(new Block(topLeftBlock.X + 1, topLeftBlock.Y));
        Blocks.Add(new Block(topLeftBlock.X, topLeftBlock.Y + 1));
        Blocks.Add(new Block(topLeftBlock.X + 1, topLeftBlock.Y + 1));
    }
    
    public void Move(MoveDirection moveDirection)
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

    public void Rotate(Rotation rotation)
    {
        
    }
}

