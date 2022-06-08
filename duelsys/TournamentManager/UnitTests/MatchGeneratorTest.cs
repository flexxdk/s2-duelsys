using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System;

using BLL.Objects;
using BLL.Registries;
using BLL.Objects.Sports;
using DTO;
using DTO.Users;
using UnitTests.Mocks;
using BLL.Enums;
using BLL.Objects.Users;
using System.ComponentModel.DataAnnotations;

namespace UnitTests
{
    [TestClass]
    public class MatchGeneratorTest
    {
        [TestMethod]
        public void TestGenerateMatchesRoundRobinEvenContestants()
        {
            MatchGenerator matchGenerator = new MatchGenerator(new MockMatch());
            ContestantRegistry contestantRegistry = new ContestantRegistry(new MockContestant());

            Tournament tournament = new Tournament()
            {
                ID = 1,
                Title = "Average-Minton",
                Sport = new Badminton(),
                City = "Helmond",
                Address = "Wethouder Ebbenlaan 30",
                MinContestants = 8,
                MaxContestants = 14,
                StartDate = DateTime.UtcNow.Date,
                EndDate = DateTime.UtcNow.AddDays(7).Date,
                Status = TournamentStatus.Planned,
                System = TournamentSystem.RoundRobin
            };

            IEnumerable<Contestant> contestants = new List<Contestant>() {
                new Contestant(){ ID = 1, Name = "Lex", SurName = "de Kort", TournamentID = 1, Wins = 0, Losses = 0 },
                new Contestant(){ ID = 2, Name = "Nick", SurName = "Blom", TournamentID = 1, Wins = 0, Losses = 0 },
                new Contestant(){ ID = 3, Name = "Sem", SurName = "Storms", TournamentID = 1, Wins = 0, Losses = 0 },
                new Contestant(){ ID = 4, Name = "Emilia", SurName = "Stoyanova", TournamentID = 1, Wins = 0, Losses = 0 },
                new Contestant(){ ID = 5, Name = "Fontys", SurName = "Man", TournamentID = 1, Wins = 0, Losses = 0 },
                new Contestant(){ ID = 6, Name = "Mohammed", SurName = "Bouali", TournamentID = 1, Wins = 0, Losses = 0 },
                new Contestant(){ ID = 7, Name = "Paula", SurName = "Cortes", TournamentID = 1, Wins = 0, Losses = 0 },
                new Contestant(){ ID = 8, Name = "Julian", SurName = "Teulings", TournamentID = 1, Wins = 0, Losses = 0 }
            };

            List<MatchDTO> matches = matchGenerator.GenerateMatches(tournament.System, tournament.ID, contestants).ToList();

            Assert.AreEqual(28, matches.Count);
        }

        [TestMethod]
        public void TestGenerateMatchesRoundRobinUnevenContestants()
        {
            MatchGenerator matchGenerator = new MatchGenerator(new MockMatch());
            ContestantRegistry contestantRegistry = new ContestantRegistry(new MockContestant());

            Tournament tournament = new Tournament()
            {
                ID = 1,
                Title = "Average-Minton",
                Sport = new Badminton(),
                City = "Helmond",
                Address = "Wethouder Ebbenlaan 30",
                MinContestants = 8,
                MaxContestants = 14,
                StartDate = DateTime.UtcNow.Date,
                EndDate = DateTime.UtcNow.AddDays(7).Date,
                Status = TournamentStatus.Planned,
                System = TournamentSystem.RoundRobin
            };

            IEnumerable<Contestant> contestants = new List<Contestant>() {
                new Contestant(){ ID = 1, Name = "Lex", SurName = "de Kort", TournamentID = 1, Wins = 0, Losses = 0 },
                new Contestant(){ ID = 2, Name = "Nick", SurName = "Blom", TournamentID = 1, Wins = 0, Losses = 0 },
                new Contestant(){ ID = 3, Name = "Sem", SurName = "Storms", TournamentID = 1, Wins = 0, Losses = 0 },
                new Contestant(){ ID = 4, Name = "Emilia", SurName = "Stoyanova", TournamentID = 1, Wins = 0, Losses = 0 },
                new Contestant(){ ID = 5, Name = "Fontys", SurName = "Man", TournamentID = 1, Wins = 0, Losses = 0 },
                new Contestant(){ ID = 6, Name = "Mohammed", SurName = "Bouali", TournamentID = 1, Wins = 0, Losses = 0 },
                new Contestant(){ ID = 7, Name = "Paula", SurName = "Cortes", TournamentID = 1, Wins = 0, Losses = 0 },
                new Contestant(){ ID = 8, Name = "Julian", SurName = "Teulings", TournamentID = 1, Wins = 0, Losses = 0 },
                new Contestant(){ ID = 9, Name = "Ivar", SurName = "Faessen", TournamentID = 1, Wins = 0, Losses = 0 },
            };

            List<MatchDTO> matches = matchGenerator.GenerateMatches(tournament.System, tournament.ID, contestants).ToList();

            Assert.AreEqual(36, matches.Count);
        }

