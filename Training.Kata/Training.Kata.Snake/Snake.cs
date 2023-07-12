using System.Drawing;
using Spectre.Console;
using Color = Spectre.Console.Color;

namespace Training.Kata.Snake;

public class Snake
{
    private readonly Canvas Canvas;
    private readonly List<SnakeSegment> Body;

    public Snake(Canvas canvas, List<SnakeSegment> body)
    {
        Canvas = canvas;
        Body = body;
    }

    public void Update(int x, int y)
    {
        // Usuń starego węża
        Draw(Color.Black);
        
        // Przesuń węża
        UpdatePosition(x, y);
        
        // Narysuj węża
        Draw(Color.Pink1);
    }

    public void Draw(Color color)
    {
        Body.ForEach(s => Canvas.SetPixel(s.X, s.Y, color));
    }

    public SnakeSegment GetHead()
    {
        return Body.Single(x => x.Number == 0);
    }

    private void UpdatePosition(int x, int y)
    {
        var oldPosition = new SnakeSegment[Body.Count];
        Body.CopyTo(oldPosition);
        MoveHead(x, y);
        MoveBody(oldPosition);
    }

    private void MoveBody(SnakeSegment[] oldPosition)
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

    private void MoveHead(int x, int y)
    {
        var snakeHead = Body.Single(s => s.Number == 0);
        snakeHead.X = x;
        snakeHead.Y = y;
    }
}