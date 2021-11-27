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
    public class CoachController : ControllerBase
    {
        ICoachesLogic cl;
        public CoachController(ICoachesLogic cl)
        {
            this.cl = cl;
        }


        [HttpGet("{id}")]
        public Coaches Get(int id)
        {
            return cl.GetCoach(id);
        }


        [HttpGet]
        public IEnumerable<Coaches> Get()
        {
            return cl.GetAllCoaches();
        }


        [HttpPut]
        public void Add(string name, int age, int salary)
        {
            cl.InsertNewCoach(name, age, salary, DateTime.Now);
        }


        [HttpPut]
        public void ChangeCoachSalary(int id, int salary)
        {
            cl.changeCoachSalary(id, salary);
        }



        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            cl.deleteCoache(id);
        }
    }
}
