namespace FinanceApp
{
    public abstract class UserBase : IUser
    {
        public delegate void TransactionAddedDelegate(object sender, EventArgs args);
        public abstract event TransactionAddedDelegate TransactionAdded;

        public string Name { get; private set; }
        public string Surname { get; private set; }

        public UserBase(string name, string surname)
        {
            this.Name = name;
            this.Surname = surname;
        }

        public abstract void AddTransaction(float transaction);

        public abstract void AddTransaction(string transaction);

        public abstract Statistics GetStatistics();
    }
}
