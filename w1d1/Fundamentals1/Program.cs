// //Create a loop that prints all values from 1-255.
for (int i = 1; i <= 255; i++ ) {
    Console.WriteLine(i);
}

int i = 0;
while (i <= 255) {
    Console.WriteLine(i);
    i ++;
}

// //Create a new loop that generates 5 random numbers between 10 and 20.
Random rand = new Random();
for(int i=1; i < 6; i++ ) {
    Console.WriteLine(rand.Next(10,20));
}

int j = 1;
Random randAlThor = new Random();
while (j < 6)
{
    Console.WriteLine(randAlThor.Next(10,20));
    j++;
}

// // Modify the previous loop to add the random values together and print the sum after the loop finishes.
Random rand = new Random();
int sum = 0;
for(int i=1; i < 6; i++ ) {
    sum += rand.Next(10,20);
}
Console.WriteLine(sum);

int j = 1;
int sum = 0;
Random randAlThor = new Random();
while (j < 6)
{
    sum += randAlThor.Next(10,20);
    j++;
}
Console.WriteLine(sum);


// // Create a new loop that prints all values from 1 to 100 that are divisible by 3 OR 5, but NOT both.
for (int i = 1; i <= 100; i++)
{
    if( i % 3 == 0 || i % 5 == 0) {
        Console.WriteLine(i);
    }
}

while(j <= 100 ) 
{
    if( j % 3 == 0 || j % 5 == 0) 
    {
        Console.WriteLine(j);
    }
    
    j++;
}

// // Modify the previous loop to print "Fizz" for multiples of 3 and "Buzz" for multiples of 5.
for (int i =1; i <= 100; i++) 
{
    if (i % 3 == 0 )
    {
        Console.WriteLine("Fizz");
    } else if (i % 5 == 0 )
    {
        Console.WriteLine("Buzz");
    } else
    {
        Console.WriteLine(i);
    }
}

while(j <=100) 
{
    if (j % 3 == 0 )
    {
        Console.WriteLine("Fizz");
    } else if (j % 5 == 0 )
    {
        Console.WriteLine("Buzz");
    } else 
    {
        Console.WriteLine(j);
    }
    j++;
}

// // Modify the previous loop once more to now also print "FizzBuzz" for numbers that are multiples of both 3 and 5.
for (int i =1; i <= 100; i++) 
{
    if (i % 3 == 0 && i % 5 == 0) 
    {
        Console.WriteLine("FizzBuzz");
    } else if (i % 3 == 0 )
    {
        Console.WriteLine("Fizz");
    } else if (i % 5 == 0 )
    {
        Console.WriteLine("Buzz");
    } 
}

while(j <= 100) 
{
    if (j % 3 == 0 && j % 5 == 0) 
    {
        Console.WriteLine("FizzBuzz");
    } else if (j % 3 == 0 )
    {
        Console.WriteLine("Fizz");
    } else if (j % 5 == 0 )
    {
        Console.WriteLine("Buzz");
    } else 
    {
        Console.WriteLine(j);
    }
    j++;
}