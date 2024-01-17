// See https://aka.ms/new-console-template for more information

using Training.Kata.ConsoleGui;

var canvas = new Canvas();

canvas.SetCell(new Cell
{
    X = 10,
    Y = 5,
    Background = ConsoleColor.Blue
});

canvas.SetCell(15, 5, ConsoleColor.Red, ConsoleColor.Blue);

canvas.SetCell(new Cell
{
    X = 10,
    Y = 1,
    Background = ConsoleColor.Blue
});

canvas.Draw();

var a = 1;

canvas.ClearCanvas();

canvas.SetCell(10, 5, ConsoleColor.Green, ConsoleColor.Blue);

canvas.Redraw();

a = 1;