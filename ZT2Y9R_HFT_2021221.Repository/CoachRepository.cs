using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZT2Y9R_HFT_2021221.Data;
using ZT2Y9R_HFT_2021221.Models;

namespace ZT2Y9R_HFT_2021221.Repository
{
    public class CoachRepository : Repository<Coaches>, ICoachRepository
    {
        public CoachRepository(SuperLeagueDbContext superLeagueDbContext) : base(superLeagueDbContext)
        {
        }

        public override Coaches GetOne(int id)
        {
            return this.GetAll().SingleOrDefault(x => x.CoachId == id);
        }
        public override void Delete(int id)
        {
            Coaches obj = this.GetOne(id);
            this.SuperLeagueDbContext.Set<Coaches>().Remove(obj);
            this.SuperLeagueDbContext.SaveChanges();
        }
        public void changeCoachSalary(int id, int newSalary)
        {
            var coaches = this.GetOne(id);
            if (coaches == null)
            {
                throw new InvalidOperationException("Coach not found");
            }

            coaches.CoachSalary = newSalary;
            this.SuperLeagueDbContext.SaveChanges();
        }
    }
}
