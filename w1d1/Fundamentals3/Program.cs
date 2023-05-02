// 1. Iterate and print values
// Given a List of strings, iterate through the List and print out all the values. Bonus: How many different ways can you find to print out the contents of a List? (There are at least 3! Check Google!)

static void PrintList(List<string> MyList)
{
    Console.WriteLine("~~~~~~~~~~~ Method 1 ~~~~~~~~~~~~");
    Console.WriteLine(String.Join(", ", MyList));
    
    Console.WriteLine("~~~~~~~~~~~ Method 2 ~~~~~~~~~~~~");
    foreach(string clone in MyList)
    {
        Console.WriteLine(clone);
    }

    Console.WriteLine("~~~~~~~~~~~ Method 3 ~~~~~~~~~~~~");
    for(int idx = 0; idx < MyList.Count; idx++)
    {
         Console.WriteLine(MyList[idx]);
    }
}

List<string> TestStringList = new List<string>() {"Sarah", "Helena", "Alison", "Cosima", "Rachel"};
PrintList(TestStringList);

// 2. Print Sum
// Given a List of integers, calculate and print the sum of the values.
static void SumOfNumbers(List<int> IntList)
{
    int sum =0;
    foreach(int num in IntList)
    {
         sum += num;
    }
    Console.WriteLine(sum);
}

List<int> TestIntList = new List<int>() {2,4,6,0,1};
SumOfNumbers(TestIntList);

// 3. Find Max
// Given a List of integers, find and return the largest value in the List.

static int FindMax(List<int> IntList)
{
    int temp = 0;
    for(int idx=0; idx <= IntList.Count -1; idx++)
    {
        if(IntList[idx] >= temp)
        {
            temp = IntList[idx];
        }
    }
    Console.WriteLine(temp);
    return temp;
}
FindMax(TestIntList);

// 4. Square the Values
// Given a List of integers, return the List with all the values squared.

static List<int> SquareValues(List<int> IntList)
{
    List<int> tempList = new List<int>();
    for(int idx =0; idx <= IntList.Count-1; idx++)
    {
        int squared = IntList[idx] * 2;
        tempList.Add(squared);
    }
    Console.WriteLine(String.Join(", ", tempList));
    return tempList;
}
SquareValues(TestIntList);

// 5. Replace Negative Numbers with 0
// Given an array of integers, return the array with all values below 0 replaced with 0.

static int[] NonNegatives(int[] IntArray)
{
    for(int idx = 0; idx <= IntArray.Length - 1; idx++)
    {
        if(IntArray[idx] < 0) 
        {
            IntArray[idx] = 0;
        }
    }
    Console.WriteLine(String.Join(", ", IntArray));
    return IntArray;
}
int[] TestIntArray = new int[] {-1, 2, 3, -4, 5};
NonNegatives(TestIntArray);

// 6. Print Dictionary
// Given a dictionary, print the contents of the said dictionary.

static void PrintDictionary(Dictionary<string,string> MyDictionary)
{
    foreach(KeyValuePair<string,string> entry in MyDictionary)
    {
        Console.WriteLine($"{entry.Key}: {entry.Value}");
    }
}

Dictionary<string,string> TestDict = new Dictionary<string, string>();
TestDict.Add("HeroName", "Iron Man");
TestDict.Add("RealName", "Tony Stark");
TestDict.Add("Powers", "none...smart with money is not a power...");
PrintDictionary(TestDict);


//7. Find Key
// Given a search term, return true or false whether the given term is a key in a dictionary. (Hint: figuring this one out may require some research!)

static bool FindKey(Dictionary<string,string> MyDictionary, string SearchTerm)
{
    if(MyDictionary.ContainsKey(SearchTerm))
    {
        return true;
    } else
    {

        return false;
    }

}

Console.WriteLine(FindKey(TestDict, "RealName"));
Console.WriteLine(FindKey(TestDict, "Name"));
// 8. Generate a Dictionary
// Given a List of names and a List of integers, create a dictionary where the key is a name from the List of names and the value is a number from the List of numbers. Assume that the two Lists will be of the same length. Don't forget to print your results to make sure it worked.

static Dictionary<string,int> GenerateDictionary(List<string> names, List<int> numbers) 
{
    Dictionary<string,int> myDictionary = new Dictionary<string, int>();

    for(int idx = 0; idx < names.Count; idx++)
    {
        myDictionary.Add(names[idx], numbers[idx]);
    }
    foreach(KeyValuePair<string,int> entry in myDictionary)
    {
        Console.WriteLine($"{entry.Key}: {entry.Value}");
    }
    return myDictionary;
}

// List<int> TestIntList = new List<int>() {2,4,6,0,1};
//List<string> TestStringList = new List<string>() {"Sarah", "Helena", "Alison", "Cosima", "Rachel"};
GenerateDictionary(TestStringList, TestIntList);