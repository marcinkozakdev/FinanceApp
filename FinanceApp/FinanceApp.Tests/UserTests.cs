namespace FinanceApp.Tests
{
    public class UserTests
    {
        [Fact]
        public void WhenAddedTransactions_ReturnCorrectBalance()
        {
            // arrange
            var user = new UserInMemory("Marcin", "Kozak");
            user.AddTransaction(-100);
            user.AddTransaction(-10);
            user.AddTransaction(100);
            user.AddTransaction(30);
            user.AddTransaction(25.2f);
            
            // act
            
            var result = user.GetStatistics();

            //
            Assert.Equal(Math.Round(45.2f,2), Math.Round(result.Balance,2));
        }

        [Fact]
        public void WhenAddedTransaction_ReturnCorrectStatistics()
        {
            // arrange
            var user = new UserInMemory("Marcin", "Kozak");
            user.AddTransaction(-100);
            user.AddTransaction(-10);
            user.AddTransaction(100);
            user.AddTransaction(30);
            user.AddTransaction(25.2f);

            // act

            var result = user.GetStatistics();

            //
            Assert.Equal(100, result.MaxIncome);
            Assert.Equal(Math.Round(25.2f,2), Math.Round(result.MinIncome,2));
        }
    }
}