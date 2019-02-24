using Mystery.Example.BLL.Common.Interfaces;
using Mystery.Example.BLL.Common.Models.Customer;
using Mystery.Example.BLL.Conveter.Customer;
using Mystery.Example.DAL.Common.Interfaces;
using Mystery.Example.DAL.Common.Models.Customer;
using System.Collections.Generic;
using System.Linq;

namespace Mystery.Example.BLL.Services
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
