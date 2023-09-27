using Spectre.Console;

namespace Training.Kata.Tetris;

public class Rectangle
{
    private readonly List<(int X, int Y)> _position = new();
    private readonly Canvas _canvas;
    private readonly int _sizeX;
    private readonly int _sizeY;

    public Rectangle(int sizeX, int sizeY, Canvas canvas)
    {
        _sizeX = sizeX;
        _sizeY = sizeY;
        _canvas = canvas;
    }

    public void Draw()
    {
        for (var x = 0; x <= _sizeX; x++)
        {
            DrawPixel(x, 0);
            DrawPixel(x, _sizeY);
        }
        
        for (var y = 0; y <= _sizeY; y++)
        {
            DrawPixel(0, y);
            DrawPixel(_sizeX, y);
        }
    }

    private void DrawPixel(int x, int y)
    {
        _canvas.SetPixel(x, y, Color.White);
        _position.Add((x, y));
    }
}