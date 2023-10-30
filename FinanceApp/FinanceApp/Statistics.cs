namespace FinanceApp
{
    public class Statistics
    {
        public float MaxIncome { get; private set; }
        public float MinIncome { get; private set; }
        public float MaxExpense { get; private set; }
        public float MinExpense { get; private set; }
        public float SumIncome { get; private set; }
        public float SumExpenses { get; private set; }
        public float CountTransaction { get; private set; }
        public float CountIncome { get; private set; }
        public float CountExpense { get; private set; }
        public float Balance
        {
            get { return this.SumIncome + this.SumExpenses; }
        }

        public Statistics()
        {
            this.CountTransaction = 0;
            this.CountIncome = 0;
            this.CountExpense = 0;
            this.MinIncome = float.MaxValue;
            this.MinExpense = float.MinValue;
            this.MaxIncome = float.MinValue;
            this.MaxExpense = float.MaxValue;
            this.SumIncome = 0;
            this.SumExpenses = 0;
        }

        public void AddTransaction(float amount)
        {
            this.CountTransaction++;

            if (amount > 0)
            {
                this.SumIncome += amount;
                this.CountIncome ++;
                this.MinIncome = Math.Min(this.MinIncome, amount);
                this.MaxIncome = Math.Max(this.MaxIncome, amount);
            }

            else if (amount < 0)
            {
                this.SumExpenses += amount;
                this.CountExpense ++;
                this.MinExpense = Math.Max(this.MinExpense, amount);
                this.MaxExpense = Math.Min(this.MaxExpense, amount);
            }
        }
    }
}

