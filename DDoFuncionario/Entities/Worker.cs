using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDoFuncionario.Entities.Enums;

namespace DDoFuncionario.Entities
{
    class Worker
    {
        public string Name { get; set; }
        public WorkerLevel Level { get; set; }
        public double BaseSalary { get; set; }
        public Deparment Deparment { get; set; }
        public List<HourContract> contracts { get; set; } = new List<HourContract>();

        public Worker()
        {
        }

        public Worker(string name, WorkerLevel level, double basesalary, Deparment deparment)
        {
            Name = name;
            Level = level;
            BaseSalary = basesalary;
            Deparment = deparment;
        }
        public void AddContranct (HourContract contract)
        {
            contracts.Add(contract);
        }
        public void RemoveContranct(HourContract contract)
        {
            contracts.Remove(contract);
        }
        public double Income (int year,int month)
        {// o ganho é uma suma de horas de contratos trabalhados em um determinado ano e mes
            //para calcular esse ganho temos que percorrer a lista de das hourcontrct a acumulando a suma de 
            //decimal essos contratos

            double sum = BaseSalary;
            foreach(HourContract contract in contracts)
            {
                if(contract.Date.Year == year && contract.Date.Month == month)
                {
                    sum += contract.TotalValue();
                }
            }
            return sum;

        }
    }
}
