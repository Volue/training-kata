using Training.Kata.ConsoleGui;
using Training.Kata.Tetris.Abstract;
using Training.Kata.Tetris.Models;
using Training.Kata.Tetris.Shapes;

namespace Training.Kata.Tetris.Factories;

public class ShapeFactory
{
    private readonly Random _random;
    private readonly Canvas _canvas;
    private readonly List<Func<AbstractShape>> _factoryFunctions;

    public ShapeFactory(Canvas canvas)
    {
        _random = new Random();
        _canvas = canvas;
        _factoryFunctions = new List<Func<AbstractShape>>
        {
            // CreateO,
            CreateI,
            // CreateL,
            // CreateJ,
            // CreateS,
            // CreateZ
        };
    }

    public AbstractShape CreateRandom()
    {
        return _factoryFunctions[_random.Next(0, _factoryFunctions.Count)]();
    }

    private AbstractShape CreateO() => new OShape(new Block(5, 1), _canvas);
    private AbstractShape CreateI() => new IShape(new Block(4, 1), _canvas);
    private AbstractShape CreateL() => new LShape(new Block(4, 2), _canvas);
    private AbstractShape CreateJ() => new JShape(new Block(4, 1), _canvas);
    private AbstractShape CreateS() => new SShape(new Block(5, 2), _canvas);
    private AbstractShape CreateZ() => new ZShape(new Block(5, 1), _canvas);
}
