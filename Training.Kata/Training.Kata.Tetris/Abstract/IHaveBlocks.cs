using Training.Kata.Tetris.Models;

namespace Training.Kata.Tetris.Abstract;

public interface IHaveBlocks
{
    List<Block> Blocks { get; }
    void Erase();
    void Draw();
}