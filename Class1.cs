using System;
class HelloWorld
{
    static void Main()
    {
        Console.WriteLine("Hello World");
        Console.WriteLine("Your age:");
    A:
        string line = Console.ReadLine();
        try
        {
            age = Int32.Parse(line);
        }
        catch (FormatException)
        {
            Console.WriteLine("{0} is not an integer", line);
            // Return? Loop round? Whatever.
            goto A;
        }
    }
}
