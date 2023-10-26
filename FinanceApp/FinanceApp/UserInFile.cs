namespace FinanceApp
{
    public class UserInFile : UserBase
    {
        private const string fileName = "transactions.txt";

        private string name;
        private string surname;
        private string fullFileName;

        public override string Name
        {
            get
            {
                return $"{char.ToUpper(name[0])}{name.Substring(1, name.Length - 1).ToLower()}";
            }
            set
            {
                name = value;
            }
        }

        public override string Surname
        {
            get
            {
                return $"{char.ToUpper(surname[0])}{surname.Substring(1, surname.Length - 1).ToLower()}";
            }
            set
            {
                surname = value;
            }
        }

        public UserInFile(string name, string surname) : base(name, surname)
        {
            fullFileName = $"{name}_{surname}_{fileName}";
        }

        public override event TransactionAddedDelegate TransactionAdded;

        public override void AddTransaction(float transaction)
        {
            throw new NotImplementedException();
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


