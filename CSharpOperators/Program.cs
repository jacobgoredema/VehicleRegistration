using System;

namespace CSharpOperators
{
    class Program
    {
        static void Main(string[] args)
        {
            int num;
            num = 5;
            Console.WriteLine($"assigned value to variable:{num}");

            int x = 5;
            int y = 10;
            Console.WriteLine($"Addition:{x + y}");
            Console.WriteLine($"Subtraction:{x - y}");
            Console.WriteLine($"Multiplication:{x * y}");
            Console.WriteLine($"Division:{y / x}");
            Console.WriteLine($"Modulus:{x % y}");

            // Compound Operators
        }
    }
}