using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZT2Y9R_HFT_2021221.Models;

namespace ZT2Y9R_HFT_2021221.Logic
{
    public interface IBusinessManagerLogic
    {
        void changeBusinessManagerSalary(int id, int newSalary);
        void deleteBusinessManager(int id);
        BusinessManagers GetBusinessManager(int id);
        IQueryable<BusinessManagers> GetAllBusinessManagers();
        BusinessManagers InsertNewBusinessManager(string name, int age, int salary);
    }
}