        [TestMethod]
        public void TestGenerateMatchesSingleEliminationPowerOfTwoContestants()
        {
            MatchGenerator matchGenerator = new MatchGenerator(new MockMatch());

            Tournament tournament = new Tournament()
            {
                ID = 1,
                Title = "Average-Minton",
                Sport = new Badminton(),
                City = "Helmond",
                Address = "Wethouder Ebbenlaan 30",
                MinContestants = 8,
                MaxContestants = 14,
                StartDate = DateTime.UtcNow.Date,
                EndDate = DateTime.UtcNow.AddDays(7).Date,
                Status = TournamentStatus.Planned,
                System = TournamentSystem.SingleElimination
            };

            IEnumerable<Contestant> contestants = new List<Contestant>() {
                new Contestant(){ ID = 1, Name = "Lex", SurName = "de Kort", TournamentID = 1, Wins = 0, Losses = 0 },
                new Contestant(){ ID = 2, Name = "Nick", SurName = "Blom", TournamentID = 1, Wins = 0, Losses = 0 },
                new Contestant(){ ID = 3, Name = "Sem", SurName = "Storms", TournamentID = 1, Wins = 0, Losses = 0 },
                new Contestant(){ ID = 4, Name = "Emilia", SurName = "Stoyanova", TournamentID = 1, Wins = 0, Losses = 0 },
                new Contestant(){ ID = 5, Name = "Fontys", SurName = "Man", TournamentID = 1, Wins = 0, Losses = 0 },
                new Contestant(){ ID = 6, Name = "Mohammed", SurName = "Bouali", TournamentID = 1, Wins = 0, Losses = 0 },
                new Contestant(){ ID = 7, Name = "Paula", SurName = "Cortes", TournamentID = 1, Wins = 0, Losses = 0 },
                new Contestant(){ ID = 8, Name = "Julian", SurName = "Teulings", TournamentID = 1, Wins = 0, Losses = 0 }
            };

            List<MatchDTO> matches = matchGenerator.GenerateMatches(tournament.System, tournament.ID, contestants).ToList();

            Assert.AreEqual(4, matches.Count);
        }

        [TestMethod]
        public void TestGenerateMatchesSingleEliminationNonPowerOfTwoContestants()
        {
            MatchGenerator matchGenerator = new MatchGenerator(new MockMatch());
            ContestantRegistry contestantRegistry = new ContestantRegistry(new MockContestant());

            Tournament tournament = new Tournament()
            {
                ID = 1,
                Title = "Average-Minton",
                Sport = new Badminton(),
                City = "Helmond",
                Address = "Wethouder Ebbenlaan 30",
                MinContestants = 8,
                MaxContestants = 14,
                StartDate = DateTime.UtcNow.Date,
                EndDate = DateTime.UtcNow.AddDays(7).Date,
                Status = TournamentStatus.Planned,
                System = TournamentSystem.SingleElimination
            };

            IEnumerable<Contestant> contestants = new List<Contestant>() {
                new Contestant(){ ID = 1, Name = "Lex", SurName = "de Kort", TournamentID = 1, Wins = 0, Losses = 0 },
                new Contestant(){ ID = 2, Name = "Nick", SurName = "Blom", TournamentID = 1, Wins = 0, Losses = 0 },
                new Contestant(){ ID = 3, Name = "Sem", SurName = "Storms", TournamentID = 1, Wins = 0, Losses = 0 },
                new Contestant(){ ID = 4, Name = "Emilia", SurName = "Stoyanova", TournamentID = 1, Wins = 0, Losses = 0 },
                new Contestant(){ ID = 5, Name = "Fontys", SurName = "Man", TournamentID = 1, Wins = 0, Losses = 0 },
                new Contestant(){ ID = 6, Name = "Mohammed", SurName = "Bouali", TournamentID = 1, Wins = 0, Losses = 0 },
                new Contestant(){ ID = 7, Name = "Paula", SurName = "Cortes", TournamentID = 1, Wins = 0, Losses = 0 },
                new Contestant(){ ID = 8, Name = "Julian", SurName = "Teulings", TournamentID = 1, Wins = 0, Losses = 0 },

                new Contestant(){ ID = 9, Name = "Ivar", SurName = "Faessen", TournamentID = 1, Wins = 0, Losses = 0 },
                new Contestant(){ ID = 10, Name = "Mariela", SurName = "Gocheva", TournamentID = 1, Wins = 0, Losses = 0 },
                new Contestant(){ ID = 11, Name = "Jochem", SurName = "van der Pol", TournamentID = 1, Wins = 0, Losses = 0 },
                new Contestant(){ ID = 12, Name = "Arthur", SurName = "Bommele", TournamentID = 1, Wins = 0, Losses = 0 }
            };

            List<MatchDTO> matches = matchGenerator.GenerateMatches(tournament.System, tournament.ID, contestants).ToList();


            Assert.AreEqual(4, matches.Count);
        }

