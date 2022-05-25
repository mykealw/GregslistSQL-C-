using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Davinci.Models;
using Davinci.Services;
using Microsoft.AspNetCore.Mvc;

namespace Davinci.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : ControllerBase
    {
        private readonly CarsService _cs;

        public CarsController(CarsService cs)
        {
            _cs = cs;
        }

        [HttpGet]
        public ActionResult<List<Car>> GetAll()
        {
            try
            {
                List<Car> cars = _cs.GetAll();
                return Ok(cars);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        private ActionResult<List<Car>> BadRequest(string message)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        public ActionResult<Car> GetById(string id)
        {
            try
            {
                Car car = _cs.GetById(id);
                return Ok(car);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpPost]
        public ActionResult<Car> CreateCar([FromBody] Car carData)
        {
            try
            {
                Car newCar = _cs.CreateCar(carData);
                return Ok(newCar);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);

            }
        }

        [HttpDelete("{id}")]
        public ActionResult<String> Delete(string id)
        {
            try
            {
                _cs.Delete(id);
                return Ok("Thats some dangerous racing, deleted");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Car> EditCar(string id, [FromBody] Car carData)
        {
            try
            {
                carData.Id = id;
                Car updated = _cs.EditCar(carData);
                return Ok(updated);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }







    }
}