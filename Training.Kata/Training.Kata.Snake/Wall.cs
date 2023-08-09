using Spectre.Console;

namespace Training.Kata.Snake;

public class Wall
{
    public readonly List<(int X, int Y)> Position = new();
    private readonly Canvas _canvas;
    private readonly int _size;

    public Wall(int size, Canvas canvas)
    {
        _size = size;
        _canvas = canvas;
    }
    
    public void Draw()
    {
        for (var i = 0; i < _size; i++)
        {
            _canvas.SetPixel(i, 0, Color.White);
            Position.Add((i, 0));

            _canvas.SetPixel(i, _size - 1, Color.White);
            Position.Add((i, _size - 1));
            
            _canvas.SetPixel(0, i, Color.White);
            Position.Add((0, i));

            _canvas.SetPixel(_size - 1, i, Color.White);
            Position.Add((_size - 1, i));
        }
    }
}