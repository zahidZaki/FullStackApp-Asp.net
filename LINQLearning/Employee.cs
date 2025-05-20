using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace LINQLearning
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Department { get; set; }
        public int Age { get; set; }
        public int Salary { get; set; }
    }
    public class DataManageSimpleData
    {
        public static List<Employee> GetSimpleEmployees()
        {
            return new List<Employee>
        {
            new Employee { Id = 1, FirstName = "John", LastName = "Doe", Department = "HR", Age = 30, Salary = 50000 },
            new Employee { Id = 2, FirstName = "Jane", LastName = "Smith", Department = "IT", Age = 28, Salary = 60000 },
            new Employee { Id = 3, FirstName = "Sam", LastName = "Brown", Department = "Finance", Age = 35, Salary = 70000 },
            new Employee { Id = 4, FirstName = "Sara", LastName = "Davis", Department = "Marketing", Age = 25, Salary = 55000 },
            new Employee { Id = 5, FirstName = "Mike", LastName = "Wilson", Department = "Sales", Age = 40, Salary = 80000 }
        };
        }
    }


    public static class DataManager
    {
        private static readonly string[] FirstNames = { "John", "Jane", "Sam", "Sara", "Mike", "Tom", "Lucy", "Robert", "Emily", "David" };
        private static readonly string[] LastNames = { "Doe", "Smith", "Brown", "Davis", "Wilson", "Taylor", "Moore", "Clark", "Hall", "Lewis" };
        private static readonly string[] Departments = { "HR", "IT", "Finance", "Marketing", "Sales", "Admin" };

        public static List<Employee> GetEmployees()
        {
            var employees = new List<Employee>();
            var rand = new Random();

            for (int i = 1; i <= 150; i++)
            {
                var employee = new Employee
                {
                    Id = i,
                    FirstName = FirstNames[rand.Next(FirstNames.Length)],
                    LastName = LastNames[rand.Next(LastNames.Length)],
                    Department = Departments[rand.Next(Departments.Length)],
                    Age = rand.Next(22, 60),
                    Salary = rand.Next(40000, 120000)
                };

                employees.Add(employee);
            }

            return employees;
        }
    }

    public class DataManageSimple2Data
    {
        public static List<Employee> GetSimple2Employees()
        {
            var employees = new List<Employee>();
            string[] firstNames = { "John", "Jane", "Sam", "Sara", "Mike", "Alex", "Emily", "David", "Sophia", "Chris" };
            string[] lastNames = { "Doe", "Smith", "Brown", "Davis", "Wilson", "Taylor", "Clark", "Lewis", "Hall", "Young" };
            string[] departments = { "HR", "IT", "Finance", "Marketing", "Sales", "Operations", "Admin", "Legal", "Support", "R&D" };

            Random rand = new Random();

            for (int i = 1; i <= 150; i++)
            {
                var employee = new Employee
                {
                    Id = i,
                    FirstName = firstNames[rand.Next(firstNames.Length)],
                    LastName = lastNames[rand.Next(lastNames.Length)],
                    Department = departments[rand.Next(departments.Length)],
                    Age = rand.Next(22, 60),          // Age between 22 and 60
                    Salary = rand.Next(40000, 120001) // Salary between 40,000 and 120,000
                };

                employees.Add(employee);
            }

            return employees;
        }
    }

}

