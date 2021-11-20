using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZT2Y9R_HFT_2021221.Models;

namespace ZT2Y9R_HFT_2021221.Logic
{
    public interface IPlayersLogic
    {
        void changePlayerSalary(int id, int newSalary);
        void deletePlayer(int id);
        Players GetPlayer(int id);
        IQueryable<Players> GetAllPlayerss();
        Players InsertNewPlayer(string name, int age, string postion, int salary);
    }
}
