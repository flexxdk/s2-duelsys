using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System;

using BLL.Objects;
using BLL.Registries;
using DTO;
using DTO.Users;
using BLL.Enums;
using UnitTests.Mocks;

namespace UnitTests.RegistryTests
{
    [TestClass]
    public class MatchSchedulerTest
    {
        [TestMethod]
        public void TestGetMatchByID()
        {
            MatchScheduler scheduler = new MatchScheduler(new MockMatch());
            int matchID = 1;

            Match? match = scheduler.GetByID(matchID);

            Assert.IsNotNull(match);
            Assert.AreEqual(match.ID, matchID);
        }

        [TestMethod]
        public void TestGetMatchWithNonexistentID()
        {
            MatchScheduler scheduler = new MatchScheduler(new MockMatch());
            int matchID = 12;

            Match? match = scheduler.GetByID(matchID);

            Assert.IsNull(match);
        }

        [TestMethod]
        public void TestGetTournamentMatches()
        {
            MatchScheduler scheduler = new MatchScheduler(new MockMatch());

            List<Match> matches = scheduler.GetMatches(1).ToList();

            Assert.AreEqual(6, matches.Count);
        }

        [TestMethod]
        public void TestGenerateMatchesRoundRobin()
        {
            MatchScheduler scheduler = new MatchScheduler(new MockMatch());

            Tournament tournament = new Tournament()
            {
                ID = 2,
                Title = "Average-Minton",
                Sport = "Badminton",
                Scoring = "Points",
                City = "Helmond",
                Address = "Wethouder Ebbenlaan 30",
                MinContestants = 8,
                MaxContestants = 14,
                StartDate = DateTime.UtcNow.Date,
                EndDate = DateTime.UtcNow.AddDays(7).Date,
                Status = TournamentStatus.Planned,
                System = TournamentSystem.RoundRobin
            };

            scheduler.GenerateMatches(tournament);
            List<Match> matches = scheduler.GetMatches(tournament.ID).ToList();

            Assert.AreEqual(28, matches.Count);
        }
    }
}
