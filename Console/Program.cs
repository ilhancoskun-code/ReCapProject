
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

            // Car CRUD operasyonları 

            CarManager carManager = new CarManager(new EfCarDal());

            Console.WriteLine("*********** TÜM ARAÇLARI DETAYI İLE LİSTELE - DTO ***************");

            foreach (var car in carManager.GetCarDetails())
            {
                 Console.WriteLine("Modeli {0} Markası {1} Rengi {2} Günlük Fiyatı {3}",car.CarName,car.BrandName,car.ColorName,car.DailyPrice);
            }
            Console.WriteLine("\n\n\n");
            Console.WriteLine("*********** YENİ ARAÇ EKLEME VE GÜNCELLEME SONRASI LİSTE ***************");

            CarManager carManager1 = new CarManager(new EfCarDal());
            carManager1.Add(new Car {Id=8,BrandId=1,ColorId=2,ModelYear=2021,DailyPrice=900,Description="Touareg"});
            carManager1.Update(new Car {Id=7,Description="Bettle",ColorId=4,ModelYear=2020,DailyPrice=750,BrandId=1});

            foreach (var car in carManager1.GetCarDetails())
            {
                Console.WriteLine("Modeli {0} Markası {1} Rengi {2} Günlük Fiyatı {3}", car.CarName, car.BrandName, car.ColorName, car.DailyPrice);
            }


            carManager1.Delete(new Car { Id=8});

            Console.WriteLine("\n\n\n");
            Console.WriteLine("*********** SİLME SONRASI LİSTELEME ***************");

            CarManager carManager2 = new CarManager(new EfCarDal());
            foreach (var car in carManager2.GetCarDetails())
            {
                Console.WriteLine("Modeli {0} Markası {1} Rengi {2} Günlük Fiyatı {3}", car.CarName, car.BrandName, car.ColorName, car.DailyPrice);
            }

            Console.WriteLine("\n\n\n");
            Console.WriteLine("*********** MARKA LİSTELEME ***************");
            //Brand CURD Ooeprasyonları

            BrandManager brandManager = new BrandManager(new EfBrandDal());

            brandManager.Add(new Brand {Id=8,Name = "Jeep" });
            brandManager.Update(new Brand { Id = 7, Name = "Suzuki" });
            brandManager.Delete(new Brand { Id = 8 });

            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine("Marka Id {0} / Markası {1} ", brand.Id,brand.Name);

            }

            Console.WriteLine("\n\n\n");
            Console.WriteLine("*********** RENK LİSTELEME ***************");
            // Color CRUD operasyonları

            ColorManager colorManager = new ColorManager(new EfColorDal());

            colorManager.Add(new Color {Id=7, Name = "Bej" });
            colorManager.Update(new Color {Id=5,Name="Kırmızı"});
            colorManager.Delete(new Color {Id=7});

            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine("Renk ID: {0} -- Renk : {1}", color.Id,color.Name);
            }

            /*
             Bu kısım önceki ödevden kalma o yüzden commentlediö
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
            carManager1.Add(new Car { BrandId = 1, ColorId = 6, Id = 6, DailyPrice = 750, Description = "Jeep", ModelYear = 2021 });

            foreach (var car in carManager1.GetAll())
            {
                Console.WriteLine("Markası {0} Rengi {1} Model Yılı {2} Günlük Fiyatı {3} Tanımı {4}", car.BrandId, car.ColorId, car.ModelYear, car.DailyPrice, car.Description);
            }

            Console.WriteLine("************************** HATALI ARAÇA EKLEME ************************");
            carManager1.Add(new Car { BrandId = 1, ColorId = 6, Id = 8, DailyPrice = 0, Description = "Passat", ModelYear = 2021 });
            */

        }
    }
}
