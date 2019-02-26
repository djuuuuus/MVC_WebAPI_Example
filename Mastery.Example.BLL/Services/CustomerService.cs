﻿using System.Collections.Generic;
using System.Linq;
using Mastery.Example.BLL.Common.Interfaces;
using Mastery.Example.BLL.Common.Models.Customer;
using Mastery.Example.BLL.Converter.Customer;
using Mastery.Example.DAL.Common.Interfaces;
using Mastery.Example.DAL.Common.Models.Customer;

namespace Mastery.Example.BLL.Services
{
    public class CustomerService : BaseService.BaseService, ICustomerService
    {
        private readonly IUnitOfWork unitOfWork;

        private readonly IGenericRepository<CustomerDbModel> customerGenericRepository;

        public CustomerService(IUnitOfWork unitOfWork) : base()
        {
            this.unitOfWork = unitOfWork;
            customerGenericRepository = unitOfWork.GetGenericRepository<CustomerDbModel>();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unitOfWork?.Dispose();
            }

            base.Dispose(disposing);
        }

        public IEnumerable<CustomerModel> GetCustomers() =>
            customerGenericRepository.GetQueryAsNoTracking().AsEnumerable().Select(ConvertCustomerDbModel.ToModel);

      
        public CustomerModel CreateCustomers(CustomerRequestModel customer)
        {
            var customerDbModel = ConvertCustomerView.ToDbModel(customer);

            customerGenericRepository.Add(customerDbModel);
            unitOfWork.SaveChanges();

            return ConvertCustomerDbModel.ToModel(customerDbModel);
        }
    }
}
