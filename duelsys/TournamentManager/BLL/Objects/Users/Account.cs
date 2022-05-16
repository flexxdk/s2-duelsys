namespace BLL.Objects.Users
{
    public abstract class Account
    {
        public int ID { get; protected set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }

        public Account(int id, string firstName, string lastName)
        {
            ID = id;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
