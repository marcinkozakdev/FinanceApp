namespace FinanceApp
{
    public interface IUser
    {
        string Name { get; }
        string Surname { get; }

        void AddTransaction(float transaction);
        void AddTransaction(string transaction);

        Statistics GetStatistics();
    }
}
