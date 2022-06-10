using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System;

using BLL.Objects;
using BLL.Registries;
using BLL.Objects.Sports;
using DTO;
using DTO.Users;
using BLL.Enums;
using UnitTests.Mocks;
using BLL.Objects.TournamentSystem;

namespace UnitTests.RegistryTests
{
    [TestClass]
    public class MatchRegistryTest
    {
        [TestMethod]
        public void TestGetMatchByID()
        {
            MatchRegistry matchRegistry = new MatchRegistry(new MockMatch());
            int matchID = 1;

            Match? match = matchRegistry.GetByID(matchID);

            Assert.IsNotNull(match);
            Assert.AreEqual(match.ID, matchID);
        }

        [TestMethod]
        public void TestGetMatchWithNonexistentID()
        {
            MatchRegistry matchRegistry = new MatchRegistry(new MockMatch());
            int matchID = 12;

            Match? match = matchRegistry.GetByID(matchID);

            Assert.IsNull(match);
        }

        [TestMethod]
        public void TestGetTournamentMatches()
        {
            MatchRegistry matchRegistry = new MatchRegistry(new MockMatch());

            List<Match> matches = matchRegistry.GetMatches(1).ToList();

            Assert.AreEqual(6, matches.Count);
        }

        [TestMethod]
        public void TestGenerateMatchesRoundRobin()
        {
            MatchRegistry matchRegistry = new MatchRegistry(new MockMatch());
            ContestantRegistry contestantRegistry = new ContestantRegistry(new MockContestant()); 

            Tournament tournament = new Tournament()
            {
                ID = 2,
                Title = "Average-Minton",
                Sport = new Badminton(),
                City = "Helmond",
                Address = "Wethouder Ebbenlaan 30",
                MinContestants = 6,
                MaxContestants = 14,
                StartDate = DateTime.UtcNow.Date,
                EndDate = DateTime.UtcNow.AddDays(7).Date,
                Status = TournamentStatus.Planned,
                System = new RoundRobin()
            };

            matchRegistry.CreateMatches(tournament.System.GenerateMatches(2, contestantRegistry.GetContestants(tournament.ID)));
            List<Match> matches = matchRegistry.GetMatches(tournament.ID).ToList();

            Assert.AreEqual(15, matches.Count);
        }

        [TestMethod]
        public void TestGenerateMatchesSingleElimination()
        {
            MatchRegistry matchRegistry = new MatchRegistry(new MockMatch());
            ContestantRegistry contestantRegistry = new ContestantRegistry(new MockContestant());

            Tournament tournament = new Tournament()
            {
                ID = 2,
                Title = "Average-Minton",
                Sport = new Badminton(),
                City = "Helmond",
                Address = "Wethouder Ebbenlaan 30",
                MinContestants = 6,
                MaxContestants = 14,
                StartDate = DateTime.UtcNow.Date,
                EndDate = DateTime.UtcNow.AddDays(7).Date,
                Status = TournamentStatus.Planned,
                System = new SingleElimination()
            };

            matchRegistry.CreateMatches(tournament.System.GenerateMatches(2, contestantRegistry.GetContestants(tournament.ID)));
            List<Match> matches = matchRegistry.GetMatches(tournament.ID).ToList();

            Assert.AreEqual(2, matches.Count);
        }

        [TestMethod]
        public void TestSaveMatchResults()
        {
            MatchRegistry matchRegistry = new MatchRegistry(new MockMatch());
            Match? match = matchRegistry.GetByID(1);

            bool result = matchRegistry.SaveMatch(new Match()
            {
                ID = match!.ID,
                TournamentID = match!.TournamentID,
                IsFinished = true,
                HomeID = match!.HomeID,
                HomeName = match!.HomeName,
                HomeScore = 2,
                AwayID = match!.AwayID,
                AwayName = match!.AwayName,
                AwayScore = 1
            });
            Match? updatedMatch = matchRegistry.GetByID(1);

            Assert.IsTrue(result);
            Assert.IsNotNull(updatedMatch);
            Assert.AreEqual(updatedMatch.ID, match!.ID);
        }

        [TestMethod]
        public void TestSaveMatchResultsInvalidMatchID()
        {
            MatchRegistry matchRegistry = new MatchRegistry(new MockMatch());
            Match? match = matchRegistry.GetByID(1);

            bool result = matchRegistry.SaveMatch(new Match()
            {
                ID = 99999,
                TournamentID = match!.TournamentID,
                IsFinished = true,
                HomeID = match!.HomeID,
                HomeName = match!.HomeName,
                HomeScore = 2,
                AwayID = match!.AwayID,
                AwayName = match!.AwayName,
                AwayScore = 1
            });

            Assert.IsFalse(result);
        }
    }
}
