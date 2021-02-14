
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;


namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());

            Console.WriteLine("*********** TÜM ARAÇLARI LİSTELEME ***************");

            foreach (var car in carManager.GetAll())
            {
                 Console.WriteLine("Markası {0} Rengi {1} Model Yılı {2} Günlük Fiyatı {3} Tanımı {4}",car.BrandId,car.ColorId,car.ModelYear,car.DailyPrice,car.Description);
            }

            Console.WriteLine("************* ID = 3 OLAN ARAÇLAR *************");


            foreach (var car in carManager.GetCarsByBrandId(1))
            {
                Console.WriteLine("Markası {0} Rengi {1} Model Yılı {2} Günlük Fiyatı {3} Tanımı {4}", car.BrandId, car.ColorId, car.ModelYear, car.DailyPrice, car.Description);
            }

 

            Console.WriteLine("************* Renk ID = 5 OLAN ARAÇLAR *************");


            foreach (var car in carManager.GetCarsByColorId(5))
            {
                Console.WriteLine("Seçitğiniz araç {0} model yılı olup, {1} fiyatı {2}", car.ModelYear, car.Description, car.DailyPrice);
            }


            
            Console.WriteLine("************* LİSTEYE YENİ ARAÇ EKLEME *************");


            CarManager carManager1 = new CarManager(new EfCarDal());
            carManager1.Add( new Car { BrandId=1,ColorId=6,Id=6,DailyPrice=750,Description="Jeep",ModelYear=2021});

            foreach (var car in carManager1.GetAll())
            {
                Console.WriteLine("Markası {0} Rengi {1} Model Yılı {2} Günlük Fiyatı {3} Tanımı {4}", car.BrandId, car.ColorId, car.ModelYear, car.DailyPrice, car.Description);
            }

            Console.WriteLine("************************** HATALI ARAÇA EKLEME ************************");
            carManager1.Add(new Car { BrandId = 1, ColorId = 6, Id = 8, DailyPrice = 0, Description = "Passat", ModelYear = 2021 });

        }
    }
}
