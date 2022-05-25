namespace BLL.Encryption 
{ 
    public class SaltKey
    {
        public string Salt { get; private set; }
        public string Key { get; private set; }

        public SaltKey(string salt, string key) 
        {
            Salt = salt;
            Key = key;
        }
    }
}
