using System;
using System.Collections.Generic;
using System.Text;

namespace ClassesAndObjects
{
    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        private double Salary;

        public double getSalary()
        {
            return Salary;
        }

        public void getSalary(double salary)
        {
            Salary = salary;
        }

    }
}
