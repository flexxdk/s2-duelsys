using Microsoft.VisualStudio.TestTools.UnitTesting;

using BLL.Encryption;

namespace UnitTests
{
    [TestClass]
    public class TestEncryptor
    {
        [TestMethod]
        public void TestHash()
        {
            Encryptor encryptor = new Encryptor();
            string password = "Hello World";

            SaltKey hashed = encryptor.Hash(password);

            Assert.IsNotNull(hashed);
        }

        [TestMethod]
        public void TestVerifyWithCorrectPassword()
        {
            Encryptor encryptor = new Encryptor();
            string password = "Hello World!";

            SaltKey hashed = encryptor.Hash(password);
            bool result = encryptor.Verify(password, hashed.Key, hashed.Salt);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestVerifyWithIncorrectPassword()
        {
            Encryptor encryptor = new Encryptor();
            string password = "Hello World!";
            string differentPassword = "Also Hello!";

            SaltKey hashed = encryptor.Hash(password);
            bool result = encryptor.Verify(differentPassword, hashed.Key, hashed.Salt);

            Assert.IsFalse(result);
        }
    }
}
