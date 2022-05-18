using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

using BLL.Objects.Users;
using BLL.Registries;
using UnitTests.Mocks;

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
        public void TestRegisterNewUser()
        {
            UserRegistry userRegistry = new UserRegistry(new MockUsers());


        }
    }
}