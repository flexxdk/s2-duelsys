﻿using BLL.Validation;
using BLL.Enums;
using BLL.Objects;
using DAL.Interfaces;
using DTO;
using DTO.Users;
using BLL.Objects.Users;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Globalization;

namespace BLL.Registries
{
    public class TournamentRegistry : BaseRegistry
    {
        private readonly ITournamentRepository repository;
        private Dictionary<int, Tournament> tournaments;

        public TournamentRegistry(ITournamentRepository repository, bool preload = false)
        {
            this.repository = repository;
            this.tournaments = new Dictionary<int, Tournament>();
            if(preload) LoadTournaments();
        }

        public void LoadTournaments()
        {
            tournaments.Clear();
            foreach (TournamentDTO dto in repository.Load())
            {
                AddToDictionary(InstantiateTournament(dto));
            }
        }

        public IList<Tournament> GetAll(bool refresh)
        {
            if (refresh) LoadTournaments();
            return tournaments.Values.ToList();
        }

        public Tournament? GetByID(int id)
        {
            if (tournaments.ContainsKey(id))
            {
                return tournaments[id];
            }
            else
            {
                TournamentDTO? dto = repository.GetByID(id);
                if(dto != null)
                {
                    AddToDictionary(InstantiateTournament(dto));
                    return tournaments[id];
                }
            }
            return null;
        }

        public bool CreateTournament(Tournament tournament)
        {
            try
            {
                ValidateModel(tournament);
                TournamentDTO dto = new TournamentDTO(0, tournament.Title!, tournament.Description!, tournament.Sport!, tournament.Type.ToString(), tournament.Scoring!, tournament.City!, tournament.Address!, tournament.MinContestants, tournament.MaxContestants, tournament.StartDate.ToString("d"), tournament.EndDate.ToString("d"), tournament.Status.ToString(), tournament.System.ToString());
                int ID = repository.Create(dto);
                if(ID == 0)
                {
                    return false;
                }
                tournament.ID = ID;
                return AddToDictionary(tournament);

            }
            catch
            {
                throw;
            }
        }

        public bool UpdateTournament(Tournament tournament)
        {
            try
            {
                ValidateModel(tournament);
                bool found = tournaments.ContainsKey(tournament.ID);
                if (found) 
                {
                    tournaments[tournament.ID] = tournament;
                    repository.Update(InstantiateDTO(tournament));
                }
                return found;
            }
            catch
            {
                throw;
            }
        }

        public bool DeleteTournament(int id)
        {
            try
            {
                if (id > 0)
                {
                    if (tournaments.ContainsKey(id))
                    {
                        tournaments.Remove(id);
                        return repository.Delete(id);
                    }
                }
                return false;
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<Tournament> GetActiveTournaments()
        {
            IList<Tournament> tournaments = new List<Tournament>();
            foreach (TournamentDTO dto in repository.FilterTournamentsOnStatus(TournamentStatus.Planned.ToString()))
            {
                tournaments.Add(InstantiateTournament(dto));
            }
            return tournaments;
        }

        public IList<Contestant> GetLeaderboard(int tournamentID)
        {
            List<Contestant> contestants = new List<Contestant>();
            foreach (ContestantDTO dto in repository.GetStandings(tournamentID))
            {
                contestants.Add(new Contestant()
                {
                    ID = dto.ID,
                    Name = dto.Name,
                    SurName = dto.SurName,
                    TournamentID = dto.TournamentID,
                    Wins = dto.Wins,
                    Losses = dto.Losses,
                });
            }
            CalculateRankings(contestants);
            return contestants;
        }

        private void CalculateRankings(List<Contestant> contestants)
        {
            for (int i = 0; i < contestants.Count; i++)
            {
                contestants[i].Rank = i + 1;
                if (i > 0)
                {
                    if (contestants[i].Wins == contestants[i - 1].Wins && contestants[i].Losses == contestants[i - 1].Losses)
                    {
                        contestants[i].Rank = contestants[i - 1].Rank;
                    }
                }
            }
        }

        private Tournament InstantiateTournament(TournamentDTO dto)
        {
            return new Tournament()
            {
                ID = dto.ID,
                Title = dto.Title,
                Description = dto.Description,
                Sport = dto.Sport,
                Scoring = dto.Scoring,
                City = dto.City,
                Address = dto.Address,
                MinContestants = dto.MinContestants,
                MaxContestants = dto.MaxContestants,
                StartDate = DateTime.Parse(dto.StartDate, new CultureInfo("nl-NL")),
                EndDate = DateTime.Parse(dto.EndDate, new CultureInfo("nl-NL")),
                Status = (TournamentStatus)Enum.Parse(typeof(TournamentStatus), dto.Status),
                System = (TournamentSystem)Enum.Parse(typeof(TournamentSystem), dto.System)
            };
        }

        private TournamentDTO InstantiateDTO(Tournament obj)
        {
            return new TournamentDTO(obj.ID, obj.Title, obj.Description, obj.Sport, obj.Type.ToString(), obj.Scoring, obj.City, obj.Address, obj.MinContestants, obj.MaxContestants, obj.StartDate.ToString("d"), obj.EndDate.ToString("d"), obj.Status.ToString(), obj.System.ToString());
        }



        private bool AddToDictionary(Tournament tournament)
        {
            return tournaments.TryAdd(tournament.ID, tournament);
        }

        private void ValidateModel(Tournament model)
        {
            IList<string> errors = new List<string>();
            if (model.MaxContestants < model.MinContestants)
            {
                errors.Add("The maximum contestants needs to be at least equal to the minimum contestants");
            }
            if (model.StartDate > model.EndDate)
            {
                errors.Add("End date must be set after start date");
            }
            base.ValidateModel(model, errors);
        }
    }
}
