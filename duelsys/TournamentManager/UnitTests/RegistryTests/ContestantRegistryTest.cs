using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

using BLL.Objects.Sports;
using BLL.Enums;
using BLL.Objects.Users;
using BLL.Registries;
using UnitTests.Mocks;
using System;
using BLL.Objects;

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

            List<Contestant> contestants = registry.GetContestants(tournamentID).ToList();

            Assert.IsNotNull(contestants);
            Assert.AreNotEqual(0, contestants.Count);
            Assert.AreEqual(tournamentID, contestants.First().TournamentID);
        }

        [TestMethod]
        public void TestGetContestantsOfNonexistentTournament()
        {
            ContestantRegistry registry = new ContestantRegistry(new MockContestant());
            int tournamentID = 7;

            List<Contestant> contestants = registry.GetContestants(tournamentID).ToList();

            Assert.IsNotNull(contestants);
            Assert.AreEqual(0, contestants.Count);
        }

        [TestMethod]
        public void TestRegisterNewContestant()
        {
            ContestantRegistry registry = new ContestantRegistry(new MockContestant());
            int userID = 5;
            string userType = "Solo";

            Tournament tournament = new Tournament()
            {
                ID = 1,
                Title = "Average-Minton",
                Description = "It's also badminton!",
                Sport = new Badminton(),
                City = "Eindhoven",
                Address = "Eindhovense Straat 1",
                MinContestants = 8,
                MaxContestants = 14,
                StartDate = DateTime.Now.AddDays(8).Date,
                EndDate = DateTime.Now.AddDays(16).Date,
                Status = TournamentStatus.Planned,
                System = TournamentSystem.RoundRobin
            };

            bool result = registry.Register(userID, userType, tournament);
            
            Assert.IsTrue(result);
            Assert.AreEqual(userID, registry.GetContestants(tournament.ID).Last().ID);
        }

        [TestMethod]
        public void TestRegisterAlreadyRegisteredContestant()
        {
            ContestantRegistry registry = new ContestantRegistry(new MockContestant());
            int userID = 3;
            string userType = "Solo";

            Tournament tournament = new Tournament()
            {
                ID = 1,
                Title = "Average-Minton",
                Description = "It's also badminton!",
                Sport = new Badminton(),
                City = "Eindhoven",
                Address = "Eindhovense Straat 1",
                MinContestants = 8,
                MaxContestants = 14,
                StartDate = DateTime.Now.AddDays(8).Date,
                EndDate = DateTime.Now.AddDays(16).Date,
                Status = TournamentStatus.Planned,
                System = TournamentSystem.RoundRobin
            };

            bool result = registry.Register(userID, userType, tournament);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestRegisterUserOfDifferentTeamType()
        {
            ContestantRegistry registry = new ContestantRegistry(new MockContestant());
            int userID = 3;
            string userType = "Team";

            Tournament tournament = new Tournament()
            {
                ID = 1,
                Title = "Average-Minton",
                Description = "It's also badminton!",
                Sport = new Badminton(),
                City = "Eindhoven",
                Address = "Eindhovense Straat 1",
                MinContestants = 8,
                MaxContestants = 14,
                StartDate = DateTime.Now.AddDays(8).Date,
                EndDate = DateTime.Now.AddDays(16).Date,
                Status = TournamentStatus.Planned,
                System = TournamentSystem.RoundRobin
            };

            Assert.ThrowsException<Exception>(() =>
                registry.Register(userID, userType, tournament)
            );
        }

        [TestMethod]
        public void TestRegisterUserWithinWeekOfTournamentStarting()
        {
            ContestantRegistry registry = new ContestantRegistry(new MockContestant());
            int userID = 3;
            string userType = "Team";

            Tournament tournament = new Tournament()
            {
                ID = 1,
                Title = "Average-Minton",
                Description = "It's also badminton!",
                Sport = new Badminton(),
                City = "Eindhoven",
                Address = "Eindhovense Straat 1",
                MinContestants = 8,
                MaxContestants = 14,
                StartDate = DateTime.Now.AddDays(2).Date,
                EndDate = DateTime.Now.AddDays(9).Date,
                Status = TournamentStatus.Planned,
                System = TournamentSystem.RoundRobin
            };

            Assert.ThrowsException<Exception>(() =>
                registry.Register(userID, userType, tournament)
            );
        }

        [TestMethod]
        public void TestRegisterUserTournamentFull()
        {
            ContestantRegistry registry = new ContestantRegistry(new MockContestant());
            int userID = 3;
            string userType = "Team";

            Tournament tournament = new Tournament()
            {
                ID = 1,
                Title = "Average-Minton",
                Description = "It's also badminton!",
                Sport = new Badminton(),
                City = "Eindhoven",
                Address = "Eindhovense Straat 1",
                MinContestants = 2,
                MaxContestants = 3,
                StartDate = DateTime.Now.AddDays(8).Date,
                EndDate = DateTime.Now.AddDays(16).Date,
                Status = TournamentStatus.Planned,
                System = TournamentSystem.RoundRobin
            };

            Assert.ThrowsException<Exception>(() =>
                registry.Register(userID, userType, tournament)
            );
        }
        [TestMethod]
        public void TestRegisterUserInvalidTeamType()
        {
            ContestantRegistry registry = new ContestantRegistry(new MockContestant());
            int userID = 3;
            string userType = "Banana";

            Tournament tournament = new Tournament()
            {
                ID = 1,
                Title = "Average-Minton",
                Description = "It's also badminton!",
                Sport = new Badminton(),
                City = "Eindhoven",
                Address = "Eindhovense Straat 1",
                MinContestants = 2,
                MaxContestants = 8,
                StartDate = DateTime.Now.AddDays(8).Date,
                EndDate = DateTime.Now.AddDays(16).Date,
                Status = TournamentStatus.Planned,
                System = TournamentSystem.RoundRobin
            };

            Assert.ThrowsException<Exception>(() =>
                registry.Register(userID, userType, tournament)
            );
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
        public void TestSaveResults()
        {
            ContestantRegistry registry = new ContestantRegistry(new MockContestant());

            Match match = new Match()
            {
                ID = 1,
                TournamentID = 2,
                HomeID = 1,
                HomeName = "Lex",
                HomeScore = 5,
                AwayID = 2,
                AwayName = "Nick",
                AwayScore = 0,
                IsFinished = true
            };
            Contestant? playerOneBefore = registry.GetContestant(match.TournamentID, match.HomeID);
            Contestant? playerTwoBefore = registry.GetContestant(match.TournamentID, match.AwayID);

            bool result = registry.SaveResults(match.TournamentID, match.GetWinner(), match.GetLoser());

            Contestant? playerOneAfter = registry.GetContestant(match.TournamentID, match.HomeID);
            Contestant? playerTwoAfter = registry.GetContestant(match.TournamentID, match.AwayID);

            Assert.AreEqual(playerOneBefore!.Wins, playerTwoBefore!.Wins);
            Assert.AreEqual(playerOneBefore!.Losses, playerTwoBefore!.Losses);

            Assert.AreNotEqual(playerOneBefore!.Wins, playerOneAfter!.Wins);
            Assert.AreNotEqual(playerTwoBefore!.Losses, playerTwoAfter!.Losses);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestSaveResultsNonexistentIDs()
        {
            ContestantRegistry registry = new ContestantRegistry(new MockContestant());

            Match match = new Match()
            {
                ID = 1,
                TournamentID = 2,
                HomeID = 10,
                HomeName = "Lex",
                HomeScore = 5,
                AwayID = 12,
                AwayName = "Nick",
                AwayScore = 0,
                IsFinished = true
            };

            bool result = registry.SaveResults(match.TournamentID, match.GetWinner(), match.GetLoser());

            Assert.IsFalse(result);
        }
    }
}
