﻿using Training.Kata.ConsoleGui;
using Training.Kata.Tetris.Abstract;
using Training.Kata.Tetris.Enums;
using Training.Kata.Tetris.Models;

namespace Training.Kata.Tetris.Shapes;

public class LShape : AbstractShape
{
    public LShape(Block topLeftBlock, Canvas canvas) : base(canvas, ConsoleColor.Magenta)
    {
        Blocks = new List<Block>();
        Blocks.Add(topLeftBlock);
        Blocks.Add(new Block(topLeftBlock.X + 1, topLeftBlock.Y));
        Blocks.Add(new Block(topLeftBlock.X + 2, topLeftBlock.Y));
        Blocks.Add(new Block(topLeftBlock.X + 2, topLeftBlock.Y - 1));
    }
    
    public override IEnumerable<Block> GetRotation()
    {
        throw new NotImplementedException();
    }

    public override void Rotate()
    {
    }
}