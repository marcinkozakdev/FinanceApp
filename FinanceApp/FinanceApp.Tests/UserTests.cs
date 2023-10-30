namespace FinanceApp.Tests
{
    public class UserTests
    {
        [Fact]
        public void WhenAddedTransactionUserInMemory_ReturnCorrectStatistics()
        {
            // arrange
            var user = new UserInMemory("Name", "Surname");
            user.AddTransaction(-100);
            user.AddTransaction(-10);
            user.AddTransaction(100);
            user.AddTransaction(30);
            user.AddTransaction(25.2f);

            // act
            var result = user.GetStatistics();

            // assert
            Assert.Equal(Math.Round(100f, 2), Math.Round(result.MaxIncome, 2));
            Assert.Equal(Math.Round(25.2f,2), Math.Round(result.MinIncome,2));
            Assert.Equal(Math.Round(-10f,2), Math.Round(result.MinExpense,2));
            Assert.Equal(Math.Round(-100f, 2), Math.Round(result.MaxExpense, 2));
            Assert.Equal(Math.Round(2f, 2), Math.Round(result.CountExpense, 2));
            Assert.Equal(Math.Round(3f, 2), Math.Round(result.CountIncome, 2));
            Assert.Equal(Math.Round(5f, 2), Math.Round(result.CountTransaction, 2));
            Assert.Equal(Math.Round(155.2f, 2), Math.Round(result.SumIncome, 2));
            Assert.Equal(Math.Round(-110f, 2), Math.Round(result.SumExpenses, 2));
            Assert.Equal(Math.Round(45.2f, 2), Math.Round(result.Balance, 2));
        }

        [Fact]
        public void WhenAddedIncomeUserInMemory_ReturnCorrectStatistics()
        {
            // arrange
            var user = new UserInMemory("Name", "Surname");
            user.AddIncome(100);
            user.AddIncome(10);

            // act
            var result = user.GetStatistics();

            // assert
            Assert.Equal(Math.Round(100f, 2), Math.Round(result.MaxIncome, 2));
            Assert.Equal(Math.Round(10f, 2), Math.Round(result.MinIncome, 2));
        }

        [Fact]
        public void WhenAddedExpenseUserInMemory_ReturnCorrectStatistics()
        {
            // arrange
            var user = new UserInMemory("Name", "Surname");
            user.AddExpense(-100);
            user.AddExpense(-10);

            // act
            var result = user.GetStatistics();

            //
            Assert.Equal(Math.Round(-100f, 2), Math.Round(result.MaxExpense, 2));
            Assert.Equal(Math.Round(-10f, 2), Math.Round(result.MinExpense, 2));
        }
    }
}