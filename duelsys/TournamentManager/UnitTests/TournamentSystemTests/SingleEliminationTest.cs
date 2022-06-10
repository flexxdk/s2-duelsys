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
using BLL.Objects.TournamentSystem;
using BLL.Validation.Exceptions;

namespace UnitTests.TournamentSystemTests
{
    [TestClass]
    public class SingleEliminationTest
    {
        [TestMethod]
        public void TestGenerateMatchesSingleEliminationPowerOfTwoContestants()
        {
            ITournamentSystem system = new SingleElimination();

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

            List<MatchDTO> matches = system.GenerateMatches(1, contestants).ToList();

            Assert.AreEqual(4, matches.Count);
        }


        [TestMethod]
        public void TestGenerateMatchesSingleEliminationNewBracket()
        {
            ITournamentSystem system = new SingleElimination();

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

            List<MatchDTO> matches = system.GenerateMatches(1, contestants).ToList();

            Assert.AreEqual(2, matches.Count);
        }

        [TestMethod]
        public void TestGenerateMatchesSeveralBrackets()
        {
            ITournamentSystem system = new SingleElimination();

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

            List<MatchDTO> firstBracket = system.GenerateMatches(1, contestants).ToList();
            contestants[0].Wins += 1;
            contestants[1].Losses += 1;
            contestants[2].Wins += 1;
            contestants[3].Losses += 1;
            contestants[4].Losses += 1;
            contestants[5].Wins += 1;
            contestants[6].Losses += 1;
            contestants[7].Wins += 1;

            List<MatchDTO> secondBracket = system.GenerateMatches(1, contestants).ToList();
            contestants[0].Losses += 1;
            contestants[2].Wins += 1;
            contestants[5].Wins += 1;
            contestants[7].Losses += 1;

            List<MatchDTO> thirdBracket = system.GenerateMatches(1, contestants).ToList();
            contestants[2].Wins += 1;
            contestants[5].Losses += 1;

            Assert.AreEqual(4, firstBracket.Count());
            Assert.AreEqual(2, secondBracket.Count());
            Assert.AreEqual(1, thirdBracket.Count());
        }

        [TestMethod]
        public void TestGenerateMatchesSeveralBracketsStopAfterFinals()
        {
            ITournamentSystem system = new SingleElimination();

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

            List<MatchDTO> firstBracket = system.GenerateMatches(1, contestants).ToList();
            contestants[0].Wins += 1;
            contestants[1].Losses += 1;
            contestants[2].Wins += 1;
            contestants[3].Losses += 1;
            contestants[4].Losses += 1;
            contestants[5].Wins += 1;
            contestants[6].Losses += 1;
            contestants[7].Wins += 1;

            List<MatchDTO> secondBracket = system.GenerateMatches(1, contestants).ToList();
            contestants[0].Losses += 1;
            contestants[2].Wins += 1;
            contestants[5].Wins += 1;
            contestants[7].Losses += 1;

            List<MatchDTO> thirdBracket = system.GenerateMatches(1, contestants).ToList();
            contestants[2].Wins += 1;
            contestants[5].Losses += 1;

            Assert.AreEqual(4, firstBracket.Count());
            Assert.AreEqual(2, secondBracket.Count());
            Assert.AreEqual(1, thirdBracket.Count());

            Assert.ThrowsException<NoValidContestantsException>(() =>
            {
                List<MatchDTO> notValid = system.GenerateMatches(1, contestants).ToList();
            });
        }
    }
}
