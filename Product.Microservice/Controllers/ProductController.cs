using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Product.Microservice.Models;
using System.Linq;

namespace Product.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private List<Productiv> products = new List<Productiv>();

        public ProductController()
        {
            products.Add(new Productiv { Id = 1, Name = "Iphone11", Money = 100000 });
            products.Add(new Productiv { Id = 2, Name = "Iphone12", Money = 100000 });
            products.Add(new Productiv { Id = 3, Name = "Iphone13", Money = 100000 });
        }

        [HttpGet]
        public JsonResult GetAll()
        {
            return new JsonResult(products);
        }


        [HttpGet("{id}")]
        public JsonResult GetById(int id)
        {
            products = products.Where(p=>p.Id == id).ToList();
            return new JsonResult(products);
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            var prod = products.Where(p => p.Id == id).First();
            products.Remove(prod);
            return new JsonResult(products);
        }
    }
}
