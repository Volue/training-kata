namespace Training.Kata.ConsoleGui;

public class Canvas
{
    public List<Cell> Cells = new();

    public void Clear()
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

    public void Draw()
    {
        Cells.OrderBy(cell => cell.Y).ToList().ForEach(cell =>
        {
            Console.SetCursorPosition(cell.X, cell.Y);
            Console.BackgroundColor = cell.Background;
            Console.ForegroundColor = cell.Foreground;
            Console.Write(" ");
        });
    }

    public void Redraw()
    {
        
    }
}