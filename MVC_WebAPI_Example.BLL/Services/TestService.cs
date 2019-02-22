using MVC_WebAPI_Example.BLL.Common.Interfaces;

namespace MVC_WebAPI_Example.BLL.Services
{
    public class TestService : ITestService
    {
        public string[] Method1() => new [] {"value1", "value2"};
    }
}
