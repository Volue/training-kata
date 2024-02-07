namespace Training.Kata.Tetris;

public interface IHaveBlocks
{
    List<Block> Blocks { get; }
    void Erase();
    void Draw();
}