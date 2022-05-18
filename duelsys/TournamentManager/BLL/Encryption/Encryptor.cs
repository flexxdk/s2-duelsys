using System.Security.Cryptography;

namespace BLL.Encryption
{
    public class Encryptor
    {
        public Encryptor() { }

        public SaltKey Hash(string password)
        {
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, 32))
            {
                string salt = ConvertToString(pbkdf2.Salt);
                string key = ConvertToString(pbkdf2.GetBytes(32));
                return new SaltKey(salt, key);
            }
        }

        public bool Verify(string password, string dbkey, string dbsalt)
        {
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, ConvertToByte(dbsalt)))
            {
                byte[] key = pbkdf2.GetBytes(32);
                return key.SequenceEqual(ConvertToByte(dbkey));
            }
        }

        private string ConvertToString(byte[] value)
        {
            return Convert.ToBase64String(value);
        }

        private byte[] ConvertToByte(string value)
        {
            return Convert.FromBase64String(value);
        }
    }
}
