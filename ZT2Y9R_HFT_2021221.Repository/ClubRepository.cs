using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZT2Y9R_HFT_2021221.Data;
using ZT2Y9R_HFT_2021221.Models;

namespace ZT2Y9R_HFT_2021221.Repository
{
    public class ClubRepository : Repository<Clubs>, IClubRepository
    {
        public ClubRepository(SuperLeagueDbContext superLeagueDbContext) : base(superLeagueDbContext)
        {
        }

        public override Clubs GetOne(int id)
        {
            return this.GetAll().SingleOrDefault(x => x.ClubId == id);
        }

        public void changeNumberOfTrophies(int id, int newTrophy)
        {
            var clubs = this.GetOne(id);
            if (clubs == null)
            {
                throw new InvalidOperationException("Club not found");
            }

            clubs.NumberOfTrophies = newTrophy;
            this.SuperLeagueDbContext.SaveChanges();
        }

        
    }
}
