using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZT2Y9R_HFT_2021221.Models;
using ZT2Y9R_HFT_2021221.Repository;

namespace ZT2Y9R_HFT_2021221.Logic
{
    public class BusinessManagerLogic : IBusinessManagerLogic
    {
        private IBusinessManagerRepository BusinessManagerRepo;

        public BusinessManagerLogic(IBusinessManagerRepository BusinessManagerRepo)
        {
            this.BusinessManagerRepo = BusinessManagerRepo;
        }

        public void changeBusinessManagerSalary(int id, int newSalary)
        {
            this.BusinessManagerRepo.changeBusinessManagerSalary(id, newSalary);
        }       

        public void deleteBusinessManager(int id)
        {
            BusinessManagers businessManager = this.BusinessManagerRepo.GetOne(id);
            if (businessManager == null)
            {
                throw new InvalidOperationException("ERROR: No corresponding record!");
            }
            else
            {
                this.BusinessManagerRepo.Delete(id);
            }
        }        

        public IQueryable<BusinessManagers> GetAllBusinessManagers()
        {
            return this.BusinessManagerRepo.GetAll().AsQueryable();
        }

        public BusinessManagers GetBusinessManager(int id)
        {
            BusinessManagers businessManagers = this.BusinessManagerRepo.GetOne(id);
            if (businessManagers == null)
            {
                throw new InvalidOperationException("ERROR: No corresponding record!");

            }
            return businessManagers;
        }             

        public BusinessManagers InsertNewBusinessManager(string name, int age, int salary)
        {
            BusinessManagers businessManagers = new BusinessManagers()
            {
                Name = name,
                age = age,
                Salary = salary

            };
            this.BusinessManagerRepo.Add(businessManagers);
            return businessManagers;
        }
    }
}
