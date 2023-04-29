// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Random rand = new Random();
for(int i = 1; i <= 10; i++)
{
    // Every time the loop executes we will get a NEW random value between 2 and 7
    Console.WriteLine(rand.Next(2,8));
}