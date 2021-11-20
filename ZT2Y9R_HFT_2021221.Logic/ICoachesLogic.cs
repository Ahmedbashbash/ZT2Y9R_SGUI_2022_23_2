using Microsoft.OData.Edm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZT2Y9R_HFT_2021221.Models;

namespace ZT2Y9R_HFT_2021221.Logic
{
    public interface ICoachesLogic
    {
        void changeCoachSalary(int id, int newSalary);
        void deleteCoache(int id);
        Coaches GetCoach(int id);
        IQueryable<Coaches> GetAllCoaches();
        Coaches InsertNewCoach(string name, int age, int salary, Date CoachHireDate);
    }
}
