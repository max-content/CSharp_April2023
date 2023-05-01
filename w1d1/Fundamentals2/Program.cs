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
bool[] boolArr = new boolArr[9];

int idx = 0;
while (idx > boolArr.Length)
{
    if (idx % 2 == 0 )
    { 
        boolArr.Add("true");
    } else 
    {
        boolArr.Add("false");
    }
    idx ++;
}
Console.WriteLine(boolArr);
