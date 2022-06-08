using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTests.Mocks;
using BLL.Registries;
using BLL.Objects.Users;
using BLL.Encryption;
using System.Security.Authentication;

namespace UnitTests.RegistryTests
{
    [TestClass]
    public class LoginHandlerTest
    {
        [TestMethod]
        public void TestAuthenticateFormWithValidAccount()
        {
            LoginHandler handler = new LoginHandler(new MockLogin());

            Credentials credsAdmin = new Credentials() { Email = "lexdekort@gmail.com", Password = "1234" };
            Credentials credsStaff = new Credentials() { Email = "semstorms@gmail.com", Password = "efgh" };

            Account? admin = handler.AuthenticateForm(credsAdmin);
            Account? staff = handler.AuthenticateForm(credsStaff);

            Assert.IsNotNull(admin);
            Assert.IsNotNull(staff);
        }

        [TestMethod]
        public void TestAuthenticateFormWithInvalidAccount()
        {
            LoginHandler handler = new LoginHandler(new MockLogin());

            Credentials credsInvalid = new Credentials() { Email = "nickblom@gmail.com", Password = "5678" };

            Account? accountInvalid;

            Assert.ThrowsException<AuthenticationException>(() =>
                accountInvalid = handler.AuthenticateForm(credsInvalid)
            );
        }

        [TestMethod]
        public void TestAuthenticateFormWithInvalidCredentials()
        {
            LoginHandler handler = new LoginHandler(new MockLogin());

            Credentials credsInvalid1 = new Credentials() { Email = "lexdekort@gmail.com", Password = "5678" };
            Credentials credsInvalid2 = new Credentials() { Email = "lexkort@gmail.com", Password = "1234" };

            Account? accountInvalid1;
            Account? accountInvalid2;

            Assert.ThrowsException<AuthenticationException>(() =>
                accountInvalid1 = handler.AuthenticateForm(credsInvalid1)
            );
            Assert.ThrowsException<AuthenticationException>(() =>
                accountInvalid2 = handler.AuthenticateForm(credsInvalid2)
            );
        }
        [TestMethod]
        public void TestAuthenticateWebsiteWithValidAccount()
        {
            LoginHandler handler = new LoginHandler(new MockLogin());

            Credentials credsAdmin = new Credentials() { Email = "lexdekort@gmail.com", Password = "1234" };
            Credentials credsStaff = new Credentials() { Email = "semstorms@gmail.com", Password = "efgh" };
            Credentials credsPlayer = new Credentials() { Email = "emilia@gmail.com", Password = "abcd" };

            Account? admin = handler.AuthenticateWebsite(credsAdmin);
            Account? staff = handler.AuthenticateWebsite(credsStaff);
            Account? player = handler.AuthenticateWebsite(credsPlayer);

            Assert.IsNotNull(admin);
            Assert.IsNotNull(staff);
            Assert.IsNotNull(player);
        }

        [TestMethod]
        public void TestAuthenticateWebsiteWithInvalidCredentials()
        {
            LoginHandler handler = new LoginHandler(new MockLogin());

            Credentials credsInvalid1 = new Credentials() { Email = "lexdekort@gmail.com", Password = "5678" };
            Credentials credsInvalid2 = new Credentials() { Email = "emilia@email.org", Password = "1234" };

            Account? accountInvalid1;
            Account? accountInvalid2;

            Assert.ThrowsException<AuthenticationException>(() =>
                accountInvalid1 = handler.AuthenticateWebsite(credsInvalid1)
            );
            Assert.ThrowsException<AuthenticationException>(() =>
                accountInvalid2 = handler.AuthenticateWebsite(credsInvalid2)
            );
        }
    }
}
