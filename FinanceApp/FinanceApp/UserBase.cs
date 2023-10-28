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
                Console.WriteLine("\n==============================================");
                Console.WriteLine($"\t\tSUMMARY");
                Console.WriteLine("==============================================");

                if(statistics.Balance > 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine($"\tBalance: {statistics.Balance:N2} zł");
                    Console.ResetColor();
                }
                else if(statistics.Balance <0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"\tBalance: {statistics.Balance:N2} zł");
                    Console.ResetColor();
                }
                else
                {
                Console.WriteLine($"Balance: {statistics.Balance:N2} zł");
                }

                Console.WriteLine("==============================================");
                Console.WriteLine($"\tTransaction Count: {statistics.CountTransaction}");
                Console.WriteLine($"\tIncome Count: {statistics.CountIncome}");
                Console.WriteLine($"\tExpenses Count: {statistics.CountExpense}");
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine($"\tTotal Income: {statistics.CountIncome:N2} zł");
                Console.WriteLine($"\tTotal Expenses: {statistics.CountExpense:N2} zł");
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine($"\tMin Income: {statistics.MinIncome:N2} zł");
                Console.WriteLine($"\tMax Income: {statistics.MaxIncome:N2} zł");
                Console.WriteLine($"\tMin Expense: {statistics.MaxExpense:N2} zł");
                Console.WriteLine($"\tMax Expense: {statistics.MinExpense:N2} zł");
                Console.WriteLine("==============================================");
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
                throw new ArgumentException("\tThis is not a number!");
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
                throw new ArgumentException("\tThis is not a number!\n");
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
                throw new ArgumentException("\tThis is not a number!\n");
            }
        }
    }
}
