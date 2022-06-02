using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

using BLL.Objects.Users;
using BLL.Registries;
using BLL.Enums;
using UnitTests.Mocks;
using System.ComponentModel.DataAnnotations;

namespace UnitTests.RegistryTests
{
    [TestClass]
    public class UserRegistyTest
    {
        [TestMethod]
        public void TestGetUser()
        {
            UserRegistry userRegistry = new UserRegistry(new MockUsers());

            Account? user = userRegistry.GetByID(1);

            Assert.IsNotNull(user);
        }

        [TestMethod]
        public void TestGetNonexistentUser()
        {
            UserRegistry userRegistry = new UserRegistry(new MockUsers());

            Account? user = userRegistry.GetByID(5);

            Assert.IsNull(user);
        }

        [TestMethod]
        public void TestRegisterNewSoloAccount()
        {
            UserRegistry userRegistry = new UserRegistry(new MockUsers());
            string firstName = "Fontys";
            string lastName = "Man";
            UserRole role = UserRole.Administrator;
            TeamType type = TeamType.Solo;
            string email = "fontys_man@fontys.nl";
            string password = "fontysman";

            bool result = userRegistry.RegisterAccount(new Account()
            {
                Name = firstName,
                SurName = lastName,
                Role = role,
                Type = type,
                Email = email,
                Password = password
            });

            Assert.IsTrue(result);
            Assert.AreEqual(5, userRegistry.GetByID(5)!.ID);
            Assert.AreEqual(email, userRegistry.GetByID(5).Email);
            Assert.AreEqual(TeamType.Solo, userRegistry.GetByID(5).Type);
        }

        [TestMethod]
        public void TestRegisterNewTeamAccount()
        {
            UserRegistry userRegistry = new UserRegistry(new MockUsers());
            string firstName = "Fontys";
            string lastName = "Man";
            UserRole role = UserRole.Administrator;
            TeamType type = TeamType.Team;
            string email = "fontys_man@fontys.nl";
            string password = "fontysman";

            bool result = userRegistry.RegisterAccount(new Account()
            {
                Name = firstName,
                SurName = lastName,
                Role = role,
                Type = type,
                Email = email,
                Password = password
            });

            Assert.IsTrue(result);
            Assert.AreEqual(5, userRegistry.GetByID(5)!.ID);
            Assert.AreEqual(email, userRegistry.GetByID(5).Email);
            Assert.AreEqual(TeamType.Team, userRegistry.GetByID(5).Type);
        }

        [TestMethod]
        public void TestRegisterNewAccountWithNonUniqueEmail()
        {
            UserRegistry userRegistry = new UserRegistry(new MockUsers());
            string firstName = "Fontys";
            string lastName = "Man";
            UserRole role = UserRole.Administrator;
            TeamType type = TeamType.Solo;
            string email = "devops@gmail.com";
            string password = "fontysman";

            bool result = userRegistry.RegisterAccount(new Account()
            {
                Name = firstName,
                SurName = lastName,
                Role = role,
                Type = type,
                Email = email,
                Password = password
            });

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestRegisterNewAccountWithInvalidInput()
        {
            UserRegistry userRegistry = new UserRegistry(new MockUsers());
            string firstName = "";
            string lastName = "";
            UserRole role = UserRole.Administrator;
            TeamType type = TeamType.Solo;
            string email = "";
            string password = "";

            Assert.ThrowsException<ValidationException>(() => 
                userRegistry.RegisterAccount(new Account()
                {
                    Name = firstName,
                    SurName = lastName,
                    Role = role,
                    Type = type,
                    Email = email,
                    Password = password
                }) 
            );
        }
    }
}