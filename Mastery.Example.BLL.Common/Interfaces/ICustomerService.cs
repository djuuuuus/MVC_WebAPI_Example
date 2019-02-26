using System;
using System.Collections.Generic;
using Mastery.Example.BLL.Common.Models.Customer;

namespace Mastery.Example.BLL.Common.Interfaces
{
    public interface ICustomerService : IDisposable
    {
        IEnumerable<CustomerModel> GetCustomers();

        CustomerModel CreateCustomers(CustomerRequestModel customer);
    }
}