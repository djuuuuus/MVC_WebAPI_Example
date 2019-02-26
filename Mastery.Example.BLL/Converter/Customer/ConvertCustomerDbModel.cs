using Mastery.Example.BLL.Common.Models.Customer;
using Mastery.Example.DAL.Common.Models.Customer;

namespace Mastery.Example.BLL.Converter.Customer
{
    public class ConvertCustomerDbModel
    {
        public static CustomerModel ToModel(CustomerDbModel model) => new CustomerModel
        {
            Id = model.CustomerId,
            Email = model.Email,
            Age = model.Age,
            FullName = $"{model.FirstName} {model.LastName}"
        };
    }
}
