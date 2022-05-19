using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

using BLL.Objects.Users;
using BLL.Registries;
using BLL.Enums;
using UnitTests.Mocks;
using System.ComponentModel.DataAnnotations;
using System;

namespace UnitTests.RegistryTests
{
    [TestClass]
    public class UserRegistyTest
    {
        [TestMethod]
        public void TestLoadUsers()
        {
            UserRegistry userRegistry = new UserRegistry(new MockUsers());

            Assert.AreEqual(4, userRegistry.GetAll().Count);
            Assert.IsInstanceOfType(userRegistry.GetAll().ToList(), typeof(List<User>));
        }

        [TestMethod]
        public void TestGetUser()
        {
            UserRegistry userRegistry = new UserRegistry(new MockUsers());

            User? user = userRegistry.GetByID(1);

            Assert.IsNotNull(user);
        }

        [TestMethod]
        public void TestGetNonexistentUser()
        {
            UserRegistry userRegistry = new UserRegistry(new MockUsers());

            User? user = userRegistry.GetByID(5);

            Assert.IsNull(user);
        }

        [TestMethod]
        public void TestRegisterNewAccount()
        {
            UserRegistry userRegistry = new UserRegistry(new MockUsers());
            string firstName = "Fontys";
            string lastName = "Man";
            UserRole role = UserRole.Administrator;
            string email = "fontys_man@fontys.nl";
            string password = "fontysman";

            bool result = userRegistry.RegisterAccount(new User()
            {
                FirstName = firstName,
                LastName = lastName,
                Role = role,
                Email = email,
                Password = password
            });

            Assert.IsTrue(result);
            Assert.AreEqual(5, userRegistry.GetAll().Last().ID);
            Assert.AreEqual(email, userRegistry.GetAll().Last().Email);
        }

        [TestMethod]
        public void TestRegisterNewAccountWithNonUniqueEmail()
        {
            UserRegistry userRegistry = new UserRegistry(new MockUsers());
            string firstName = "Fontys";
            string lastName = "Man";
            UserRole role = UserRole.Administrator;
            string email = "devops@gmail.com";
            string password = "fontysman";

            bool result = userRegistry.RegisterAccount(new User()
            {
                FirstName = firstName,
                LastName = lastName,
                Role = role,
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
            string email = "";
            string password = "";

            Assert.ThrowsException<ValidationException>(() => 
                userRegistry.RegisterAccount(new User()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Role = role,
                    Email = email,
                    Password = password
                }) 
            );
        }
    }
}