using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Davinci.Models;

namespace Davinci.Repositories
{
    public class CarRepository
    {
        private readonly IDbConnection _db;

        public CarRepository(IDbConnection db)
        {
            _db = db;
        }

        internal List<Car> GetAll()
        {
            string sql = @"
        SELECT
        c.*,
        act.*
        FROM car c
        JOIN accounts act On c.creatorId = act.id;
        ";
            return _db.Query<Car, Account, Car>(sql, (car, account) =>
            {
                car.Creator = account;
                return car;
            }).ToList();
        }

        internal Car CreateCar(Car carData)
        {
            string sql = @"
            INSERT INTO cars
            (title, imgUrl, createId)
            VALUES
            (@Model, @Make, @Year, @Color, @Price, @ImgUrl, @CreatorId, @Creator);
            SELECT LAST_INSERT_ID();
            ";
            carData.Id = _db.ExecuteScalar<int>(sql, carData);
            return carData;
        }

        internal Car GetById(int id)
        {
            string sql = @"
            SELECT 
            c.*,
            act.*
            FROM car c
            Join accounts act ON c.creatorId = act.Id
            WHERE c.id = @id;";
            return _db.Query<Car, Account, Car>(sql, (car, account) =>
            {
                car.Creator = account;
                return car;
            }, new { id }).FirstOrDefault();
        }
    }
}