using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZT2Y9R_HFT_2021221.Data;
using ZT2Y9R_HFT_2021221.Models;

namespace ZT2Y9R_HFT_2021221.Repository
{
    public class BusinessManagerRepository : Repository<BusinessManagers>, IBusinessManagerRepository
    {
        public BusinessManagerRepository(SuperLeagueDbContext superLeagueDbContext) : base(superLeagueDbContext)
        {
        }

        public override BusinessManagers GetOne(int id)
        {
            return this.GetAll().SingleOrDefault(x => x.BusinessManagerId == id);
        }
        public void changeBusinessManagerSalary(int id, int newSalary)
        {
            var businessManagers = this.GetOne(id);
            if (businessManagers == null)
            {
                throw new InvalidOperationException("Business Manager not found");
            }

            businessManagers.Salary = newSalary;
            this.SuperLeagueDbContext.SaveChanges();
        }
    }
}