        [TestMethod]
        public void TestGenerateMatchesSingleEliminationNewBracket()
        {
            MatchGenerator matchGenerator = new MatchGenerator(new MockMatch());

            Tournament tournament = new Tournament()
            {
                ID = 1,
                Title = "Average-Minton",
                Sport = new Badminton(),
                City = "Helmond",
                Address = "Wethouder Ebbenlaan 30",
                MinContestants = 8,
                MaxContestants = 14,
                StartDate = DateTime.UtcNow.Date,
                EndDate = DateTime.UtcNow.AddDays(7).Date,
                Status = TournamentStatus.Planned,
                System = TournamentSystem.SingleElimination
            };

            IEnumerable<Contestant> contestants = new List<Contestant>() {
                new Contestant(){ ID = 1, Name = "Lex", SurName = "de Kort", TournamentID = 1, Wins = 1, Losses = 0 },
                new Contestant(){ ID = 2, Name = "Nick", SurName = "Blom", TournamentID = 1, Wins = 0, Losses = 1 },
                new Contestant(){ ID = 3, Name = "Sem", SurName = "Storms", TournamentID = 1, Wins = 1, Losses = 0 },
                new Contestant(){ ID = 4, Name = "Emilia", SurName = "Stoyanova", TournamentID = 1, Wins = 0, Losses = 1 },
                new Contestant(){ ID = 5, Name = "Fontys", SurName = "Man", TournamentID = 1, Wins = 0, Losses = 1 },
                new Contestant(){ ID = 6, Name = "Mohammed", SurName = "Bouali", TournamentID = 1, Wins = 1, Losses = 0 },
                new Contestant(){ ID = 7, Name = "Paula", SurName = "Cortes", TournamentID = 1, Wins = 1, Losses = 0 },
                new Contestant(){ ID = 8, Name = "Julian", SurName = "Teulings", TournamentID = 1, Wins = 0, Losses = 1 }
            };

            List<MatchDTO> matches = matchGenerator.GenerateMatches(tournament.System, tournament.ID, contestants).ToList();



            Assert.AreEqual(2, matches.Count);
        }

        [TestMethod]
        public void TestGenerateMatchesSeveralBrackets()
        {
            MatchGenerator matchGenerator = new MatchGenerator(new MockMatch());

            Tournament tournament = new Tournament()
            {
                ID = 1,
                Title = "Average-Minton",
                Sport = new Badminton(),
                City = "Helmond",
                Address = "Wethouder Ebbenlaan 30",
                MinContestants = 8,
                MaxContestants = 14,
                StartDate = DateTime.UtcNow.Date,
                EndDate = DateTime.UtcNow.AddDays(7).Date,
                Status = TournamentStatus.Planned,
                System = TournamentSystem.SingleElimination
            };

            IList<Contestant> contestants = new List<Contestant>() {
                new Contestant(){ ID = 1, Name = "Lex", SurName = "de Kort", TournamentID = 1, Wins = 0, Losses = 0 },
                new Contestant(){ ID = 2, Name = "Nick", SurName = "Blom", TournamentID = 1, Wins = 0, Losses = 0 },
                new Contestant(){ ID = 3, Name = "Sem", SurName = "Storms", TournamentID = 1, Wins = 0, Losses = 0 },
                new Contestant(){ ID = 4, Name = "Emilia", SurName = "Stoyanova", TournamentID = 1, Wins = 0, Losses = 0 },
                new Contestant(){ ID = 5, Name = "Fontys", SurName = "Man", TournamentID = 1, Wins = 0, Losses = 0 },
                new Contestant(){ ID = 6, Name = "Mohammed", SurName = "Bouali", TournamentID = 1, Wins = 0, Losses = 0 },
                new Contestant(){ ID = 7, Name = "Paula", SurName = "Cortes", TournamentID = 1, Wins = 0, Losses = 0 },
                new Contestant(){ ID = 8, Name = "Julian", SurName = "Teulings", TournamentID = 1, Wins = 0, Losses = 0 }
            };

            List<MatchDTO> firstBracket = matchGenerator.GenerateMatches(tournament.System, tournament.ID, contestants).ToList();
            contestants[0].Wins += 1;
            contestants[1].Losses += 1;
            contestants[2].Wins += 1;
            contestants[3].Losses += 1;
            contestants[4].Losses += 1;
            contestants[5].Wins += 1;
            contestants[6].Losses += 1;
            contestants[7].Wins += 1;

            List<MatchDTO> secondBracket = matchGenerator.GenerateMatches(tournament.System, tournament.ID, contestants).ToList();
            contestants[0].Losses += 1;
            contestants[2].Wins += 1;
            contestants[5].Wins += 1;
            contestants[7].Losses += 1;

            List<MatchDTO> thirdBracket = matchGenerator.GenerateMatches(tournament.System, tournament.ID, contestants).ToList();
            contestants[2].Wins += 1;
            contestants[5].Losses += 1;

            Assert.AreEqual(4, firstBracket.Count());
            Assert.AreEqual(2, secondBracket.Count());
            Assert.AreEqual(1, thirdBracket.Count());
        }

