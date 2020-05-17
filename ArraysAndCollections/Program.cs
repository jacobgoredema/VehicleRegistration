using System;
using System.Collections.Generic;

namespace ArraysAndCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            // declare an array of fixed size
            int[] grades = new int[5];
            //grades[0]=1;
            //grades[1] = 90;
            //grades[2] = 56;
            //grades[3] = 87;
            //grades[4] = 46;

            //grades = new int[] { 10, 56, 45, 34, 89 };
            // declare variable size array
            for (int i = 0; i < grades.Length; i++)
            {
                Console.Write("Enter Grade: ");
                grades[i]= int.Parse(Console.ReadLine());
            }

            Console.WriteLine();
            Console.Write("The grades you entered are: ");
            for (int i = 0; i < grades.Length; i++)
            {
                Console.Write(grades[i] +", ");
            }

            int[] grades1;
            grades1 = new int[] { 18, 95, 57, 84, 70 };
            for (int i = 0; i < grades1.Length; i++)
            {
                Console.WriteLine(grades1[i]);
            }

            // using List
            // declare a list
            List<string> names = new List<string>();
            names.Add("Jacob");
            names.Add("Gore");
            names.Add("Nana");

            string name = string.Empty;
            Console.Write("Enter Names: ");
            while (!name.Equals("-1"))
            {
                name = Console.ReadLine();
                if (!name.Equals("-1"))
                {
                    names.Add(name);
                }
            }

            // using a for loop for output
            Console.WriteLine("The names you entered are using a for loop: ");
            for (int i = 0; i < names.Count; i++)
            {
                Console.WriteLine(names[i]);
            }

            Console.WriteLine();
            // or using a foreach loop easier to write output
            Console.WriteLine("The names you entered are using a foreach loop: ");
            foreach (var item in names)
            {
                Console.WriteLine(item);
            }
        }
    }
}