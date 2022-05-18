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
    }
}