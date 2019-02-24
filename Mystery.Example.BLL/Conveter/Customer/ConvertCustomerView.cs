using Mystery.Example.BLL.Common.Models.Customer;
using Mystery.Example.DAL.Common.Models.Customer;

namespace Mystery.Example.BLL.Conveter.Customer
{
    public class ConvertCustomerView
    {
        public static CustomerDbModel ToDbModel(CustomerRequestModel model) => new CustomerDbModel
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            Email = model.Email,
            Age = model.Age
        };
    }
}
