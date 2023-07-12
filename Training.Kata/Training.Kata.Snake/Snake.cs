using System.Drawing;
using Spectre.Console;
using Color = Spectre.Console.Color;

namespace Training.Kata.Snake;

public class Snake
{
    public Canvas Canvas;
    public List<SnakeSegment> Body;

    public Snake(Canvas canvas, List<SnakeSegment> body)
    {
        Canvas = canvas;
        Body = body;
    }

    public void Draw(Color color)
    {
        Body.ForEach(s => Canvas.SetPixel(s.X, s.Y, color));
    }

    public void Update()
    {
        // Usuń starego węża
        // Przesuń węża
        // Narysuj węża
    }

    public void UpdatePosition(int x, int y)
    {
        var oldPosition = Array.Empty<SnakeSegment>();
        Body.CopyTo(oldPosition);
        MoveHead(x, y);
        MoveBody(oldPosition);
    }

    public void MoveBody(SnakeSegment[] oldPosition)
    {
        Body.Where(s => s.Number > 0)
            .ToList()
            .ForEach(s =>
            {
                var newSegmentPosition = oldPosition.Single(o => o.Number == s.Number - 1);
                s.X = newSegmentPosition.X;
                s.Y = newSegmentPosition.Y;
            });
    }

    public void MoveHead(int x, int y)
    {
        var snakeHead = Body.Single(s => s.Number == 0);
        snakeHead.X = x;
        snakeHead.Y = y;
    }
}