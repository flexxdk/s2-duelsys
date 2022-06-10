using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL.Objects.TournamentSystem;
using System.Collections.Generic;
using BLL.Objects.Assigners;

namespace UnitTests.TournamentSystemTests
{
    [TestClass]
    public class TournamentSystemAssignerTest
    {
        [TestMethod]
        public void TestRetrieveSystemByIndex()
        {
            TournamentSystemAssigner systemAssigner = new TournamentSystemAssigner();
            int index = 0;

            ITournamentSystem? roundRobin = systemAssigner.Retrieve(index);

            Assert.IsNotNull(roundRobin);
            Assert.IsInstanceOfType(roundRobin, typeof(RoundRobin));

            index = 1;

            ITournamentSystem? singleElimination = systemAssigner.Retrieve(index);

            Assert.IsNotNull(singleElimination);
            Assert.IsInstanceOfType(singleElimination, typeof(SingleElimination));
        }

        [TestMethod]
        public void TestRetrieveSystemByIndexInvalidIndex()
        {
            TournamentSystemAssigner systemAssigner = new TournamentSystemAssigner();
            int index = 5;

            ITournamentSystem? system = systemAssigner.Retrieve(index);

            Assert.IsNull(system);
        }

        [TestMethod]
        public void TestRetrieveSystemByName()
        {
            TournamentSystemAssigner systemAssigner = new TournamentSystemAssigner();
            string name = "singleelimination";

            ITournamentSystem? singleElimination = systemAssigner.Retrieve(name);

            Assert.IsNotNull(singleElimination);
            Assert.IsInstanceOfType(singleElimination, typeof(SingleElimination));
        }

        [TestMethod]
        public void TestRetrieveSystemByNameInvalidName()
        {
            TournamentSystemAssigner systemAssigner = new TournamentSystemAssigner();
            string name = "banana";

            ITournamentSystem? sport = systemAssigner.Retrieve(name);

            Assert.IsNull(sport);
        }

        [TestMethod]
        public void TestGetSystemsAsITournamentSystem()
        {
            TournamentSystemAssigner systemAssigner = new TournamentSystemAssigner();
            List<ITournamentSystem?> systems = systemAssigner.GetObjects();

            Assert.IsNotNull(systems);
            Assert.IsInstanceOfType(systems, typeof(List<ITournamentSystem?>));
            Assert.AreEqual(2, systems.Count);
        }

        [TestMethod]
        public void TestGetSystemsAsString()
        {
            TournamentSystemAssigner systemAssigner = new TournamentSystemAssigner();
            List<string> systems = systemAssigner.GetNames();

            Assert.IsNotNull(systems);
            Assert.IsInstanceOfType(systems, typeof(List<string>));
            Assert.AreEqual(2, systems.Count);
        }
    }
}
