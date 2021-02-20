using Business.Abstract;
using Business.Concrete;
using Core.Utilities;
using DataAccess.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {

        ICarService _carService;
        public CarsController(ICarService carService)
        {

            _carService = carService;

        }

        [HttpPost("Add")]  
        public IActionResult Add(Car car)
        {
           
            var result = _carService.Add(car);
            if (result.Success)
             return Ok(result.Message);
            else
             return Ok(result.Message);
        }

        [HttpPost("Update")]
        public IActionResult Update(Car car)
        {

            var result = _carService.Update(car);
            if (result.Success)
                return Ok(result.Message);
            else
                return Ok(result.Message);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(Car car)
        {

            var result = _carService.Delete(car);
            if (result.Success)
                return Ok(result.Message);
            else
                return Ok(result.Message);
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            
            var result = _carService.GetAll();
            if(result.Success)

                return Ok(result.Data);
            else
                return Ok(result.Message);

       
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int Id)
        {

            var result = _carService.Get(Id);
            if (result.Success)

                return Ok(result.Data);
            else
                return BadRequest(result.Message);


        }

    }
    
}
