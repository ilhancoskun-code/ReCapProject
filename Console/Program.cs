
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;


namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

            Menu();



        }
        private static void Menu()
        {
            Console.WriteLine("*** Araç Kiralama Sistemi***");
            Console.WriteLine("\n");
            Console.WriteLine("[1] ARAÇ LİSTESİ");
            Console.WriteLine("[2] KAYIT OL");
            Console.WriteLine("[3] MÜŞTERİ OL");
            Console.WriteLine("[4] ARAÇ KİRALA");
            Console.WriteLine("[5] ARAÇ KİRALAMA DÖNÜŞÜ");
            Console.WriteLine("[6] ARAÇ DURUM LİSTESİ");
            Console.WriteLine("[7] ÇIKIŞ");
            Console.WriteLine("\n");
            Console.WriteLine("Seçiminiz [ 1 ... 7 ] ?");
            int secim = int.Parse(Console.ReadLine());

            switch (secim)
            {
                case 1:
                    ListCars();
                    break;
                case 2:
                    UserAdd();
                    break;
                case 3:
                    CustomerAdd();
                    break;
                case 4:
                    RentalAdd();
                    break;
                case 5:
                    RentalReturn();
                    break;
                case 6:
                    ListAllRentalDetails();
                    break;
                case 7:
                    Exit();
                    break;
                default:
                    break;
            }
        }
        private static void ListCars()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarDetails();
            foreach (var car in result.Data)
            {
                Console.WriteLine(" Araç Id:{0} \n Model:{1} \n Marka:{2} \n ModelYılı:{3} \n Renk:{4} \n Günlük Fiyat:{5} ", car.CarId, car.CarName, car.BrandName, car.ModelYear, car.ColorName, car.DailyPrice);
                Console.WriteLine("*********************************************************");

            }

            Menu();
        }

        private static void UserAdd()
        {
            User user = new User();
            Console.WriteLine("First Name: ");
            user.FirstName = Console.ReadLine();
            Console.WriteLine("Last Name: ");
            user.LastName = Console.ReadLine();
            Console.WriteLine("Email: ");
            user.Email = Console.ReadLine();
            Console.WriteLine("Password : ");
            user.Password = Console.ReadLine();

            UserManager userManager = new UserManager(new EfUserDal());

            Console.WriteLine(userManager.Add(user).Message);

            Menu();


        }
        private static void CustomerAdd()
        {
            Customer customer = new Customer();
            Console.WriteLine("Kullanıcı Id");
            customer.UserId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Şirket Adı");
            customer.CompanyName = Console.ReadLine();

            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            Console.WriteLine(customerManager.Add(customer).Message);

            Menu();
        }

        private static void RentalAdd( )
        {
            Rental rental = new Rental();


            Console.WriteLine("Car Id: ");
            rental.CarId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Customer Id: ");
            rental.CustomerId = Convert.ToInt32(Console.ReadLine());
            rental.RentDate = DateTime.Now;
 

            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            Console.WriteLine(rentalManager.Add(rental).Message);
            Console.WriteLine("\n ***************************************************");

            // Id, CarName, UserName, CopmanyName, RentDate, ReturnDate
            foreach (var rentalDeatil in rentalManager.GetRentalDetails().Data)
            {
                Console.WriteLine("Kiralama ID:{0} \n Kiralayan:{1} \n Şirketi:{2} \n Araç:{3} \n Kiralama Tarihi:{4} \n Dönüş Tarihi: {5} \n ",rentalDeatil.Id,rentalDeatil.UserName,rentalDeatil.CompanyName, rentalDeatil.CarName,rentalDeatil.RentDate,rentalDeatil.ReturnDate);

            }
            Menu();
        }

        private static void RentalReturn()
        {
            Rental rental = new Rental();
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            Console.WriteLine("Lütfen dönüş kaydı yapılacak kiralama ID'sini seçiniz:");
            int activeId = Convert.ToInt32(Console.ReadLine());
            ListSpecificRentalDetails(activeId);

            var result=rentalManager.GetById(activeId).Data;

            rental.Id = activeId;
            rental.CarId = result.CarId;
            rental.CustomerId = result.CustomerId;
            rental.RentDate = result.RentDate;
            rental.ReturnDate = DateTime.Now;
                      

            Console.WriteLine( rentalManager.Update(rental).Message);

            ListSpecificRentalDetails(activeId);
            Menu();

        }

        private static void ListSpecificRentalDetails(int id)
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            var result = rentalManager.GetRentalDetails(r=>r.Id==id);
            foreach (var rentalDetail in result.Data)
            {
                Console.WriteLine("Kiralama ID:{0} \n Kiralayan:{1} \n Şirketi:{2} \n Araç:{3} \n Kiralama Tarihi:{4} \n Dönüş Tarihi{5}:\n ", rentalDetail.Id, rentalDetail.UserName, rentalDetail.CompanyName, rentalDetail.CarName, rentalDetail.RentDate, rentalDetail.ReturnDate);
            }


        }


        private static void ListAllRentalDetails()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            var result = rentalManager.GetRentalDetails();
            foreach (var rentalDetail in result.Data)
            {
                Console.WriteLine("Kiralama ID:{0} \n Kiralayan:{1} \n Şirketi:{2} \n Araç:{3} \n Kiralama Tarihi:{4} \n Dönüş Tarihi{5}:\n ", rentalDetail.Id, rentalDetail.UserName, rentalDetail.CompanyName, rentalDetail.CarName, rentalDetail.RentDate, rentalDetail.ReturnDate);
            }

            Menu();
        }




        private static void Exit()
        {
            Console.Write("Tekrar bekleriz");
        }
        // CarId, CarName, BrandName, ColorName, DailyPrice

        //CarTest();
        //BrandTest();

        /*
        //Bu kısım önceki ödevden kalma o yüzden commentlediö
        CarManager carManager = new CarManager();
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
        private static void BrandTest()
            {
                //Brand CURD Ooeprasyonları

                BrandManager brandManager = new BrandManager(new EfBrandDal());

                brandManager.Add(new Brand { Id = 8, Name = "Jeep" });
                brandManager.Update(new Brand { Id = 7, Name = "Suzuki" });
                brandManager.Delete(new Brand { Id = 8 });

                foreach (var brand in brandManager.GetAll().Data)
                {
                    Console.WriteLine("Marka Id {0} / Markası {1} ", brand.Id, brand.Name);

                }

                Console.WriteLine("\n\n\n");
                Console.WriteLine("*********** RENK LİSTELEME ***************");
                // Color CRUD operasyonları

                ColorManager colorManager = new ColorManager(new EfColorDal());

                colorManager.Add(new Color { Id = 7, Name = "Bej" });
                colorManager.Update(new Color { Id = 5, Name = "Kırmızı" });
                colorManager.Delete(new Color { Id = 7 });

                foreach (var color in colorManager.GetAll().Data)
                {
                    Console.WriteLine("Renk ID: {0} -- Renk : {1}", color.Id, color.Name);
                }
            }

            private static void CarTest()
            {
                // Car CRUD operasyonları 

                CarManager carManager = new CarManager(new EfCarDal());

                Console.WriteLine("*********** TÜM ARAÇLARI DETAYI İLE LİSTELE - DTO ***************");

                var result = carManager.GetCarDetails();

                if (result.Success == true)
                {
                    foreach (var car in result.Data)
                    {
                        Console.WriteLine("Modeli {0} Markası {1} Rengi {2} Günlük Fiyatı {3}", car.CarName, car.BrandName, car.ColorName, car.DailyPrice);
                    }
                }
                else
                {
                    Console.WriteLine(result.Message);
                }

                Console.WriteLine("\n\n\n");
                Console.WriteLine("*********** YENİ ARAÇ EKLEME VE GÜNCELLEME SONRASI LİSTE ***************");

                CarManager carManager1 = new CarManager(new EfCarDal());
                var result2 = carManager1.GetCarDetails();
                carManager1.Add(new Car { Id = 8, BrandId = 1, ColorId = 2, ModelYear = 2021, DailyPrice = 900, Description = "Touareg" });
                carManager1.Update(new Car { Id = 7, Description = "Bettle", ColorId = 4, ModelYear = 2020, DailyPrice = 750, BrandId = 1 });


                foreach (var car in carManager1.GetCarDetails().Data)
                {
                    Console.WriteLine("Modeli {0} Markası {1} Rengi {2} Günlük Fiyatı {3}", car.CarName, car.BrandName, car.ColorName, car.DailyPrice);
                }


                carManager1.Delete(new Car { Id = 8 });

                Console.WriteLine("\n\n\n");
                Console.WriteLine("*********** SİLME SONRASI LİSTELEME ***************");

                CarManager carManager2 = new CarManager(new EfCarDal());
                foreach (var car in carManager2.GetCarDetails().Data)
                {
                    Console.WriteLine("Modeli {0} Markası {1} Rengi {2} Günlük Fiyatı {3}", car.CarName, car.BrandName, car.ColorName, car.DailyPrice);
                }

                Console.WriteLine("\n\n\n");
                Console.WriteLine("*********** MARKA LİSTELEME ***************");
            }

        
    }
}