using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System;

using BLL.Objects;
using BLL.Registries;
using BLL.Enums;
using BLL.Objects.Sports;
using BLL.Objects.Users;
using UnitTests.Mocks;
using System.ComponentModel.DataAnnotations;

namespace UnitTests.RegistryTests
{
    [TestClass]
    public class TournamentRegistryTest
    {
        [TestMethod]
        public void TestLoadTournaments()
        {
            TournamentRegistry registry = new TournamentRegistry(new MockTournament());

            Assert.AreEqual(8, registry.GetAll(true).Count);
            Assert.IsInstanceOfType(registry.GetAll(true).ToList(), typeof(List<Tournament>));
        }

        [TestMethod]
        public void TestGetTournament()
        {
            TournamentRegistry registry = new TournamentRegistry(new MockTournament());

            Tournament? tournament = registry.GetByID(1);

            Assert.IsNotNull(tournament);
        }

        [TestMethod]
        public void TestGetNonexistentTournament()
        {
            TournamentRegistry registry = new TournamentRegistry(new MockTournament());

            Tournament? tournament = registry.GetByID(20);

            Assert.IsNull(tournament);
        }

        [TestMethod]
        public void TestCreateTournament()
        {
            TournamentRegistry registry = new TournamentRegistry(new MockTournament());

            int beforeCount = registry.GetAll(true).Count;
            registry.CreateTournament(new Tournament()
            {
                Title = "Average-Minton",
                Description = "It's also badminton!",
                Sport = new Badminton(),
                City = "Eindhoven",
                Address = "Eindhovense Straat 1",
                MinContestants = 8,
                MaxContestants = 14,
                StartDate = DateTime.UtcNow.Date,
                EndDate = DateTime.UtcNow.AddDays(7).Date,
                Status = TournamentStatus.Planned,
                System = TournamentSystem.RoundRobin
            });
            int afterCount = registry.GetAll(true).Count;

            Assert.AreNotEqual(beforeCount, afterCount);
            Assert.AreEqual(afterCount, registry.GetAll(true).Last().ID);
        }

        [TestMethod]
        public void TestCreateTournamentWithInvalidInput()
        {
            TournamentRegistry registry = new TournamentRegistry(new MockTournament());

            Assert.ThrowsException<ValidationException>(() =>
                registry.CreateTournament(new Tournament()
                {
                    ID = 0,
                    Title = "Mario Kart Grand Prix",
                    Sport = new Badminton(),
                    City = "Eindhoven",
                    Address = "Eindhovense Straat 1",
                    MinContestants = 8,
                    MaxContestants = 2,
                    StartDate = DateTime.UtcNow.Date,
                    EndDate = DateTime.UtcNow.AddDays(7).Date,
                    Status = TournamentStatus.Planned,
                    System = TournamentSystem.RoundRobin
                }), "All input is correct"
            );
        }

        [TestMethod]
        public void TestUpdateTournament()
        {
            TournamentRegistry registry = new TournamentRegistry(new MockTournament());

            Tournament? tournament = registry.GetByID(1);
            registry.UpdateTournament(new Tournament()
            {
                ID = tournament!.ID,
                Title = "Mario Kart Grand Prix",
                Description = "Now it's karting!",
                Sport = new Badminton(),
                City = "Eindhoven",
                Address = "Eindhovense Straat 1",
                MinContestants = 4,
                MaxContestants = 8,
                StartDate = DateTime.UtcNow.Date.AddDays(1),
                EndDate = DateTime.UtcNow.Date.AddDays(2),
                Status = TournamentStatus.Finished,
                System = TournamentSystem.RoundRobin
            });
            Tournament? updatedTournament = registry.GetByID(1);

            Assert.IsNotNull(updatedTournament);
            Assert.AreEqual(updatedTournament.ID, tournament!.ID);
            Assert.AreNotEqual(updatedTournament.Title, tournament!.Title);
            Assert.AreNotEqual(updatedTournament.Sport, tournament!.Sport);
            Assert.AreNotEqual(updatedTournament.City, tournament!.City);
            Assert.AreNotEqual(updatedTournament.Address, tournament!.Address);
            Assert.AreNotEqual(updatedTournament.MinContestants, tournament!.MinContestants);
            Assert.AreNotEqual(updatedTournament.MaxContestants, tournament!.MaxContestants);
            Assert.AreNotEqual(updatedTournament.StartDate, tournament!.StartDate);
            Assert.AreNotEqual(updatedTournament.EndDate, tournament!.EndDate);
            Assert.AreNotEqual(updatedTournament.Status, tournament!.Status);
            Assert.AreNotEqual(updatedTournament.System, tournament!.System);
        }

        [TestMethod]
        public void TestUpdateTournamentWithInvalidInput()
        {
            TournamentRegistry registry = new TournamentRegistry(new MockTournament());

            Tournament? tournament = registry.GetByID(1);

            Assert.ThrowsException<ValidationException>(() =>
                registry.UpdateTournament(new Tournament()
                {
                    ID = tournament!.ID,
                    Title = "",
                    Sport = new Badminton(),
                    City = "",
                    Address = "",
                    MinContestants = 0,
                    MaxContestants = -1,
                    StartDate = DateTime.UtcNow.Date,
                    EndDate = DateTime.UtcNow.Date,
                    Status = TournamentStatus.Planned,
                    System = TournamentSystem.RoundRobin
                })
            ); ;
        }

