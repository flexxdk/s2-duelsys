using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System;

using BLL.Objects;
using BLL.Registries;
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
            MatchGenerator matchGenerator = new MatchGenerator();

            Tournament tournament = new Tournament()
            {
                ID = 1,
                Name = "Average-Minton",
                AllowRegistration = true,
                MinContestants = 8,
                MaxContestants = 14,
                StartDate = DateTime.UtcNow.Date,
                EndDate = DateTime.UtcNow.AddDays(7).Date,
                System = TournamentSystem.RoundRobin
            };

            List<ContestantDTO> contestants = new List<ContestantDTO>() {
                new ContestantDTO(1, "Lex", "de Kort", 1, 0, 0),
                new ContestantDTO(2, "Nick", "Blom", 1, 0, 0),
                new ContestantDTO(3, "Sem", "Storms", 1, 0, 0),
                new ContestantDTO(4, "Emilia", "Stoyanova", 1, 0, 0),
                new ContestantDTO(5, "Lex", "de Kort", 1, 0, 0),
                new ContestantDTO(6, "Nick", "Blom", 1, 0, 0),
                new ContestantDTO(7, "Sem", "Storms", 1, 0, 0),
                new ContestantDTO(8, "Emilia", "Stoyanova", 1, 0, 0),
            };

            List<MatchDTO> matches = matchGenerator.GenerateMatches(tournament, contestants).ToList();

            Assert.AreEqual(28, matches.Count);
        }

        [TestMethod]
        public void TestGenerateMatchesRoundRobinUnevenContestants()
        {
            MatchGenerator matchGenerator = new MatchGenerator();

            Tournament tournament = new Tournament()
            {
                ID = 1,
                Name = "Average-Minton",
                AllowRegistration = true,
                MinContestants = 8,
                MaxContestants = 14,
                StartDate = DateTime.UtcNow.Date,
                EndDate = DateTime.UtcNow.AddDays(7).Date,
                System = TournamentSystem.RoundRobin
            };

            List<ContestantDTO> contestants = new List<ContestantDTO>() {
                new ContestantDTO(1, "Lex", "de Kort", 1, 0, 0),
                new ContestantDTO(2, "Nick", "Blom", 1, 0, 0),
                new ContestantDTO(3, "Sem", "Storms", 1, 0, 0),
                new ContestantDTO(4, "Emilia", "Stoyanova", 1, 0, 0),
                new ContestantDTO(5, "Lex", "de Kort", 1, 0, 0),
                new ContestantDTO(6, "Nick", "Blom", 1, 0, 0),
                new ContestantDTO(7, "Sem", "Storms", 1, 0, 0),
                new ContestantDTO(8, "Emilia", "Stoyanova", 1, 0, 0),
                new ContestantDTO(9, "Emilia", "Stoyanova", 1, 0, 0),
            };

            List<MatchDTO> matches = matchGenerator.GenerateMatches(tournament, contestants).ToList();

            Assert.AreEqual(36, matches.Count);
        }

        [TestMethod]
        public void TestGenerateMatchesSingleEliminationBaseTwoContestants()
        {
            MatchGenerator matchGenerator = new MatchGenerator();

            Tournament tournament = new Tournament()
            {
                ID = 1,
                Name = "Average-Minton",
                AllowRegistration = true,
                MinContestants = 8,
                MaxContestants = 14,
                StartDate = DateTime.UtcNow.Date,
                EndDate = DateTime.UtcNow.AddDays(7).Date,
                System = TournamentSystem.SingleElimination
            };

            List<ContestantDTO> contestants = new List<ContestantDTO>() {
                new ContestantDTO(1, "Lex", "de Kort", 1, 0, 0),
                new ContestantDTO(2, "Nick", "Blom", 1, 0, 0),
                new ContestantDTO(3, "Sem", "Storms", 1, 0, 0),
                new ContestantDTO(4, "Emilia", "Stoyanova", 1, 0, 0),
                new ContestantDTO(5, "Lex", "de Kort", 1, 0, 0),
                new ContestantDTO(6, "Nick", "Blom", 1, 0, 0),
                new ContestantDTO(7, "Sem", "Storms", 1, 0, 0),
                new ContestantDTO(8, "Emilia", "Stoyanova", 1, 0, 0),
            };

            List<MatchDTO> matches = matchGenerator.GenerateMatches(tournament, contestants).ToList();

            Assert.AreEqual(4, matches.Count);
        }

        [TestMethod]
        public void TestGenerateMatchesSingleEliminationUnevenContestants()
        {
            MatchGenerator matchGenerator = new MatchGenerator();

            Tournament tournament = new Tournament()
            {
                ID = 1,
                Name = "Average-Minton",
                AllowRegistration = true,
                MinContestants = 8,
                MaxContestants = 14,
                StartDate = DateTime.UtcNow.Date,
                EndDate = DateTime.UtcNow.AddDays(7).Date,
                System = TournamentSystem.SingleElimination
            };

            List<ContestantDTO> contestants = new List<ContestantDTO>() {
                new ContestantDTO(1, "Lex", "de Kort", 1, 0, 0),
                new ContestantDTO(2, "Nick", "Blom", 1, 0, 0),
                new ContestantDTO(3, "Sem", "Storms", 1, 0, 0),
                new ContestantDTO(4, "Emilia", "Stoyanova", 1, 0, 0),

                new ContestantDTO(5, "Lex", "de Kort", 1, 0, 0),
                new ContestantDTO(6, "Nick", "Blom", 1, 0, 0),
                new ContestantDTO(7, "Sem", "Storms", 1, 0, 0),
                new ContestantDTO(8, "Emilia", "Stoyanova", 1, 0, 0),
                new ContestantDTO(9, "Emilia", "Stoyanova", 1, 0, 0),
                new ContestantDTO(10, "Sem", "Storms", 1, 0, 0),
                new ContestantDTO(11, "Emilia", "Stoyanova", 1, 0, 0),
                new ContestantDTO(12, "Emilia", "Stoyanova", 1, 0, 0),
            };

            List<MatchDTO> matches = matchGenerator.GenerateMatches(tournament, contestants).ToList();

            Assert.AreEqual(4, matches.Count);
        }

        [TestMethod]
        public void TestGenerateMatchesSingleEliminationNewBracket()
        {
            MatchGenerator matchGenerator = new MatchGenerator();

            Tournament tournament = new Tournament()
            {
                ID = 1,
                Name = "Average-Minton",
                AllowRegistration = true,
                MinContestants = 8,
                MaxContestants = 14,
                StartDate = DateTime.UtcNow.Date,
                EndDate = DateTime.UtcNow.AddDays(7).Date,
                System = TournamentSystem.SingleElimination
            };

            List<ContestantDTO> contestants = new List<ContestantDTO>() {
                new ContestantDTO(1, "Lex", "de Kort", 1, 1, 0),
                new ContestantDTO(2, "Nick", "Blom", 1, 0, 1),
                new ContestantDTO(3, "Sem", "Storms", 1, 1, 0),
                new ContestantDTO(4, "Emilia", "Stoyanova", 1, 0, 1),
                new ContestantDTO(5, "Lex", "de Kort", 1, 0, 1),
                new ContestantDTO(6, "Nick", "Blom", 1, 1, 0),
                new ContestantDTO(7, "Sem", "Storms", 1, 1, 0),
                new ContestantDTO(8, "Emilia", "Stoyanova", 1, 0, 1)
            };

            List<MatchDTO> matches = matchGenerator.GenerateMatches(tournament, contestants).ToList();

            Assert.AreEqual(2, matches.Count);
        }
    }
}
