using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System;

using BLL.Objects;
using BLL.Registries;
using BLL.Enums;
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
            TournamentRegistry tournamentRegistry = new TournamentRegistry(new MockTournament());

            Assert.AreEqual(3, tournamentRegistry.GetAll().Count);
            Assert.IsInstanceOfType(tournamentRegistry.GetAll().ToList(), typeof(List<Tournament>));
        }

        [TestMethod]
        public void TestGetTournament()
        {
            TournamentRegistry tournamentRegistry = new TournamentRegistry(new MockTournament());

            Tournament? tournament = tournamentRegistry.GetByID(1);

            Assert.IsNotNull(tournament);
        }

        [TestMethod]
        public void TestGetNonexistentTournament()
        {
            TournamentRegistry tournamentRegistry = new TournamentRegistry(new MockTournament());

            Tournament? tournament = tournamentRegistry.GetByID(5);

            Assert.IsNull(tournament);
        }

        [TestMethod]
        public void TestCreateTournament()
        {
            TournamentRegistry tournamentRegistry = new TournamentRegistry(new MockTournament());

            int beforeCount = tournamentRegistry.GetAll().Count;
            tournamentRegistry.CreateTournament(new Tournament()
            {
                Title = "Average-Minton",
                Description = "It's also badminton!",
                Sport = "Badminton",
                Scoring = "Points",
                City = "Eindhoven",
                Address = "Eindhovense Straat 1",
                MinContestants = 8,
                MaxContestants = 14,
                StartDate = DateTime.UtcNow.Date,
                EndDate = DateTime.UtcNow.AddDays(7).Date,
                Status = TournamentStatus.Planned,
                System = TournamentSystem.RoundRobin
            });
            int afterCount = tournamentRegistry.GetAll().Count;

            Assert.AreNotEqual(beforeCount, afterCount);
            Assert.AreEqual(afterCount, tournamentRegistry.GetAll().Last().ID);
        }

        [TestMethod]
        public void TestCreateTournamentWithInvalidInput()
        {
            TournamentRegistry tournamentRegistry = new TournamentRegistry(new MockTournament());

            Assert.ThrowsException<ValidationException>(() =>
                tournamentRegistry.CreateTournament(new Tournament()
                {
                    ID = 0,
                    Title = "Mario Kart Grand Prix",
                    Sport = "eGames",
                    Scoring = "Points",
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
            TournamentRegistry tournamentRegistry = new TournamentRegistry(new MockTournament());

            Tournament? tournament = tournamentRegistry.GetByID(1);
            tournamentRegistry.UpdateTournament(new Tournament()
            {
                ID = tournament!.ID,
                Title = "Mario Kart Grand Prix",
                Description = "Now it's karting!",
                Sport = "eGames",
                Scoring = "Cups",
                City = "Eindhoven",
                Address = "Eindhovense Straat 1",
                MinContestants = 4,
                MaxContestants = 8,
                StartDate = DateTime.UtcNow.Date.AddDays(1),
                EndDate = DateTime.UtcNow.Date.AddDays(2),
                Status = TournamentStatus.Finished,
                System = TournamentSystem.RoundRobin
            });
            Tournament? updatedTournament = tournamentRegistry.GetByID(1);

            Assert.IsNotNull(updatedTournament);
            Assert.AreEqual(updatedTournament.ID, tournament!.ID);
            Assert.AreNotEqual(updatedTournament.Title, tournament!.Title);
            Assert.AreNotEqual(updatedTournament.Sport, tournament!.Sport);
            Assert.AreNotEqual(updatedTournament.Scoring, tournament!.Scoring);
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
            TournamentRegistry tournamentRegistry = new TournamentRegistry(new MockTournament());

            Tournament? tournament = tournamentRegistry.GetByID(1);

            Assert.ThrowsException<ValidationException>(() =>
                tournamentRegistry.UpdateTournament(new Tournament()
                {
                    ID = tournament!.ID,
                    Title = "",
                    Sport = "",
                    Scoring = "",
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
            TournamentRegistry tournamentRegistry = new TournamentRegistry(new MockTournament());
            int idToRemove = 1;

            int beforeCount = tournamentRegistry.GetAll().Count;
            bool result = tournamentRegistry.DeleteTournament(idToRemove);
            int afterCount = tournamentRegistry.GetAll().Count;

            Assert.IsTrue(result);
            Assert.AreNotEqual(beforeCount, afterCount);
            Assert.AreNotEqual(idToRemove, tournamentRegistry.GetAll().First().ID);
        }

        [TestMethod]
        public void TestDeleteTournamentNonexistentID()
        {
            TournamentRegistry tournamentRegistry = new TournamentRegistry(new MockTournament());
            int idToRemove = 5;

            int beforeCount = tournamentRegistry.GetAll().Count;
            bool result = tournamentRegistry.DeleteTournament(idToRemove);
            int afterCount = tournamentRegistry.GetAll().Count;

            Assert.IsFalse(result);
            Assert.AreEqual(beforeCount, afterCount);
        }

        [TestMethod]
        public void TestGetLeaderboard()
        {
            TournamentRegistry tournamentRegistry = new TournamentRegistry(new MockTournament());

            List<Contestant> rankings = tournamentRegistry.GetLeaderboard(3).ToList();

            Assert.IsNotNull(rankings);
        }

        [TestMethod]
        public void TestGetLeaderboardNonexistentID()
        {
            TournamentRegistry tournamentRegistry = new TournamentRegistry(new MockTournament());

            List<Contestant> rankings = tournamentRegistry.GetLeaderboard(6).ToList();

            Assert.AreEqual(0, rankings.Count);
        }
    }
}
