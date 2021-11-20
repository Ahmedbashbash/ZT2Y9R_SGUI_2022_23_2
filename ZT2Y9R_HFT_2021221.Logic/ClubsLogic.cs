using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZT2Y9R_HFT_2021221.Models;
using ZT2Y9R_HFT_2021221.Repository;

namespace ZT2Y9R_HFT_2021221.Logic
{
    public class ClubsLogic : IClubsLogic
    {
        private IClubRepository ClubRepo;

        public ClubsLogic(IClubRepository ClubRepo)
        {
            this.ClubRepo = ClubRepo;
        }

        public void changeNumberOfTrophies(int id, int numberOfTrophies)
        {
            this.ClubRepo.changeNumberOfTrophies(id, numberOfTrophies);
        }

        public void deleteClub(int id)
        {
            Clubs clubs = this.ClubRepo.GetOne(id);
            if (clubs == null)
            {
                throw new InvalidOperationException("ERROR: No corresponding record!");
            }
            else
            {
                this.ClubRepo.Delete(id);
            }
        }

        public IQueryable<Clubs> GetAllClubs()
        {
            return this.ClubRepo.GetAll().AsQueryable();
        }

        public Clubs GetClub(int id)
        {
            Clubs clubs = this.ClubRepo.GetOne(id);
            if (clubs == null)
            {
                throw new InvalidOperationException("ERROR: No corresponding record!");

            }
            return clubs;
        }

        public Clubs InsertNewClub(string name, int NumberOfTrophies)
        {
            Clubs clubs = new Clubs()
            {
                Name = name,
                NumberOfTrophies = NumberOfTrophies

            };
            this.ClubRepo.Add(clubs);
            return clubs;
        }
    }
}
