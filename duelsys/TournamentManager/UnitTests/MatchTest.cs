using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL.Objects;
using BLL.Validation.Exceptions;

namespace UnitTests
{
    [TestClass]
    public class MatchTest
    {
        [TestMethod]
        public void TestMatchGetWinner()
        {
            Match match1 = new Match()
            {
                ID = 1,
                TournamentID = 1,
                HomeID = 1,
                HomeName = "Nick",
                HomeScore = 5,
                AwayID = 2,
                AwayName = "Sem",
                AwayScore = 0,
                IsFinished = true
            };

            Match match2 = new Match()
            {
                ID = 1,
                TournamentID = 1,
                HomeID = 1,
                HomeName = "Nick",
                HomeScore = 0,
                AwayID = 2,
                AwayName = "Sem",
                AwayScore = 5,
                IsFinished = true
            };

            Match match3 = new Match()
            {
                ID = 1,
                TournamentID = 1,
                HomeID = 1,
                HomeName = "Nick",
                HomeScore = 5,
                AwayID = 2,
                AwayName = "Sem",
                AwayScore = 5,
                IsFinished = true
            };

            Assert.AreEqual(1, match1.GetWinner());
            Assert.AreEqual(2, match2.GetWinner());
            Assert.AreEqual(-1, match3.GetWinner());
        }

        [TestMethod]
        public void TestMatchGetLoser()
        {
            Match match1 = new Match()
            {
                ID = 1,
                TournamentID = 1,
                HomeID = 1,
                HomeName = "Nick",
                HomeScore = 5,
                AwayID = 2,
                AwayName = "Sem",
                AwayScore = 0,
                IsFinished = true
            };

            Match match2 = new Match()
            {
                ID = 1,
                TournamentID = 1,
                HomeID = 1,
                HomeName = "Nick",
                HomeScore = 0,
                AwayID = 2,
                AwayName = "Sem",
                AwayScore = 5,
                IsFinished = true
            };

            Match match3 = new Match()
            {
                ID = 1,
                TournamentID = 1,
                HomeID = 1,
                HomeName = "Nick",
                HomeScore = 5,
                AwayID = 2,
                AwayName = "Sem",
                AwayScore = 5,
                IsFinished = true
            };

            Assert.AreEqual(2, match1.GetLoser());
            Assert.AreEqual(1, match2.GetLoser());
            Assert.AreEqual(-1, match3.GetLoser());
        }

        [TestMethod]
        public void TestMatchWinnerLoserUnfinishedMatch()
        {
            Match match = new Match()
            {
                ID = 1,
                TournamentID = 1,
                HomeID = 1,
                HomeName = "Nick",
                HomeScore = 2,
                AwayID = 2,
                AwayName = "Sem",
                AwayScore = 1,
                IsFinished = false
            };

            Assert.ThrowsException<MatchNotPlayedException>(() =>
            {
                match.GetWinner();
            });
            Assert.ThrowsException<MatchNotPlayedException>(() =>
            {
                match.GetLoser();
            });
        }
    }
}
