namespace Training.Kata.ConsoleGui;

public class Canvas
{
    public List<Cell> Cells = new();

    public void ClearCells()
    {
        ClearCanvas();
        Cells = new List<Cell>();
    }

    public void ClearCanvas()
    {
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.White;
        Console.Clear();
    }

    public void SetCell(Cell cell)
    {
        var cellResult = Cells.SingleOrDefault(x => x.X == cell.X & x.Y == cell.Y);
        if (cellResult is null)
        {
            Cells.Add(cell);
            return;
        }

        cellResult.Background = cell.Background;
        cellResult.Foreground = cell.Foreground;
    }

    public void SetCell(int x, int y, ConsoleColor backgroundColor = ConsoleColor.Black, ConsoleColor foregroundColor = ConsoleColor.White)
    {
        SetCell(new Cell
        {
            X = x,
            Y = y,
            Background = backgroundColor,
            Foreground = foregroundColor
        });
    }

    public void Draw()
    {
        Cells.OrderBy(cell => cell.Y).ToList().ForEach(cell =>
        {
            Console.BackgroundColor = cell.Background;
            Console.ForegroundColor = cell.Foreground;
            Console.SetCursorPosition(cell.X * 2, cell.Y);
            Console.Write("  ");
        });
    }

    public void Redraw()
    {
        ClearCanvas();
        Draw();
    }
}