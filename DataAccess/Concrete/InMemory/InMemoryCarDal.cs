using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car> { 
            
                new Car{Id=1,BrandId=1,ColorId=1,ModelYear=2020,DailyPrice=550,Description="Sedan, dizel 1.5 motor"},
                new Car{Id=2,BrandId=1,ColorId=2,ModelYear=2021,DailyPrice=650,Description="HatchBack, dizel 1.6 motor" },
                new Car{Id=3,BrandId=2,ColorId=4,ModelYear=2019,DailyPrice=400,Description="Station, benzinli 1.5 motor" },
                new Car{Id=4,BrandId=3,ColorId=3,ModelYear=2020,DailyPrice=750,Description=" SUV, elektrikli" }
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c=>c.Id==car.Id);

            _cars.Remove(carToDelete);

        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int id)
        {
           return _cars.Where(c=>c.Id==id).ToList();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);

            carToUpdate.Description = car.Description;
            carToUpdate.DailyPrice = car.DailyPrice;
            
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }
    }
}
 