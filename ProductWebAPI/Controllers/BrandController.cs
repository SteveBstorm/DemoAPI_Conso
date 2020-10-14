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
    public class BrandController : ControllerBase
    {
        private BrandService _service;

        public BrandController()
        {
            _service = new BrandService();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
           return Ok( _service.GetAll());
        }

        [HttpGet("{Id:int}")]
        //[Route("{Id:int}")]
        public IActionResult GetById(int Id)
        {
            return Ok(_service.Get(Id));
        }


        [HttpPost]
        public IActionResult Ajouter(Brand brand)
        {
            try
            {
                _service.Insert(brand);
            }
            catch(Exception e)
            {
                // return BadRequest("Echec de l'enregistrement");
                return BadRequest(e.Message);
            }
            
            return Ok("Insertion effectuée");
            
        }

        [HttpDelete]
        [Route("{Id}")]
        public IActionResult Delete(int Id)
        {
            if (_service.Delete(Id)) return Ok("Suppression effectuée");
            else return BadRequest("Record non trouvé");
        }

        [HttpPut]
        public IActionResult Update(Brand brand)
        {
            _service.Update(brand);
            return Ok("Update OK");
        }

    }
}