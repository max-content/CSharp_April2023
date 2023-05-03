//Class Declaration
class Vehicle
{
    //Declare class properties -- these will default to private --
    public string Type {get;set;}
    public string Color {get;set;}
    public bool HasEngine {get;set;}
    public int MaxNumPassengers {get;set;}
    public int NumOfMiles {get;set;}

    //Declare pubic if public
    public Vehicle(string type, string color, bool hasEngine = true, int maxNumPassengers = 5, int numOfMiles = 0) 
    {
        Type = type;
        Color = color;
        HasEngine = hasEngine;
        MaxNumPassengers = maxNumPassengers;
        NumOfMiles = numOfMiles;
    }

    // Method Declarations
    public void ShowInfo()
    {
        Console.WriteLine($"Vehicle Info: Type - {Type} Color - {Color} Has Engine - {HasEngine} Max Number of Passengers - {MaxNumPassengers} Number of Miles - {NumOfMiles}");
    }
    public void Travel(int distance) 
    {
        NumOfMiles = NumOfMiles + distance;
        Console.WriteLine(NumOfMiles);
    }

}