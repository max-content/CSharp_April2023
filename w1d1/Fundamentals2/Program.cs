// Create an integer array with the values 0 through 9 inside.
// int[] intArray;
// intArray = new int[] {0,1,2,3,4,5,6,7,8,9};

// for (int i=0; i < intArray.Length; i++) {
//     Console.WriteLine(intArray[i]);
// }

// Create a string array with the names "Tim", "Martin", "Nikki", and "Sara".
// string[] namesArr;
// namesArr = new string[] {"Tim", "Martin", "Nikki", "Sara"};

// for (int i=0; i < namesArr.Length; i++) {
//     Console.WriteLine(namesArr[i]);
// }

// Create a boolean array of length 10. Then fill it with alternating true/false values, starting with true. (Tip: do this using logic! Do not hard-code the values in!)
bool[] BoolArr = new bool[9];

int idx = 0;
while (idx > BoolArr.Length)
{
    Console.WriteLine("I am here");
    if (idx % 2 == 0 )
    { 
        BoolArr[idx] = false;
    } else 
    {
        BoolArr[idx] = true;
    }
    idx ++;
}
Console.WriteLine(String.Join(", ", BoolArr));

//Create a string List of ice cream flavors that holds at least 5 different flavors. (Feel free to add more than 5!)

// List<string> flavors = new List<string>();
// flavors.Add("vanilla");
// flavors.Add("chocolate");
// flavors.Add("half baked");
// flavors.Add("chocolate chip cookie dough");
// flavors.Add("mint chocolate chip");
// flavors.Add("cookies and cream");

// foreach (string flavor in flavors)
// {
//     Console.WriteLine(flavor);
// }

// Output the length of the List after you added the flavors.
List<string> flavors = new List<string>();
flavors.Add("vanilla");
flavors.Add("chocolate");
flavors.Add("half baked");
flavors.Add("chocolate chip cookie dough");
flavors.Add("mint chocolate chip");
flavors.Add("cookies and cream");

foreach (string flavor in flavors)
{
    Console.WriteLine(flavor);
}

Console.WriteLine("Flavors: {0}", flavors.Count);
Console.WriteLine(flavors[2]);
flavors.Remove(flavors[2]);

Console.WriteLine("~~~~~~~~~~~~~~~~~");
foreach (string flavor in flavors)
{
    Console.WriteLine(flavor);
}

Console.WriteLine("Flavors: {0}", flavors.Count);

// Create a dictionary that will store string keys and string values.
// Add key/value pairs to the dictionary where:
// Each key is a name from your names array (this can be done by hand or using logic)
// Each value is a randomly selected flavor from your flavors List (remember Random from earlier?)
// Loop through the dictionary and print out each user's name and their associated ice cream flavor.

Dictionary<string,string> iceCreamFavs = new Dictionary<string, string>();

iceCreamFavs.Add("Name", "Tim");
iceCreamFavs.Add("Flavor", "chocolate");

iceCreamFavs.Add("newKey", "Max");
iceCreamFavs.Add("newFlavorKey", "half baked");


foreach(KeyValuePair<string,string> entry in iceCreamFavs)
{
    Console.WriteLine($"{entry.Key} - {entry.Value}");
}


