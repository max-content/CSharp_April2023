static string CoinFlip()
{
    string result = "";
    Random rand = new Random();
    
    int value = rand.Next(1,10);
    Console.WriteLine($"Value: {value}");
    if(value <= 1 )
    {
        result = "heads";
    } else
    { 
        result = "tails";
    }

    return result;
}

// rolling 1d6
static int DiceRoll()
{
    int result = 0;
    Random rand = new Random();
    int numOfSides = 6;
    result = rand.Next(1, numOfSides+1);

    return result;
}

static int ChooseYourDie(int die) 
{

    Random rand = new Random();
    int numOfSides = die;
    int result = rand.Next(1, numOfSides + 1);
    if(numOfSides == 20)
    {
        return result;
    } else if(numOfSides == 100)
    {
        return result;
    } else if(numOfSides == 12)
    {
        return result;
    } else if(numOfSides == 10)
    {
        return result;
    } else if(numOfSides == 8)
    {
        return result;
    } else if(numOfSides == 6)
    {
        return result;
    } else if(numOfSides == 4)
    {
        return result;
    }
    return result;
}

static List<int> RollStats(int dice, int times)
{
    List<int> stats = new List<int>();
    int i = 1;
    while(i <= times)
    {
        stats.Add(ChooseYourDie(dice));
        i++;
    }
    return stats;

}

static List<int> RollUntil(int num, int dice)
{
    List<int> listOfAttempts = new List<int>();
    int result = ChooseYourDie(dice);
    while(result != num)
    {
        listOfAttempts.Add(result);
        result = ChooseYourDie(dice);
    }
    return listOfAttempts;
}

//~~~~~~~~~~~~~~~~~~~~~~~~~~~ Tests ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
Console.WriteLine("~~~~~~~~ Flip 1 ~~~~~~~~");
Console.WriteLine(CoinFlip());

Console.WriteLine("~~~~~~~~ Flip 2 ~~~~~~~~");
Console.WriteLine(CoinFlip());

Console.WriteLine("~~~~~~~~ Flip 3 ~~~~~~~~");
Console.WriteLine(CoinFlip());

Console.WriteLine("~~~~~~~~ Rolling 1d6  ~~~~~~~~");
Console.WriteLine($" You rolled a {DiceRoll()}");

Console.WriteLine("~~~~~~~~ Rolling Your Choice  ~~~~~~~~");
Console.WriteLine(ChooseYourDie(20));

Console.WriteLine("~~~~~~~~ Stats  ~~~~~~~~");
Console.WriteLine(String.Join(", ", RollStats(20, 8)));

Console.WriteLine("~~~~~~~~ Roll Until  ~~~~~~~~");
Console.WriteLine(String.Join(", ", RollUntil(19, 20).Count));