        [TestMethod]
        public void TestGenerateMatchesSeveralBracketsStopAfterFinals()
        {
            MatchGenerator matchGenerator = new MatchGenerator(new MockMatch());

            Tournament tournament = new Tournament()
            {
                ID = 1,
                Title = "Average-Minton",
                Sport = new Badminton(),
                City = "Helmond",
                Address = "Wethouder Ebbenlaan 30",
                MinContestants = 8,
                MaxContestants = 14,
                StartDate = DateTime.UtcNow.Date,
                EndDate = DateTime.UtcNow.AddDays(7).Date,
                Status = TournamentStatus.Planned,
                System = TournamentSystem.SingleElimination
            };

            IList<Contestant> contestants = new List<Contestant>() {
                new Contestant(){ ID = 1, Name = "Lex", SurName = "de Kort", TournamentID = 1, Wins = 0, Losses = 0 },
                new Contestant(){ ID = 2, Name = "Nick", SurName = "Blom", TournamentID = 1, Wins = 0, Losses = 0 },
                new Contestant(){ ID = 3, Name = "Sem", SurName = "Storms", TournamentID = 1, Wins = 0, Losses = 0 },
                new Contestant(){ ID = 4, Name = "Emilia", SurName = "Stoyanova", TournamentID = 1, Wins = 0, Losses = 0 },
                new Contestant(){ ID = 5, Name = "Fontys", SurName = "Man", TournamentID = 1, Wins = 0, Losses = 0 },
                new Contestant(){ ID = 6, Name = "Mohammed", SurName = "Bouali", TournamentID = 1, Wins = 0, Losses = 0 },
                new Contestant(){ ID = 7, Name = "Paula", SurName = "Cortes", TournamentID = 1, Wins = 0, Losses = 0 },
                new Contestant(){ ID = 8, Name = "Julian", SurName = "Teulings", TournamentID = 1, Wins = 0, Losses = 0 }
            };

            List<MatchDTO> firstBracket = matchGenerator.GenerateMatches(tournament.System, tournament.ID, contestants).ToList();
            contestants[0].Wins += 1;
            contestants[1].Losses += 1;
            contestants[2].Wins += 1;
            contestants[3].Losses += 1;
            contestants[4].Losses += 1;
            contestants[5].Wins += 1;
            contestants[6].Losses += 1;
            contestants[7].Wins += 1;

            List<MatchDTO> secondBracket = matchGenerator.GenerateMatches(tournament.System, tournament.ID, contestants).ToList();
            contestants[0].Losses += 1;
            contestants[2].Wins += 1;
            contestants[5].Wins += 1;
            contestants[7].Losses += 1;

            List<MatchDTO> thirdBracket = matchGenerator.GenerateMatches(tournament.System, tournament.ID, contestants).ToList();
            contestants[2].Wins += 1;
            contestants[5].Losses += 1;

            List<MatchDTO> notValid = matchGenerator.GenerateMatches(tournament.System, tournament.ID, contestants).ToList();

            Assert.AreEqual(4, firstBracket.Count());
            Assert.AreEqual(2, secondBracket.Count());
            Assert.AreEqual(1, thirdBracket.Count());
            Assert.AreEqual(0, notValid.Count());
        }
    }
}