        [TestMethod]
        public void TestDeleteTournament()
        {
            TournamentRegistry registry = new TournamentRegistry(new MockTournament());
            int idToRemove = 1;

            int beforeCount = registry.GetAll(true).Count;
            bool result = registry.DeleteTournament(idToRemove);
            int afterCount = registry.GetAll(true).Count;

            Assert.IsTrue(result);
            Assert.AreNotEqual(beforeCount, afterCount);
            Assert.AreNotEqual(idToRemove, registry.GetAll(true).First().ID);
        }

        [TestMethod]
        public void TestDeleteTournamentNonexistentID()
        {
            TournamentRegistry registry = new TournamentRegistry(new MockTournament());
            int idToRemove = 20;

            int beforeCount = registry.GetAll(true).Count;
            bool result = registry.DeleteTournament(idToRemove);
            int afterCount = registry.GetAll(true).Count;

            Assert.IsFalse(result);
            Assert.AreEqual(beforeCount, afterCount);
        }

        [TestMethod]
        public void TestGetLeaderboard()
        {
            TournamentRegistry registry = new TournamentRegistry(new MockTournament());

            List<Contestant> rankings = registry.GetLeaderboard(3).ToList();

            Assert.IsNotNull(rankings);
        }

        [TestMethod]
        public void TestGetLeaderboardNonexistentID()
        {
            TournamentRegistry registry = new TournamentRegistry(new MockTournament());

            List<Contestant> rankings = registry.GetLeaderboard(20).ToList();

            Assert.AreEqual(0, rankings.Count);
        }

        [TestMethod]
        public void TestGetActiveTournaments()
        {
            TournamentRegistry registry = new TournamentRegistry(new MockTournament());

            List<Tournament> active = registry.GetActiveTournaments().ToList();

            Assert.IsNotNull(active);
            Assert.AreEqual(1, active.Count);
        }

        [TestMethod]
        public void TestStartTournament()
        {
            TournamentRegistry registry = new TournamentRegistry(new MockTournament());

            Tournament? tournament = registry.GetByID(3);
            IEnumerable<Contestant> contestants = new List<Contestant>() {
                new Contestant(){ ID = 1, Name = "Lex", SurName = "de Kort", TournamentID = 3, Wins = 0, Losses = 0 },
                new Contestant(){ ID = 2, Name = "Nick", SurName = "Blom", TournamentID = 3, Wins = 0, Losses = 0 },
                new Contestant(){ ID = 3, Name = "Sem", SurName = "Storms", TournamentID = 3, Wins = 0, Losses = 0 },
                new Contestant(){ ID = 4, Name = "Emilia", SurName = "Stoyanova", TournamentID = 3, Wins = 0, Losses = 0 },
                new Contestant(){ ID = 5, Name = "Fontys", SurName = "Man", TournamentID = 3, Wins = 0, Losses = 0 },
                new Contestant(){ ID = 6, Name = "Mohammed", SurName = "Bouali", TournamentID = 3, Wins = 0, Losses = 0 },
                new Contestant(){ ID = 7, Name = "Paula", SurName = "Cortes", TournamentID = 3, Wins = 0, Losses = 0 },
                new Contestant(){ ID = 8, Name = "Julian", SurName = "Teulings", TournamentID = 3, Wins = 0, Losses = 0 }
            };

            bool result = registry.StartTournament(tournament!.ID, TournamentStatus.Running, contestants.Count());

            Assert.AreNotEqual(TournamentStatus.Planned, registry.GetByID(3)!.Status);
            Assert.AreEqual(TournamentStatus.Running, registry.GetByID(3)!.Status);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestFinishTournament()
        {
            TournamentRegistry registry = new TournamentRegistry(new MockTournament());
            int id = 7;

            bool result = registry.UpdateTournamentStatus(id, TournamentStatus.Finished);

            Assert.IsTrue(result);
            Assert.AreEqual(TournamentStatus.Finished, registry.GetByID(id)!.Status);
        }

        [TestMethod]
        public void TestCancelTournament()
        {
            TournamentRegistry registry = new TournamentRegistry(new MockTournament());
            int id = 8;

            bool result = registry.UpdateTournamentStatus(id, TournamentStatus.Cancelled);

            Assert.IsTrue(result);
            Assert.AreEqual(TournamentStatus.Cancelled, registry.GetByID(id)!.Status);
        }

        [TestMethod]
        public void TestUpdateTournamentStatusInvalidTournamentID()
        {
            TournamentRegistry registry = new TournamentRegistry(new MockTournament());
            int id = 20;

            bool result = registry.UpdateTournamentStatus(id, TournamentStatus.Cancelled);

            Assert.IsFalse(result);
        }
    }
}
