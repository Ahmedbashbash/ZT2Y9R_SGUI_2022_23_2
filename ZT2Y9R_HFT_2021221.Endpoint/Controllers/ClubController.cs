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
    public class ClubController : ControllerBase
    {
        IClubsLogic cl;
        public ClubController(IClubsLogic cl)
        {
            this.cl = cl;
        }


        [HttpGet("{id}")]
        public Clubs Get(int id)
        {
            return cl.GetClub(id);
        }


        [HttpGet]
        public IEnumerable<Clubs> Get()
        {
            return cl.GetAllClubs();
        }


        


        [HttpPost]
        public void Add(string name, int numberOfTrophies)
        {
            cl.InsertNewClub(name, numberOfTrophies);
        }

        [HttpPut]
        public void changeNumberOfTrophies(int Id, int numberofTrophies)
        {
            cl.changeNumberOfTrophies(Id, numberofTrophies);
        }



        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            cl.deleteClub(id);
        }
    }
}
