using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    static class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car { BrandId = 1, ColorId = 1, DailyPrice = 41231,
                ModelYear = 1921, Description = "Mercedes" };
            Brand brand = new Brand { Name = "Audi" };
            Color color = new Color { Name = "Blue" };

            CarManager carManager = new CarManager(new EFCarDal());
            BrandManager brandManager = new BrandManager(new EFBrandDal());
            ColorManager colorManager = new ColorManager(new EFColorDal());


            carManager.Add(car);
            brandManager.Add(brand);
            colorManager.Add(color);

            foreach (var carIter in carManager.GetAll().Data)
            {
                Console.WriteLine(carIter.Description);
            }

        }


        private static void Memory()
        {
            Car carToAdd = new Car { Id = 6, BrandId = 6, ColorId = 6, DailyPrice = 1212, ModelYear = 2021, Description = "Mercedes" };

            Car carToUpdate = new Car { Id = 3, BrandId = 15, ColorId = 16, DailyPrice = 5555, ModelYear = 1980, Description = "Devrim" };

            CarManager carManager = new CarManager(new InMemoryCarDal());




            Console.WriteLine("1. durum");

            foreach (var carIter in carManager.GetAll().Data)
            {
                Console.WriteLine(carIter.Description);
            }

            carManager.Add(carToAdd);
            carManager.Delete(carToAdd);
            carManager.Update(carToUpdate);

            Console.WriteLine("");


            Console.WriteLine("2. durum");

            foreach (var carIter in carManager.GetAll().Data)
            {
                Console.WriteLine(carIter.Description);
            }

            //Console.WriteLine("Id'ye göre getirilen araba : " + carManager.GetById(1).Description);
            //Console.WriteLine("Id'ye göre getirilen araba : " + carManager.GetById(234).Description); // Hata durumu
        }
    }
}
