using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZT2Y9R_HFT_2021221.Data;

namespace ZT2Y9R_HFT_2021221.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected readonly SuperLeagueDbContext SuperLeagueDbContext;

        public Repository(SuperLeagueDbContext superLeagueDbContext)
        {
            SuperLeagueDbContext = superLeagueDbContext;
        }

        public void Add(T entity)
        {
            SuperLeagueDbContext.Set<T>().Add(entity);

            SuperLeagueDbContext.SaveChanges();
        }

        public abstract void Delete(int id);
        public IQueryable<T> GetAll()
        {
            return SuperLeagueDbContext.Set<T>();
        }

        public abstract T GetOne(int id);
        

        public void Update(T entity)
        {
            SuperLeagueDbContext.Set<T>().Attach(entity);

            SuperLeagueDbContext.SaveChanges();
        }
    }
}
