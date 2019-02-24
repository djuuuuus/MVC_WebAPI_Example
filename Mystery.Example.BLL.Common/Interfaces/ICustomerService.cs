using Mystery.Example.BLL.Common.Models.Customer;
using System;
using System.Collections.Generic;

namespace Mystery.Example.BLL.Common.Interfaces
{
    public interface ICustomerService : IDisposable
    {
        IEnumerable<CustomerModel> GetCustomers();

        CustomerModel CreateCustomers(CustomerRequestModel customer);
    }
}