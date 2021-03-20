using Business.Abstract;
using Business.Concrete;
using Core.Utilities;
using DataAccess.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
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
        //[Authorize(Roles = "Admin,CarAdd")]
        public IActionResult Add(Car car)
        {
           
            var result = _carService.Add(car);
            if (result.Success)
             return Ok(result.Message);
            else
             return Ok(result.Message);
        }

        [HttpPost("Update")]
        //[Authorize(Roles = "Admin")]
        public IActionResult Update(Car car)
        {

            var result = _carService.Update(car);
            if (result.Success)
                return Ok(result.Message);
            else
                return Ok(result.Message);
        }

        [HttpPost("Delete")]
        //[Authorize(Roles = "Admin")]
        public IActionResult Delete(Car car)
        {

            var result = _carService.Delete(car);
            if (result.Success)
                return Ok(result.Message);
            else
                return Ok(result.Message);
        }
        [HttpGet("GetAll")]
        //[Authorize(Roles = "CarList,Admin")]
        public IActionResult GetAll()
        {
            
            var result = _carService.GetAll();
            if(result.Success)

                return Ok(result);
            else
                return Ok(result.Message);

       
        }

        [HttpGet("GetById")]
        //[Authorize(Roles = "Admin")]
        public IActionResult GetById(int Id)
        {

            var result = _carService.Get(Id);
            if (result.Success)

                return Ok(result.Data);
            else
                return BadRequest(result.Message);


        }

        [HttpGet("GetAllCarDetails")]
        //[Authorize(Roles = "Admin")]
        public IActionResult GetAllCarDetails()
        {

            var result = _carService.GetAllCarDetails();
            if (result.Success)

                return Ok(result);
            else
                return Ok(result.Message);


        }



    }
    
}
