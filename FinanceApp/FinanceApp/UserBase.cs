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

        public abstract void AddTransaction(float transaction);

        public abstract void AddTransaction(string transaction);

        public abstract Statistics GetStatistics();
    }
}
