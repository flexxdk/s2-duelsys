using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL.Objects.Sports;
using System.Collections.Generic;
using BLL.Objects.Assigners;

namespace UnitTests.SportsTests
{
    [TestClass]
    public class SportAssignerTest
    {
        [TestMethod]
        public void TestRetrieveSportByIndex()
        {
            SportAssigner sportAssigner = new SportAssigner();
            int index = 0;

            ISport? sport = sportAssigner.Retrieve(index);

            Assert.IsNotNull(sport);
            Assert.IsInstanceOfType(sport, typeof(Badminton));
        }

        [TestMethod]
        public void TestRetrieveSportByIndexInvalidIndex()
        {
            SportAssigner sportAssigner = new SportAssigner();
            int index = 5;

            ISport? sport = sportAssigner.Retrieve(index);

            Assert.IsNull(sport);
        }

        [TestMethod]
        public void TestRetrieveSportByName()
        {
            SportAssigner sportAssigner = new SportAssigner();
            string name = "badminton";

            ISport? sport = sportAssigner.Retrieve(name);

            Assert.IsNotNull(sport);
            Assert.IsInstanceOfType(sport, typeof(Badminton));
        }

        [TestMethod]
        public void TestRetrieveSportByNameInvalidName()
        {
            SportAssigner sportAssigner = new SportAssigner();
            string name = "tennis";

            ISport? sport = sportAssigner.Retrieve(name);

            Assert.IsNull(sport);
        }

        [TestMethod]
        public void TestGetSportsAsISport()
        {
            SportAssigner sportAssigner = new SportAssigner();
            List<ISport?> sports = sportAssigner.GetObjects();

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
