using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Car carToAdd = new Car { Id = 6, BrandId = 6, ColorId = 6, DailyPrice = 1212, ModelYear = 2021, Description = "Mercedes" };

            Car carToUpdate = new Car { Id = 3, BrandId = 15, ColorId = 16, DailyPrice = 5555, ModelYear = 1980, Description = "Devrim" };

            CarManager carManager = new CarManager(new InMemoryCarDal());




            Console.WriteLine("1. durum");

            foreach (var carIter in carManager.GetAll())
            {
                Console.WriteLine(carIter.Description);
            }

            carManager.Add(carToAdd);
            carManager.Delete(2);
            carManager.Update(carToUpdate);

            Console.WriteLine("");


            Console.WriteLine("2. durum");

            foreach (var carIter in carManager.GetAll())
            {
                Console.WriteLine(carIter.Description);
            }

            Console.WriteLine("Id'ye göre getirilen araba : " + carManager.GetById(1).Description);
            //Console.WriteLine("Id'ye göre getirilen araba : " + carManager.GetById(234).Description); // Hata durumu




        }
    }
}
