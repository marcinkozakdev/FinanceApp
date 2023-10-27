using System.Diagnostics;

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

        public override void AddIncome(float amount)
        {
            using (var writer = File.AppendText($"{fullFileName}"))
            {
                writer.WriteLine(amount);

                if (TransactionAdded != null)
                {
                    TransactionAdded(this, new EventArgs());
                }
            }
        }


        public override void AddExpense(float amount)
        {
            using (var writer = File.AppendText(fullFileName))
            {
                writer.WriteLine(amount);
            }
            if (TransactionAdded != null)
            {
                TransactionAdded(this, new EventArgs());
            }
        }

        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();

            if (File.Exists(fileName))
            {
                using (var reader = File.OpenText(fullFileName))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        var amount = float.Parse(line);
                        statistics.AddTransaction(amount);
                        line = reader.ReadLine();
                    }
                }
            }
            return statistics;
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
    }

}


