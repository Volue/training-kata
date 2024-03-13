using Training.Kata.Tetris.Abstract;

namespace Training.Kata.Tetris.Models;

public class Collider
{
    public bool DoesItCollide(List<Block> figure, List<IHaveBlocks> board)
    {
        var allBlocks = board.SelectMany(x => x.Blocks).ToList();
        foreach (var block in figure)
        {
            var thereIsCollision = allBlocks.Any(element => element.X == block.X && element.Y == block.Y);
            if (thereIsCollision)
            {
                return true;
            } 
        }
        return false;
    }
}