using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZT2Y9R_HFT_2021221.Models;

namespace ZT2Y9R_HFT_2021221.Repository
{
    public interface IBusinessManagerRepository: IRepository<BusinessManagers>
    {
        void changeBusinessManagerSalary(int id, int newSalary);
    }
}
