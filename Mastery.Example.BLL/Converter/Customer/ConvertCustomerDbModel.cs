using Mastery.Example.DAL.Common.Models.Customer;
using Mystery.Example.BLL.Common.Models.Customer;

namespace Mystery.Example.BLL.Converter.Customer
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
