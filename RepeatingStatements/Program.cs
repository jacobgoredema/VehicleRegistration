using System;

namespace RepeatingStatements
{
    class Program
    {
        static void Main(string[] args)
        {
            // counter controlled loop  For
            for(int i =0;i<= 10; i++)
            {
                Console.WriteLine(i+ ". I am a winner");
            }

            //pre check While
            int n = 0;
            while(n<=10)
            {
                Console.Write("Input a number (0 - 4)");
                n = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("You entered: "+ n);
                n += 1;
            }
            Console.WriteLine("\n While Loop Finished.");

            //Post Check do loop
            do
            {
                Console.Write("Input a number (0 - 4)");
                n = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("You entered: " + n);
                n += 1;
            } while (n < 5);





        }
    }
}