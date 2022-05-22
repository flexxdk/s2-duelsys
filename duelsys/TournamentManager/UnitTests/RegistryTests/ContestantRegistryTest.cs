using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

using BLL.Objects.Users;
using BLL.Registries;
using UnitTests.Mocks;

namespace UnitTests.RegistryTests
{
    [TestClass]
    public class ContestantRegistryTest
    {
        [TestMethod]
        public void TestGetContestant()
        {
            ContestantRegistry registry = new ContestantRegistry(new MockContestant());
            int tournamentID = 1;
            int contestantID = 1;

            Contestant? contestant = registry.GetContestant(tournamentID, contestantID);

            Assert.IsNotNull(contestant);
            Assert.AreEqual(tournamentID, contestant.TournamentID);
            Assert.AreEqual(contestantID, contestant.ID);
        }

        [TestMethod]
        public void TestGetContestantWithInvalidIDs()
        {
            ContestantRegistry registry = new ContestantRegistry(new MockContestant());
            int tournamentID = 5;
            int contestantID = 5;

            Contestant? contestant = registry.GetContestant(tournamentID, contestantID);

            Assert.IsNull(contestant);
        }

        [TestMethod]
        public void TestGetRegistrants()
        {
            ContestantRegistry registry = new ContestantRegistry(new MockContestant());
            int tournamentID = 1;

            List<Contestant> contestants = registry.GetRegistrants(tournamentID).ToList();

            Assert.IsNotNull(contestants);
            Assert.AreNotEqual(0, contestants.Count);
            Assert.AreEqual(tournamentID, contestants.First().TournamentID);
        }

        [TestMethod]
        public void TestGetRegistrantsOfNonexistentTournament()
        {
            ContestantRegistry registry = new ContestantRegistry(new MockContestant());
            int tournamentID = 7;

            List<Contestant> contestants = registry.GetRegistrants(tournamentID).ToList();

            Assert.IsNotNull(contestants);
            Assert.AreEqual(0, contestants.Count);
        }

        [TestMethod]
        public void TestRegisterNewUser()
        {
            ContestantRegistry registry = new ContestantRegistry(new MockContestant());
            int tournamentID = 1;
            int userID = 5;

            bool result = registry.Register(userID, tournamentID);
            
            Assert.IsTrue(result);
            Assert.AreEqual(userID, registry.GetRegistrants(tournamentID).Last().ID);
        }

        [TestMethod]
        public void TestRegisterAlreadyRegisteredUser()
        {
            ContestantRegistry registry = new ContestantRegistry(new MockContestant());
            int tournamentID = 1;
            int userID = 3;

            bool result = registry.Register(userID, tournamentID);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestRegisterNonexistentUser()
        {
            ContestantRegistry registry = new ContestantRegistry(new MockContestant());
            int tournamentID = 1;
            int userID = 6;

            bool result = registry.Register(userID, tournamentID);

            Assert.IsFalse(result);
            Assert.AreNotEqual(userID, registry.GetRegistrants(tournamentID).Last().ID);
        }

        [TestMethod]
        public void TestDeregisterContestant()
        {
            ContestantRegistry registry = new ContestantRegistry(new MockContestant());
            int tournamentID = 1;
            int userID = 3;

            bool result = registry.Deregister(userID, tournamentID);

            Assert.IsTrue(result);
            Assert.IsNull(registry.GetContestant(tournamentID, userID));
        }

        [TestMethod]
        public void TestDeregisteredNonregisteredUser()
        {
            ContestantRegistry registry = new ContestantRegistry(new MockContestant());
            int tournamentID = 1;
            int userID = 5;

            bool result = registry.Deregister(userID, tournamentID);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestDeregisterNonexistentContestant()
        {
            ContestantRegistry registry = new ContestantRegistry(new MockContestant());
            int tournamentID = 1;
            int userID = 6;

            bool result = registry.Deregister(userID, tournamentID);

            Assert.IsFalse(result);
        }
    }
}
