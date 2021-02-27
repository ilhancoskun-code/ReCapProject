using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;
        
        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }
    

        public IResult Add(Customer customer)
        {
            var  result=_customerDal.Get(c=>c.UserId==customer.UserId);
            if (result==null)
            {
                _customerDal.Add(customer);
                return new SuccessResult(Messages.CustomerdAdded);
            }

            return new ErrorResult(Messages.NotRegistered);
           
        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult(Messages.CustomerDeleted);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll());
            
        }

        public IDataResult<Customer> GetById(int userId)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(c=>c.UserId==userId));
        }

        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult(Messages.CustomerUpdated);
        }
    }
}
