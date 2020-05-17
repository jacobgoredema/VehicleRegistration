using System;

namespace VariablesAndDataTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            string name;
            int age;
            double salary;
            bool working;
            char gender;

            Console.Write("Enter your name: ");
            name = Console.ReadLine();

            Console.Write("Enter your age: ");
            age = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter your Salary: ");
            salary = Convert.ToDouble(Console.ReadLine());

            Console.Write("Are you working (true or false: ");
            working = Convert.ToBoolean(Console.ReadLine());

            Console.Write("Enter Gender (M / F: ");
            gender = Convert.ToChar(Console.ReadLine());

            Console.WriteLine("Your name is "+ name +", your age is " + age+", salary is " 
                + salary+ ". Are you working "+ working+ " and you Gender is "+ gender);
        }
    }
}