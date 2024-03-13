using Training.Kata.ConsoleGui;
using Training.Kata.Tetris.Enums;
using Training.Kata.Tetris.Models;

namespace Training.Kata.Tetris.Abstract;

public abstract class AbstractShape : IHaveBlocks
{
    public List<Block> Blocks { get; set; }
    public readonly ConsoleColor Color;
    private readonly Canvas _canvas;
    
    public AbstractShape(Canvas canvas, ConsoleColor color)
    {
        _canvas = canvas;
        Color = color;
    }
    
    public abstract void Rotate();
    public abstract IEnumerable<Block> GetRotation();

    public void Erase()
    {
        Blocks.ForEach(block => _canvas.SetCell(block.X, block.Y));
    }

    public void Draw()
    {
        Blocks.ForEach(block => _canvas.SetCell(block.X, block.Y, Color));
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