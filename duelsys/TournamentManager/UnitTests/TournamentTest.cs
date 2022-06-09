using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL.Objects;
using BLL.Objects.Sports;
using BLL.Enums;
using System;

namespace UnitTests
{
    [TestClass]
    public class TournamentTest
    {
        [TestMethod]
        public void TestTournamentCanStartTrue()
        {
            Tournament tournament = new Tournament()
            {
                Title = "Average-Minton",
                Description = "It's also badminton!",
                Sport = new Badminton(),
                City = "Eindhoven",
                Address = "Eindhovense Straat 1",
                MinContestants = 8,
                MaxContestants = 14,
                StartDate = DateTime.Now.Date,
                EndDate = DateTime.Now.AddDays(7).Date,
                Status = TournamentStatus.Planned,
                System = TournamentSystem.RoundRobin
            };

            bool result = tournament.CanStart(10);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestTournamentCanStartInvalidDate()
        {
            Tournament tournament = new Tournament()
            {
                Title = "Average-Minton",
                Description = "It's also badminton!",
                Sport = new Badminton(),
                City = "Eindhoven",
                Address = "Eindhovense Straat 1",
                MinContestants = 8,
                MaxContestants = 14,
                StartDate = DateTime.Now.Date.AddDays(10),
                EndDate = DateTime.Now.AddDays(15).Date,
                Status = TournamentStatus.Planned,
                System = TournamentSystem.RoundRobin
            };

            bool result = tournament.CanStart(10);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestTournamentCanStartNotEnoughContestants()
        {
            Tournament tournament = new Tournament()
            {
                Title = "Average-Minton",
                Description = "It's also badminton!",
                Sport = new Badminton(),
                City = "Eindhoven",
                Address = "Eindhovense Straat 1",
                MinContestants = 8,
                MaxContestants = 14,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(7).Date,
                Status = TournamentStatus.Planned,
                System = TournamentSystem.RoundRobin
            };

            bool result = tournament.CanStart(2);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestTournamentCanStartBothStartConditionsFail()
        {
            Tournament tournament = new Tournament()
            {
                Title = "Average-Minton",
                Description = "It's also badminton!",
                Sport = new Badminton(),
                City = "Eindhoven",
                Address = "Eindhovense Straat 1",
                MinContestants = 8,
                MaxContestants = 14,
                StartDate = DateTime.Now.Date.AddDays(10),
                EndDate = DateTime.Now.AddDays(15).Date,
                Status = TournamentStatus.Planned,
                System = TournamentSystem.RoundRobin
            };

            bool result = tournament.CanStart(2);

            Assert.IsFalse(result);
        }
    }
}
