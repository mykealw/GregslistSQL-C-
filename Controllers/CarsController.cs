using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Davinci.Models;
using Davinci.Services;
using Microsoft.AspNetCore.Authorization;
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


        [HttpGet("{id}")]
        public ActionResult<Car> GetById(int id)
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
        [Authorize]
        public async Task<ActionResult<Car>> CreateCar([FromBody] Car carData)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                carData.CreatorId = userInfo.Id;
                Car newCar = _cs.CreateCar(carData);
                carData.Creator = userInfo;
                return Ok(newCar);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);

            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<String>> Delete(int id)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                _cs.Delete(id, userInfo.Id);
                return Ok("Thats some dangerous racing, deleted");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public ActionResult<Car> EditCar(int id, [FromBody] Car carData)
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