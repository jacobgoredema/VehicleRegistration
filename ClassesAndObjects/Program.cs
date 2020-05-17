using System;

namespace ClassesAndObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            Box box = new Box();
            Person person = new Person();

            Console.Write("Enter length:");
            double length = double.Parse(Console.ReadLine());
            Console.Write("Enter Width: ");
            double width = double.Parse(Console.ReadLine());
            Console.Write("Enter Height: ");
            double height = double.Parse(Console.ReadLine());

            box.Width = width;
            box.Length = length;
            box.Height = height;
            double volume = box.GetVolume();

            Console.WriteLine($"volume is {volume}");
        }
    }
}