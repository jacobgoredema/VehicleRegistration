using System;

namespace ConditionStatements
{
    class Program
    {
        static void Main(string[] args)
        {
            int number1 = 3;
            int number2 = 5;
            int number3 = 0;
            string result;

            Console.WriteLine("How many apples do you have: ");
            number1 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("How many oranges do you have: ");
            number2 = Convert.ToInt32(Console.ReadLine());

            if(number2>number1)
                Console.WriteLine("Yes it is");
            else
                Console.WriteLine("No it is not");

            Console.WriteLine();
            Console.Write("How many eyes do you have: ");
            number3 = Convert.ToInt32(Console.ReadLine());
            switch (number3)
            {
                case 1:
                    Console.WriteLine("Value is 1");
                    break;
                case 2:
                    Console.WriteLine("Value is 2");
                    break;
                default:
                    Console.WriteLine("Invalid value");
                    break;
            }

            // tenary statement
            result = (number2 > number1) ? "You have more oranges" : "You have more apples";
            Console.WriteLine(result);



        }
    }
}