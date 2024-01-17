namespace Volue.BattleShips.Api;

// Obiekt reprezentujący dane wychodzący lub przychodzący z zewnątrz aplikacji
public class CellViewModel
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool IsShip { get; private set; }
    public bool IsHit { get; set; }
    
//  dostęo  konstruktor    Klasa zmiennej| Nazwa zmiennej
    public   CellViewModel(      Cell       domainModel)
    {
        X = domainModel.X;
        Y = domainModel.Y;
        IsShip = domainModel.IsShip;
        IsHit = domainModel.IsHit;
    }
}



// Obiekt domenowy zawierający logike
public class Cell
{
    public int X;
    public int Y;
    public bool IsShip;
    public bool IsHit;

    public void SetHit()
    {
        IsHit = true;
    }
}

