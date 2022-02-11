using CollectionsLibrary.Concrete;
using CollectionsLibrary.Entities;
using CollectionsLibrary.Validators;
using System;

namespace TestUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FailedValidatedExample();
        }

        private static void ValidatedExample()
        {
            ValidatedList<Employee, EmployeeValidator> employees = new ValidatedList<Employee, EmployeeValidator>();

            Employee e1 = new Employee { Id = 1, FirstName = "Vahap Onur", LastName = "YILDIRIM" };
            Employee e2 = new Employee { Id = 2, FirstName = "Beyza", LastName = "YILDIRIM" };
            Employee e3 = new Employee { Id = 3, FirstName = "Hamit", LastName = "YILDIRIM" };
            employees.Add(e1);
            employees.Add(e2);
            employees.Add(e3);
            foreach (var item in employees)
            {
                Console.WriteLine(item.FirstName + " " + item.LastName);
            }
            employees.Remove(e1);
            foreach (var item in employees)
            {
                Console.WriteLine(item.FirstName + " " + item.LastName);
            }
        }
        private static void FailedValidatedExample()
        {
            ValidatedList<Employee, EmployeeValidator> employees = new ValidatedList<Employee, EmployeeValidator>();

            Employee e1 = new Employee { Id = 1, FirstName = "Ba", LastName = "YILDIRIM" };
            Employee e2 = new Employee { Id = 2, FirstName = "Beyza", LastName = "YILDIRIM" };
            Employee e3 = new Employee { Id = 3, FirstName = "Hamit", LastName = "YILDIRIM" };
            employees.Add(e1);
            employees.Add(e2);
            employees.Add(e3);
            foreach (var item in employees)
            {
                Console.WriteLine(item.FirstName + " " + item.LastName);
            }
            employees.Remove(e1);
            foreach (var item in employees)
            {
                Console.WriteLine(item.FirstName + " " + item.LastName);
            }
        }
    }
}
