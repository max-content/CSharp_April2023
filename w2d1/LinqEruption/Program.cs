List<Eruption> eruptions = new List<Eruption>()
{
    new Eruption("La Palma", 2021, "Canary Is", 2426, "Stratovolcano"),
    new Eruption("Villarrica", 1963, "Chile", 2847, "Stratovolcano"),
    new Eruption("Chaiten", 2008, "Chile", 1122, "Caldera"),
    new Eruption("Kilauea", 2018, "Hawaiian Is", 1122, "Shield Volcano"),
    new Eruption("Hekla", 1206, "Iceland", 1490, "Stratovolcano"),
    new Eruption("Taupo", 1910, "New Zealand", 760, "Caldera"),
    new Eruption("Lengai, Ol Doinyo", 1927, "Tanzania", 2962, "Stratovolcano"),
    new Eruption("Santorini", 46, "Greece", 367, "Shield Volcano"),
    new Eruption("Katla", 950, "Iceland", 1490, "Subglacial Volcano"),
    new Eruption("Aira", 766, "Japan", 1117, "Stratovolcano"),
    new Eruption("Ceboruco", 930, "Mexico", 2280, "Stratovolcano"),
    new Eruption("Etna", 1329, "Italy", 3320, "Stratovolcano"),
    new Eruption("Bardarbunga", 1477, "Iceland", 2000, "Stratovolcano")
};
// Example Query - Prints all Stratovolcano eruptions
IEnumerable<Eruption> stratovolcanoEruptions = eruptions.Where(c => c.Type == "Stratovolcano");
PrintEach(stratovolcanoEruptions, "Stratovolcano eruptions.");
// Execute Assignment Tasks here!

Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~");
Eruption ChileRupts = eruptions.First(c => c.Location == "Chile");
Console.WriteLine(ChileRupts);

Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~");
Eruption HawaiiRupts = eruptions.First(c => c.Location == "Hawaiian Is");
Console.WriteLine(HawaiiRupts);

Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~");
Eruption? GreenlandRupts = eruptions.FirstOrDefault(c=> c.Location == "Greenland");

if(GreenlandRupts == null)
{
    Console.WriteLine("No Greenland eruption found.");
}
else 
{
    Console.WriteLine(GreenlandRupts);
}

Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~");
Eruption? NewZealandRupts = eruptions.FirstOrDefault(c =>c.Location == "New Zealand" && c.Year > 1900);
Console.WriteLine(NewZealandRupts);

Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~");
List<Eruption>? ElevationAbove2000 = eruptions.Where(c => c.ElevationInMeters > 2000).ToList();
PrintEach(ElevationAbove2000, "Elevation is > 2000m");

List<Eruption>? NameStartsWithL = eruptions.Where(c => c.Volcano.StartsWith("L")).ToList();
PrintEach(NameStartsWithL, "Name Starts With L");

Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~");
int? MaxEl = eruptions.Max(c => c.ElevationInMeters);
Eruption? HighestElevation = eruptions.FirstOrDefault(c => c.ElevationInMeters == MaxEl);
Console.WriteLine( "Highest Elevation: " + HighestElevation.ElevationInMeters + "m");
Console.WriteLine( "Highest Volcano Elevation: " + HighestElevation.Volcano);

Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~");
List<Eruption>? Alphabetical = eruptions.OrderBy(c => c.Volcano).ToList();
PrintEach(Alphabetical, "Alphabetical");

Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~");
int? sum = eruptions.Sum(c => c.ElevationInMeters);
Console.WriteLine($"Sum of Elevations: {sum}");

Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~");
bool Year2000 = eruptions.Any(c => c.Year == 2000);
Console.WriteLine(Year2000);

Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~");
List<Eruption>? FirstThreeOfType = eruptions.Where(c => c.Type == "Stratovolcano").Take(3).ToList();
PrintEach(FirstThreeOfType);

Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~");
List<Eruption>? ChainedQueries = eruptions.Where(c => c.Year < 1000).OrderBy(c => c.Volcano).ToList();
PrintEach(ChainedQueries);

Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~");
List<String> ChainedQueries2 = eruptions.Where(c => c.Year < 1000).OrderBy(c => c.Volcano).Select(c => c.Volcano).ToList();

foreach(String volcano in ChainedQueries2)
{
    Console.WriteLine(volcano);
}

// Helper method to print each item in a List or IEnumerable. This should remain at the bottom of your class!
static void PrintEach(IEnumerable<Eruption> items, string msg = "")
{
    Console.WriteLine("\n" + msg);
    foreach (Eruption item in items)
    {
        Console.WriteLine(item.ToString());
    }
}


