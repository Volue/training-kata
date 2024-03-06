using Training.Kata.ConsoleGui;

namespace Training.Kata.Tetris;

public class ShapeFactory
{
    private readonly Canvas _canvas;
    private List<Func<AbstractShape>> _factoryFunctions;
    private Random _random;

    public ShapeFactory(Canvas canvas)
    {
        _random = new Random();
        _canvas = canvas;
        _factoryFunctions = new List<Func<AbstractShape>>()
        {
            CreateO,
            CreateI,
            CreateL,
            CreateJ,
            CreateS,
            CreateZ
        };
    }

    public AbstractShape CreateRandom()
    {
        return _factoryFunctions[_random.Next(0, _factoryFunctions.Count)]();
    }

    public AbstractShape CreateO() => new OShape(new Block(5, 1), _canvas);
    public AbstractShape CreateI() => new IShape(new Block(4, 1), _canvas);
    public AbstractShape CreateL() => new LShape(new Block(4, 2), _canvas);
    public AbstractShape CreateJ() => new JShape(new Block(4, 1), _canvas);
    public AbstractShape CreateS() => new SShape(new Block(5, 2), _canvas);
    public AbstractShape CreateZ() => new ZShape(new Block(5, 1), _canvas);
}
