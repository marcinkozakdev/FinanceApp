namespace FinanceApp
{
    public class UserInMemory : UserBase
    {
        List<float> amounts = new List<float>();
        private string name;
        private string surname;

        public override event TransactionAddedDelegate TransactionAdded;

        public override string Name
        {
            get
            {
                return $"{char.ToUpper(name[0])}{name.Substring(1, name.Length - 1).ToLower()}";
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    name = value;
                }
            }
        }
        public override string Surname
        {
            get
            {
                return $"{char.ToUpper(surname[0])}.";
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    surname = value;
                }
            }
        }

        public UserInMemory(string name, string surname) : base(name, surname)
        {
        }

        public override void AddTransaction(float amount)
        {
            if (amount > 0)
            {
                AddIncome(amount);
            }
            else if (amount < 0)
            {
                AddTransaction(amount);
            }
            else
            {
                throw new Exception($"{amount} is invalid value.");
            }
        }

        public override void AddIncome(float amount)
        {
            amounts.Add(amount);
            if (TransactionAdded != null)
            {
                TransactionAdded(this, new EventArgs());
            }
        }

        public override void AddExpense(float amount)
        {
            amounts.Add(amount);
            if (TransactionAdded != null)
            {
                TransactionAdded(this, new EventArgs());
            }

        }

        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();

            foreach (var amount in this.amounts)
            {
                statistics.AddTransaction(amount);
            }
            return statistics;
        }
    }
}
