using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Davinci.Models;
using Davinci.Repositories;

namespace Davinci.Services
{
    public class CarsService
    {
        private readonly CarRepository _cr;
        public CarsService(CarRepository cr)
        {
            _cr = cr;
        }
        internal List<Car> GetAll()
        {
            return _cr.GetAll();
        }
        internal Car GetById(int id)
        {
            Car car = _cr.GetById(id);
            if (car == null)
            {
                throw new Exception("Invalid Car Id");
            }
            return car;
        }

        internal Car CreateCar(Car carData)
        {
            return _cr.CreateCar(carData);
        }

        internal void Delete(int id)
        {
            throw new NotImplementedException();
        }

        internal Car EditCar(Car carData)
        {
            throw new NotImplementedException();
        }
    }
}