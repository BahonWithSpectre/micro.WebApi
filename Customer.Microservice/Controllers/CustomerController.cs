using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Customer.Microservice.Models;
using System.Collections.Generic;
using System.Linq;

namespace Customer.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private List<User> users = new List<User>();
        public CustomerController()
        {
            users.Add(new User { Id = 1, Fio = "Shymkentbay B", Addres = "Panfilov, 103/2" });
            users.Add(new User { Id = 2, Fio = "Beysenali Zh", Addres = "Almaty" });
            users.Add(new User { Id = 3, Fio = "Moldabekov A", Addres = "Nur-Sultan" });
        }

        [HttpGet]
        public JsonResult GetAll()
        {
            return new JsonResult(users);
        }


        [HttpGet("{id}")]
        public JsonResult GetById(int id)
        {
            users = users.Where(p => p.Id == id).ToList();
            return new JsonResult(users);
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            var user = users.Where(p => p.Id == id).First();
            users.Remove(user);
            return new JsonResult(users);
        }
    }
}
