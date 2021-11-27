using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZT2Y9R_HFT_2021221.Logic;
using ZT2Y9R_HFT_2021221.Models;

namespace ZT2Y9R_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        IPlayersLogic cl;
        public PlayerController(IPlayersLogic cl)
        {
            this.cl = cl;
        }


        [HttpGet("{id}")]
        public Players Get(int id)
        {
            return cl.GetPlayer(id);
        }


        [HttpGet]
        public IEnumerable<Players> Get()
        {
            return cl.GetAllPlayerss();
        }


        [HttpPut]
        public void Add(string name, int age, string postion, int salary)
        {
            cl.InsertNewPlayer(name, age, postion, salary);
        }


        [HttpPut]
        public void Add(int id, int salary)
        {
            cl.changePlayerSalary(id, salary);
        }



        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            cl.deletePlayer(id);
        }
    }
}
