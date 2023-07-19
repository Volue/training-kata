using Spectre.Console;

namespace Training.Kata.Snake;

public class Food
{
    public int X;
    public int Y;
    private readonly Canvas _canvas;

    public Food(int x, int y, Canvas canvas)
    {
        X = x;
        Y = y;
        _canvas = canvas;
    }

    public void Draw()
    {
        _canvas.SetPixel(X, Y, Color.Green);
    }
}