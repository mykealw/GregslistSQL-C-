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
        FROM cars c
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

        internal void Delete(int id)
        {
            string sql = "DELETE FROM cars WHERE id = @id LIMIT 1;";
            _db.Execute(sql, new { id });
        }

        internal Car GetById(int id)
        {
            string sql = @"
            SELECT 
            c.*,
            act.*
            FROM cars c
            Join accounts act ON c.creatorId = act.Id
            WHERE c.id = @id;";
            return _db.Query<Car, Account, Car>(sql, (car, account) =>
            {
                car.Creator = account;
                return car;
            }, new { id }).FirstOrDefault();
        }

        internal void Edit(Car original)
        {

            string sql = @"
                UPDATE cars SET 
                color = @Color,
                model = @Model,
                make = @Make,
                imgUrl = @ImgUrl
                WHERE id = @Id;
                ";
            _db.Execute(sql, original);
        }
    }
}