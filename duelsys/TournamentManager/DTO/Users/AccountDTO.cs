namespace DTO.Users
{
    public class AccountDTO
    {
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string SurName { get; private set; }
        public string Role { get; private set; }
        public string Type { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string Salt { get; private set; }

        public AccountDTO(int id, string name, string surName, string role, string type, string email, string password, string salt)
        {
            ID = id;
            Name = name;
            SurName = surName;
            Role = role;
            Type = type;
            Email = email;
            Password = password;
            Salt = salt;
        }
    }
}
