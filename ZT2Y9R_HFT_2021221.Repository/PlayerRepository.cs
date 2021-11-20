using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZT2Y9R_HFT_2021221.Data;
using ZT2Y9R_HFT_2021221.Models;

namespace ZT2Y9R_HFT_2021221.Repository
{
    public class PlayerRepository : Repository<Players>, IPlayerRepository
    {
        public PlayerRepository(SuperLeagueDbContext superLeagueDbContext) : base(superLeagueDbContext)
        {
        }        

        public override Players GetOne(int id)
        {
            return this.GetAll().SingleOrDefault(x => x.PlayerId == id);
        }
        public override void Delete(int id)
        {
            Players obj = this.GetOne(id);
            this.SuperLeagueDbContext.Set<Players>().Remove(obj);
            this.SuperLeagueDbContext.SaveChanges();
        }
        public void changePlayerSalary(int id, int newSalary)
        {
            var players = this.GetOne(id);
            if (players == null)
            {
                throw new InvalidOperationException("Player not found");
            }

            players.PlayerSalary = newSalary;
            this.SuperLeagueDbContext.SaveChanges();
        }
    }
}
