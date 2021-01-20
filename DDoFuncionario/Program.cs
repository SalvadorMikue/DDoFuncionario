using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDoFuncionario.Entities;
using DDoFuncionario.Entities.Enums;



namespace DDoFuncionario
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter department name;");
            string deptName = Console.ReadLine();
            Console.WriteLine("Enter worker data:");
            Console.Write("Name:");
            string name = Console.ReadLine();
            Console.Write("Level (Junior/MidLevel/Senior):");
            WorkerLevel level = Enum.Parse <WorkerLevel> (Console.ReadLine());
            Console.Write("Base Salary:");
            double baseSalary = double.Parse(Console.ReadLine());

            Deparment dep = new Deparment(deptName);
            Worker worker = new Worker(name, level, baseSalary, dep);

            Console.Write("How many contract to this worker?");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i<=n; i++)
            {
                Console.WriteLine("Enter #{i} contract data");
                Console.Write("Date (DD/MM/YYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Value per hour:");
                double valueperhour = double.Parse(Console.ReadLine());
                Console.Write("Duration(hour):");
                int hours = int.Parse(Console.ReadLine());


                HourContract contract = new HourContract(date, valueperhour, hours);
                worker.AddContranct(contract);
            }

            Console.WriteLine();
            Console.Write("Enter month and year to calculate income (MM/YYY):");
            string monthYear = Console.ReadLine();

            int month = int.Parse(monthYear.Substring(0, 2));
            int year = int.Parse(monthYear.Substring(3));
            Console.WriteLine("Name:" + worker.Name);
            Console.WriteLine("Department: " + worker.Deparment.Name);
            Console.WriteLine("Income for " + monthYear + ": " + worker.Income(year, month));
            
        }
    }
}
