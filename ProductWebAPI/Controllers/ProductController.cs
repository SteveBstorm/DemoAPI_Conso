using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoDAL.DAL.Models;
using DemoDAL.DAL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProductWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        ProductService _service;

        public ProductController()
        {
            _service = new ProductService();
        }

        [HttpGet]
        public IEnumerable<Product> GetAll()
        {
            return _service.GetAll();
        }

        [HttpGet("{Id}")]
        public Product GetById(int Id)
        {
            return _service.Get(Id);
        }

        [HttpPost]
        public void Insert(Product p)
        {
            _service.Insert(p);
        }

        [HttpPut]
        public void Update(Product p)
        {
            _service.Update(p);
        }

        [HttpDelete("{Id}")]
        public void Delete(int Id)
        {
            _service.Delete(Id);
        }
    }
}