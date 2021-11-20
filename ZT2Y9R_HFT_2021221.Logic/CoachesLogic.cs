using Microsoft.OData.Edm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZT2Y9R_HFT_2021221.Models;
using ZT2Y9R_HFT_2021221.Repository;

namespace ZT2Y9R_HFT_2021221.Logic
{
    public class CoachesLogic : ICoachesLogic
    {
        private ICoachRepository CoachRepo;

        public CoachesLogic(ICoachRepository CoachRepo)
        {
            this.CoachRepo = CoachRepo;
        }
        public void changeCoachSalary(int id, int newSalary)
        {
            this.CoachRepo.changeCoachSalary(id, newSalary);
        }

        public void deleteCoache(int id)
        {
            Coaches coaches = this.CoachRepo.GetOne(id);
            if (coaches == null)
            {
                throw new InvalidOperationException("ERROR: No corresponding record!");
            }
            else
            {
                this.CoachRepo.Delete(id);
            }
        }

        public IQueryable<Coaches> GetAllCoaches()
        {
            return this.CoachRepo.GetAll().AsQueryable();
        }

        public Coaches GetCoach(int id)
        {
            Coaches coaches = this.CoachRepo.GetOne(id);
            if (coaches == null)
            {
                throw new InvalidOperationException("ERROR: No corresponding record!");

            }
            return coaches;
        }

        public Coaches InsertNewCoach(string name, int age, int salary, Date CoachHireDate)
        {
            Coaches coaches = new Coaches()
            {
                Name = name,
                age = age,
                CoachSalary= salary

            };
            this.CoachRepo.Add(coaches);
            return coaches; 
        }
    }
}
