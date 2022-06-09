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
            SportAssigner sportAssigner = new SportAssigner();
            int index = 0;

            ISport? sport = sportAssigner.RetrieveSport(index);

            Assert.IsNotNull(sport);
            Assert.IsInstanceOfType(sport, typeof(Badminton));
        }

        [TestMethod]
        public void TestRetrieveSportByIndexInvalidIndex()
        {
            SportAssigner sportAssigner = new SportAssigner();
            int index = 5;

            ISport? sport = sportAssigner.RetrieveSport(index);

            Assert.IsNull(sport);
        }

        [TestMethod]
        public void TestRetrieveSportByName()
        {
            SportAssigner sportAssigner = new SportAssigner();
            string name = "badminton";

            ISport? sport = sportAssigner.RetrieveSport(name);

            Assert.IsNotNull(sport);
            Assert.IsInstanceOfType(sport, typeof(Badminton));
        }

        [TestMethod]
        public void TestRetrieveSportByNameInvalidName()
        {
            SportAssigner sportAssigner = new SportAssigner();
            string name = "tennis";

            ISport? sport = sportAssigner.RetrieveSport(name);

            Assert.IsNull(sport);
        }

        [TestMethod]
        public void TestGetSportsAsISport()
        {
            SportAssigner sportAssigner = new SportAssigner();
            List<ISport?> sports = sportAssigner.GetSports();

            Assert.IsNotNull(sports);
            Assert.IsInstanceOfType(sports, typeof(List<ISport?>));
            Assert.AreEqual(1, sports.Count);
        }

        [TestMethod]
        public void TestGetSportsAsString()
        {
            SportAssigner sportAssigner = new SportAssigner();
            List<string> sports = sportAssigner.GetNames();

            Assert.IsNotNull(sports);
            Assert.IsInstanceOfType(sports, typeof(List<string>));
            Assert.AreEqual(1, sports.Count);
        }
    }
}
