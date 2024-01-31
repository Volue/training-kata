using Training.Kata.ConsoleGui;

namespace Training.Kata.Tetris;

public class Rectangle : IHaveBlocks
{
    public List<Block> Blocks { get; } = new();
    private readonly Canvas _canvas;
    private readonly int _sizeX;
    private readonly int _sizeY;

    public Rectangle(int sizeX, int sizeY, Canvas canvas)
    {
        _sizeX = sizeX;
        _sizeY = sizeY;
        _canvas = canvas;
        Setup();
    }

    private void Setup()
    {
        for (var x = 0; x <= _sizeX; x++)
        {
            Blocks.Add(new Block(x, 0));
            Blocks.Add(new Block(x, _sizeY));
        }
        
        for (var y = 0; y <= _sizeY; y++)
        {
            Blocks.Add(new Block(0, y));
            Blocks.Add(new Block(_sizeX, y));
        }
    }

    public void Draw()
    {
        Blocks.ForEach(block => _canvas.SetCell(block.X, block.Y, ConsoleColor.White));
    }
}