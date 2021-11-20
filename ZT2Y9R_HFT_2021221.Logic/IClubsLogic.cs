using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZT2Y9R_HFT_2021221.Models;

namespace ZT2Y9R_HFT_2021221.Logic
{
    public interface IClubsLogic
    {
        void changeNumberOfTrophies(int id, int numberOfTrophies);
        void deleteClub(int id);
        Clubs GetClub(int id);
        IQueryable<Clubs> GetAllClubs();
        Clubs InsertNewClub(string name, int NumberOfTrophies);

    }
}
