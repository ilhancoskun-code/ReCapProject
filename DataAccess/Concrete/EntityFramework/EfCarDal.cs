﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentCarDBContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (RentCarDBContext carDBContext= new RentCarDBContext())
            {
                var result = from c in carDBContext.Cars
                             join b in carDBContext.Brands
                              on c.BrandId equals b.Id
                             join cl in carDBContext.Colors
                             on c.ColorId equals cl.Id
                             select new CarDetailDto { CarId=c.Id, CarName = c.Description, BrandName = b.Name, ColorName = cl.Name, DailyPrice = c.DailyPrice,ModelYear=c.ModelYear };

                return result.ToList();
            }
             
        }
    }
}
