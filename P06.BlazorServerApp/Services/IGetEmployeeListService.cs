using P06.BlazorServerApp.Data;
using System.Collections.Generic;

namespace P06.BlazorServerApp.Services
{
    public interface IGetEmployeeListService
    {
        public List<Employee> GetEmployeeList();

    }
}
