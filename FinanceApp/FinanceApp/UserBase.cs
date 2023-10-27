using System.ComponentModel.DataAnnotations;
using System.Transactions;

namespace FinanceApp
{
    public abstract class UserBase : Person, IUser
    {
        public delegate void TransactionAddedDelegate(object sender, EventArgs args);
        public abstract event TransactionAddedDelegate TransactionAdded;

        public override string Name { get;  set; }
        public override string Surname { get;  set; }

        public UserBase(string name, string surname) : base(name, surname)
        {
            this.Name = name;
            this.Surname = surname;
        }

        public abstract void AddTransaction(float amount);
        public abstract void AddIncome(float amount);
        public abstract void AddExpense(float amount);

        public abstract Statistics GetStatistics();

        public void ShowStatistics()
        {
            var statistics = GetStatistics();
            if(statistics.CountTransaction !=0)
            {
                Console.WriteLine($"SUMMARY");
                Console.WriteLine("==============================================");
                Console.WriteLine($"Transaction Count: {statistics.CountTransaction}");
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine($"Total Income: {statistics.CountIncome:N2} zł");
                Console.WriteLine($"Total Expenses: {statistics.CountExpense:N2} zł");
                Console.WriteLine($"Balance: {statistics.Balance:N2} zł");
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine($"Min Income: {statistics.MinIncome:N2} zł");
                Console.WriteLine($"Max Income: {statistics.MaxIncome:N2} zł");
                Console.WriteLine($"Min Expense: {statistics.MaxExpense:N2} zł");
                Console.WriteLine($"Max Expense: {statistics.MinExpense:N2} zł");
                Console.WriteLine("----------------------------------------------");
            }
        }

        public void AddIncome(string amount)
        {
            if (float.TryParse(amount, out float result))
            {
                this.AddIncome(result);
            }
            else
            {
                throw new Exception("This is not a number!");
            }
        }

        public void AddExpense(string amount)
        {
            if (float.TryParse(amount, out float result))
            {
                this.AddExpense(result);
            }
            else
            {
                throw new Exception("This is not a number!");
            }
        }

        public void AddTransaction(string amount)
        {
            if (float.TryParse(amount, out float result))
            {
                this.AddIncome(result);
            }
            else
            {
                throw new Exception("This is not a number!");
            }
        }
    }
}
