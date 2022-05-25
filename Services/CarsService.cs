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

        internal void Delete(int id, string userId)
        {
            Car car = GetById(id);
            if (car.CreatorId != userId)
            {
                throw new Exception("you do not own this Car");
            }
            _cr.Delete(id);
        }

        internal Car EditCar(Car carData)
        {

            Car original = GetById(carData.Id);
            if (original.CreatorId != carData.CreatorId)
            {
                throw new Exception("you dont own this");
            }
            original.Color = carData.Color ?? original.Color;
            original.Model = carData.Model ?? original.Model;
            original.Make = carData.Make ?? original.Make;
            original.ImgUrl = carData.ImgUrl ?? original.ImgUrl;

            _cr.Edit(original);

            return GetById(original.Id);
        }
    }
}