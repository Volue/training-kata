// See https://aka.ms/new-console-template for more information

using Spectre.Console;

var canvas = new Canvas(20, 20);

for (var i = 0; i < 20; i++)
{
    canvas.SetPixel(i, 0, Color.White);
    canvas.SetPixel(i, 19, Color.White);
    canvas.SetPixel(0, i, Color.White);
    canvas.SetPixel(19, i, Color.White);
}

canvas.SetPixel(10, 10, Color.White);
canvas.SetPixel(11, 10, Color.White);

canvas.SetPixel(13, 4, Color.Green);

AnsiConsole.Write(canvas);
Console.ReadLine();