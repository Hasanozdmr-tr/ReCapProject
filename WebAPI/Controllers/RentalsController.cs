﻿using Business.Abstract;
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
    public class RentalsController : ControllerBase
    {
        IRentalService _rentalService;
        public RentalsController(IRentalService rentalService)
        {

            _rentalService = rentalService;

        }

        [HttpPost("Add")]
        public IActionResult Add(Rental rental)
        {

            var result = _rentalService.Add(rental);
            if (result.Success)
                return Ok(result.Message);
            else
                return Ok(result.Message);
        }

        [HttpPost("Update")]
        public IActionResult Update(Rental rental)
        {

            var result = _rentalService.Update(rental);
            if (result.Success)
                return Ok(result.Message);
            else
                return Ok(result.Message);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(Rental rental)
        {

            var result = _rentalService.Delete(rental);
            if (result.Success)
                return Ok(result.Message);
            else
                return Ok(result.Message);
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {

            var result = _rentalService.GetAll();
            if (result.Success)

                return Ok(result.Data);
            else
                return Ok(result.Message);


        }

        [HttpGet("GetRentalDetails")]
        public IActionResult GetRentalDetails()
      {

            var result = _rentalService.GetRentalDetails();
            if (result.Success)

                return Ok(result);
            else
                return Ok(result.Message);


        }
    }
}

