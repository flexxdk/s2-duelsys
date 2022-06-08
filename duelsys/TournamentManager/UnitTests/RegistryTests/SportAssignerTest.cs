using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL.Registries;
using BLL.Objects.Sports;
using System.Collections.Generic;

namespace UnitTests.RegistryTests
{
    [TestClass]
    public class SportAssignerTest
    {
        [TestMethod]
        public void TestRetrieveSportByIndex()
        {
            int index = 0;

            ISport? sport = SportAssigner.RetrieveSport(index);

            Assert.IsNotNull(sport);
            Assert.IsInstanceOfType(sport, typeof(Badminton));
        }

        [TestMethod]
        public void TestRetrieveSportByIndexInvalidIndex()
        {
            int index = 5;

            ISport? sport = SportAssigner.RetrieveSport(index);

            Assert.IsNull(sport);
        }

        [TestMethod]
        public void TestRetrieveSportByName()
        {
            string name = "badminton";

            ISport? sport = SportAssigner.RetrieveSport(name);

            Assert.IsNotNull(sport);
            Assert.IsInstanceOfType(sport, typeof(Badminton));
        }

        [TestMethod]
        public void TestRetrieveSportByNameInvalidName()
        {
            string name = "tennis";

            ISport? sport = SportAssigner.RetrieveSport(name);

            Assert.IsNull(sport);
        }

        [TestMethod]
        public void TestGetSportsAsISport()
        {
            List<ISport?> sports = SportAssigner.GetSports();

            Assert.IsNotNull(sports);
            Assert.IsInstanceOfType(sports, typeof(List<ISport?>));
            Assert.AreEqual(1, sports.Count);
        }

        [TestMethod]
        public void TestGetSportsAsString()
        {
            List<string> sports = SportAssigner.GetNames();

            Assert.IsNotNull(sports);
            Assert.IsInstanceOfType(sports, typeof(List<string>));
            Assert.AreEqual(1, sports.Count);
        }
    }
}
