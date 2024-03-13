﻿using Training.Kata.ConsoleGui;
using Training.Kata.Tetris.Abstract;
using Training.Kata.Tetris.Enums;
using Training.Kata.Tetris.Models;

namespace Training.Kata.Tetris.Shapes;

public class ZShape : AbstractShape
{
    public ZShape(Block topLeftBlock, Canvas canvas) : base(canvas, ConsoleColor.DarkBlue)
    {
        Blocks = new List<Block>();
        Blocks.Add(topLeftBlock);
        Blocks.Add(new Block(topLeftBlock.X + 1, topLeftBlock.Y));
        Blocks.Add(new Block(topLeftBlock.X + 1, topLeftBlock.Y + 1));
        Blocks.Add(new Block(topLeftBlock.X + 2, topLeftBlock.Y + 1));
    }
    
    public override IEnumerable<Block> GetRotation()
    {
        return new List<Block>();
    }

    public override void Rotate()
    {
    }
}