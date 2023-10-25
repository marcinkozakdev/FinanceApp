namespace FinanceApp
{
    public class UserInMemory : UserBase
    {
        List<float> transactions = new List<float>();

        public override event TransactionAddedDelegate TransactionAdded;

        public UserInMemory(string name, string surname) : base(name, surname) { }

        public override void AddTransaction(float amount)
        {
            if (amount > 0 && amount <= 100)
            {
                this.transactions.Add(amount);

                if (TransactionAdded != null)
                {
                    TransactionAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new Exception($"{amount}is invalid value.");
            }
        }

        public override void AddTransaction(string transaction)
        {
            throw new NotImplementedException();
        }

        public override Statistics GetStatistics()
        {
            throw new NotImplementedException();
        }
    }
}
