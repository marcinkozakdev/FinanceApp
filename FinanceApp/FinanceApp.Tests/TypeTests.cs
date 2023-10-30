namespace FinanceApp.Tests
{
    public class TypeTests
    {
        [Fact]
        public void GetUserReturnsDifferentObjects()
        {
            var user1 = GetUser("Marcin", "Kozak");
            var user2 = GetUser("Kozak", "Marcin");

            Assert.NotSame(user1, user2);
            Assert.False(user1.Equals(user2));
            Assert.False(Object.ReferenceEquals(user1, user2));
        }

        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            var user1 = GetUser("Marcin", "Kozak");
            var user2 = user1;

            Assert.Same(user1, user2);
            Assert.True(user1.Equals(user2));
            Assert.True(Object.ReferenceEquals(user1, user2));
        }

        private UserInMemory GetUser(string name, string surname)
        {
            return new UserInMemory(name, surname);
        }
    }
}
