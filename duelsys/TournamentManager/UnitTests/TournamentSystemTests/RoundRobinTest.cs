using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System;

using BLL.Objects;
using BLL.Registries;
using BLL.Objects.TournamentSystem;
using DTO;
using UnitTests.Mocks;
using BLL.Enums;
using BLL.Objects.Users;
using BLL.Objects.Sports;

namespace UnitTests.TournamentSystemTests
{
    [TestClass]
    public class RoundRobinTest
    {
        [TestMethod]
        public void TestGenerateMatchesRoundRobinEvenContestants()
        {
            ITournamentSystem system = new RoundRobin();

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

            Assert.AreEqual(28, matches.Count);
        }

        [TestMethod]
        public void TestGenerateMatchesRoundRobinUnevenContestants()
        {
            ITournamentSystem system = new RoundRobin();

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

            List<MatchDTO> matches = system.GenerateMatches(1, contestants).ToList();

            Assert.AreEqual(36, matches.Count);
        }
    }
}
