// See https://aka.ms/new-console-template for more information

using Training.Kata.ConsoleGui;

var canvas = new Canvas();

canvas.SetCell(new Cell
{
    X = 10,
    Y = 5,
    Background = ConsoleColor.Blue
});

canvas.SetCell(new Cell
{
    X = 10,
    Y = 1,
    Background = ConsoleColor.Blue
});

canvas.Draw();

var a = 1;