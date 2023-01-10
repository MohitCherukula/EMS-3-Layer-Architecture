using System;
using Capgemini.EMS.BusinessLayer;
using Capgemini.EMS.Entities;
using Capgemini.EMS.Exceptions;

namespace Capgemini.EMS.PL
{
    class Program
    {
        public static object Enviroment { get; private set; }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1 Add Employee ,2 Employee List, 3 Update Employee, 4.Delete Employee 5.Exit");
                Console.WriteLine("Enter Your Choice");
                string input = Console.ReadLine();
                if (!int.TryParse(input, out int choice))
                {
                    Console.WriteLine("invalid Input");
                    return;
                }
                switch (choice)
                {
                    case 1:
                        AddEmployee();
                        break;
                    case 2:
                        EmployeeList();
                    break;
                            case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid");
                        break;
                }
            }
        }

        private static void EmployeeList()
        {
            var list = EmployeeBL.GetList();
            Console.WriteLine("EmployeeList");
            foreach( var emp in list)
            {
                Console.WriteLine(emp); ;
            }
        }

        private static void AddEmployee()
        {
            Employee newEmployee = new Employee();
            Console.WriteLine("enter employee id");
            string input;
            int empid;
            DateTime dateofjoining;
            do
            {
                Console.WriteLine("Enter Employeeid");
                input = Console.ReadLine();
            } while (!int.TryParse(input, out empid));
            newEmployee.Id = empid;
            do
            {
                Console.WriteLine("Enter EmployeeName");
                input = Console.ReadLine();
            } while (string.IsNullOrEmpty(input));
            newEmployee.Name = input;
            do
            {
                Console.WriteLine("Enter Employee DoJ");
                input = Console.ReadLine();
            } while (!DateTime.TryParse(input, out dateofjoining));
            newEmployee.DateofJoining = dateofjoining;

            // call Business Layer
            try
            {
                bool isAdded = EmployeeBL.Add(newEmployee);
                if (isAdded)
                {
                    Console.WriteLine("Employee Added Succesfully");
                }
                else
                {
                    Console.WriteLine("Employee add failed");
                }
            }
            catch (EmsException ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

    }
}
