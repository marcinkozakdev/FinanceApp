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
        public float Balance { get; private set; }
        public int CountTransaction { get; private set; }
        public int CountIncome { get; private set; }
        public int CountExpense { get; private set; }

        public Statistics()
        {
        }
    }
}
