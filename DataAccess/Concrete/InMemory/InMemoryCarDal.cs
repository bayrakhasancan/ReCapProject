using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car { Id = 1 , BrandId = 1, ColorId = 1 , DailyPrice = 100 , ModelYear = 1990, Description ="BMW"} ,
                new Car { Id = 2 , BrandId = 2, ColorId = 2 , DailyPrice = 200 , ModelYear = 2000, Description ="Audi"} ,
                new Car { Id = 3 , BrandId = 3, ColorId = 3 , DailyPrice = 300 , ModelYear = 2006, Description ="Bugatti"} ,
                new Car { Id = 4 , BrandId = 4, ColorId = 4 , DailyPrice = 400 , ModelYear = 2010, Description ="Aston Martin"} ,
                new Car { Id = 5 , BrandId = 5, ColorId = 5 , DailyPrice = 500 , ModelYear = 2020, Description ="Cadillac"}
            };
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public Car GetById(uint carId)
        {
            Car car = _cars.FirstOrDefault(x => x.Id == carId);

            if (car == null)
            {
                throw new Exception("Car not found!");
            }

            return car;
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(ushort carId)
        {
            Car carToDelete = _cars.FirstOrDefault(x => x.Id == carId);

            if (carToDelete == null)
            {
                throw new Exception("Car not found!");
            }

            _cars.Remove(carToDelete);
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.FirstOrDefault(x => x.Id == car.Id);

            if (carToUpdate == null)
            {
                throw new Exception("Car not found!");
            }

            carToUpdate.Id = car.Id;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;
        }
    }
}
