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
    public class BusinessManagerController : ControllerBase
    {
        IBusinessManagerLogic cl;
        public BusinessManagerController(IBusinessManagerLogic cl)
        {
            this.cl = cl;
        }


        [HttpGet]
        public IEnumerable<BusinessManagers> Get()
        {
            return cl.GetAllBusinessManagers();
        }


        [HttpGet("{id}")]
        public BusinessManagers Get(int id)
        {
            return cl.GetBusinessManager(id);
        }


        [HttpPut]
        public void Add(string name, int age, int salary)
        {
            cl.InsertNewBusinessManager(name, age, salary);
        }


        [HttpPut]
        public void ChangeBusinessManagerSalary(int id, int salary)
        {
            cl.changeBusinessManagerSalary(id, salary);
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            cl.deleteBusinessManager(id);
        }

    }
}
