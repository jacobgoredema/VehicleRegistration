using System;

namespace Methods
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter first number: ");
            int n1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter second number: ");
            int n2 = int.Parse(Console.ReadLine());

            Console.Write("Enter third number: ");
            int n3 = int.Parse(Console.ReadLine());

            int result = LargestNumber(n1, n2, n3);
            Console.WriteLine("The largest number is: "+ result);
        }

        static int LargestNumber(int num1,int num2, int num3)
        {
            int largest = num1;
            if(num2>largest)
            {
                largest = num2;
            }

            if(num3>largest)
            {
                largest = num3;
            }

            return largest;
        }
    }
}