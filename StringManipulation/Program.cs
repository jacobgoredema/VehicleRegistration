using System;

namespace StringManipulation
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstName = "Hi, my name is Jacob";
            string lastName = "Gore";
            Console.WriteLine(firstName + " " + lastName);
            Console.WriteLine("{0} {1}", firstName, lastName);
            Console.WriteLine($"{firstName} {lastName}");

            int length = firstName.Length;
            Console.WriteLine(length);

            string newName = firstName.Replace('c', 'K');
            Console.WriteLine(newName);

            // compare string
            int result = string.Compare(firstName, lastName);

            //convert to string
            result.ToString();

            //exception handling
            try
            {
                Console.WriteLine("Enter a first number");
                int number1 = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter second Number");
                int number2 = int.Parse(Console.ReadLine());

                int results = number1 / number2;
                Console.WriteLine($"Result: {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Program ended");
            }
            
        }
    }
}