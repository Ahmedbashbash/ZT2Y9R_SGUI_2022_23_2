using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZT2Y9R_HFT_2021221.Models;
using ZT2Y9R_HFT_2021221.Repository;

namespace ZT2Y9R_HFT_2021221.Logic
{
    public class PlayersLogic : IPlayersLogic
    {
        private IPlayerRepository PlayerRepo;

        public PlayersLogic(IPlayerRepository PlayerRepo)
        {
            this.PlayerRepo = PlayerRepo;
        }
        public void changePlayerSalary(int id, int newSalary)
        {
            this.PlayerRepo.changePlayerSalary(id, newSalary);
        }

        public void deletePlayer(int id)
        {
            Players players = this.PlayerRepo.GetOne(id);
            if (players == null)
            {
                throw new InvalidOperationException("ERROR: No corresponding record!");
            }
            else
            {
                this.PlayerRepo.Delete(id);
            }
        }

        public IQueryable<Players> GetAllPlayerss()
        {
            return this.PlayerRepo.GetAll().AsQueryable();
        }

        public Players GetPlayer(int id)
        {
            Players players = this.PlayerRepo.GetOne(id);
            if (players == null)
            {
                throw new InvalidOperationException("ERROR: No corresponding record!");

            }
            return players;
        }

        public Players InsertNewPlayer(string name, int age, string postion, int salary)
        {
            Players players = new Players()
            {
                Name = name,
                age = age,
                Position=postion,
                PlayerSalary = salary

            };
            this.PlayerRepo.Add(players);
            return players;
        }
    }
}
