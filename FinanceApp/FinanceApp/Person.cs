namespace FinanceApp
{
    public class Person
    {
        public virtual string Name { get; set; }
        public virtual string Surname { get; set; }

        public Person(string name, string surname)
        {
            this.Name = name;
            this.Surname = surname;
        }
    }
}
