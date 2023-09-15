using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{


    public interface IHasGuid
    {
        Guid Guid { get; }
    }


    public class Operation : IHasGuid
    {
        public Guid Guid { get; }
        public string ProcessName { get; }
        public DateTime DateTime { get; }

        public Operation(string processName)
        {
            Guid = Guid.NewGuid();
            ProcessName = processName;
            DateTime = DateTime.Now;
        }
    }


    public class Person : IHasGuid
    {
        public Guid Guid { get; }
        public string Name { get; }
        public string Surname { get; }
        public int Age { get; }
        public string Position { get; }
        public decimal Salary { get; }

        public Person(string name, string surname, int age, string position, decimal salary)
        {
            Guid = Guid.NewGuid();
            Name = name;
            Surname = surname;
            Age = age;
            Position = position;
            Salary = salary;
        }
    }


    public class CEO : Person
    {
        public CEO(string name, string surname, int age, string position, decimal salary)
            : base(name, surname, age, position, salary)
        {
        }

        public void Control() { }
        public void Organize() { }
        public void MakeMeeting() { }
        public void DecreasePercentage(decimal percent) { }
    }


    public class Worker : Person
    {
        public DateTime StartTime { get; }
        public DateTime EndTime { get; }
        public List<Operation> Operations { get; }

        public Worker(string name, string surname, int age, string position, decimal salary,
                      DateTime startTime, DateTime endTime)
            : base(name, surname, age, position, salary)
        {
            StartTime = startTime;
            EndTime = endTime;
            Operations = new List<Operation>();
        }

        public void AddOperation(Operation operation)
        {
            Operations.Add(operation);
        }
    }


    public class Manager : Person
    {
        public Manager(string name, string surname, int age, string position, decimal salary)
            : base(name, surname, age, position, salary)
        {
        }

        public void Organize() { }
        public void CalculateSalaries() { }
    }


    public class Client : Person
    {
        public string LiveAddress { get; }
        public string WorkAddress { get; }
        public List<Credit> Credits { get; }

        public Client(string name, string surname, int age, string liveAddress, string workAddress,
                      decimal salary)
            : base(name, surname, age, "Client", salary)
        {
            LiveAddress = liveAddress;
            WorkAddress = workAddress;
            Credits = new List<Credit>();
        }
    }


    public class Credit : IHasGuid
    {
        public Guid Guid { get; }
        public Client Client { get; }
        public decimal Amount { get; }
        public decimal Percent { get; }
        public int Months { get; }
        public decimal CalculatePercent { get; }
        public decimal Payment { get; }

        public Credit(Client client, decimal amount, decimal percent, int months)
        {
            Guid = Guid.NewGuid();
            Client = client;
            Amount = amount;
            Percent = percent;
            Months = months;
            CalculatePercent = CalculateInterest();
            Payment = CalculatePayment();
        }

        private decimal CalculateInterest()
        {
            return Amount * Percent / 100;
        }

        private decimal CalculatePayment()
        {
            decimal interest = CalculateInterest();
            return (Amount + interest) / Months;
        }
    }


    public class Bank
    {
        public string Name { get; }
        public decimal Budget { get; private set; }
        public decimal Profit { get; private set; }
        public CEO CEO { get; }
        public List<Worker> Workers { get; }
        public List<Manager> Managers { get; }
        public List<Client> Clients { get; }

        public Bank(string name, decimal initialBudget)
        {
            Name = name;
            Budget = initialBudget;
            Profit = 0;
            CEO = new CEO("John", "Doe", 45, "CEO", 100000);
            Workers = new List<Worker>();
            Managers = new List<Manager>();
            Clients = new List<Client>();
        }

        public void CalculateProfit()
        {
            
        }

        public void ShowClientCredit(string fullname)
        {
          
        }

        public void PayCredit(Client client, decimal money)
        {
            
        }

        public void ShowAllCredit()
        {
            
        }
    }

}
