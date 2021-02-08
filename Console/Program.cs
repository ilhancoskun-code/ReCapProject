
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
            CarManager carManager = new CarManager(new InMemoryCarDal());

            foreach (var car in carManager.GetAll())
            {
                 Console.WriteLine("Markası {0} Rengi {1} Model Yılı {2} Günlük Fiyatı {3} Tanımı {4}",car.BrandId,car.ColorId,car.ModelYear,car.DailyPrice,car.Description);
            }

            Console.WriteLine("**************************");

            foreach (var car in carManager.GetById(3))
            {
                Console.WriteLine("Seçitğiniz araç {0} model yılı olup, {1} fiyatı {2}",car.ModelYear,car.Description,car.DailyPrice);

            }

            Console.WriteLine("**************************");


            CarManager carManager1 = new CarManager(new InMemoryCarDal());
            carManager1.Add( new Car { BrandId=1,ColorId=6,Id=7,DailyPrice=950,Description="En kral aracımz",ModelYear=2021});

            foreach (var car in carManager1.GetAll())
            {
                Console.WriteLine("Markası {0} Rengi {1} Model Yılı {2} Günlük Fiyatı {3} Tanımı {4}", car.BrandId, car.ColorId, car.ModelYear, car.DailyPrice, car.Description);
            }


        }
    }
}
