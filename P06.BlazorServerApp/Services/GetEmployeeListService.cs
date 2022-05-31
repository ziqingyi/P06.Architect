using P06.BlazorServerApp.Data;
using System;
using System.Collections.Generic;

namespace P06.BlazorServerApp.Services
{
    public class GetEmployeeListService: IGetEmployeeListService
    {
        private List<Employee> _employees = new List<Employee>();

        public GetEmployeeListService()
        {
            _employees.AddRange(new Employee[]
            {
                new Employee
                {
                    Name = "User1",
                    Title="Developer", 
                    Department="Software Dev",
                    EmploymentDate=DateTime.Now,
                    Salary=100000
                },

                 new Employee
                {
                    Name = "User2",
                    Title="Developer",
                    Department="Software Dev",
                    EmploymentDate=DateTime.Now,
                    Salary=90000
                },
                  new Employee
                {
                    Name = "User3",
                    Title="Devops",
                    Department="IT",
                    EmploymentDate=DateTime.Now,
                    Salary=8000
                },
                   new Employee
                {
                    Name = "User4",
                    Title="Developer",
                    Department="Software Dev",
                    EmploymentDate=DateTime.Now,
                    Salary=11000
                },
                   new Employee
                {
                    Name = "User5",
                    Title="Developer",
                    Department="Software Dev",
                    EmploymentDate=DateTime.Now,
                    Salary=100000
                },

                 new Employee
                {
                    Name = "User6",
                    Title="Developer",
                    Department="Software Dev",
                    EmploymentDate=DateTime.Now,
                    Salary=90000
                },
                  new Employee
                {
                    Name = "User7",
                    Title="Devops",
                    Department="IT",
                    EmploymentDate=DateTime.Now,
                    Salary=8000
                },
                   new Employee
                {
                    Name = "User8",
                    Title="Developer",
                    Department="Software Dev",
                    EmploymentDate=DateTime.Now,
                    Salary=11000
                },
                   new Employee
                {
                    Name = "User9",
                    Title="Developer",
                    Department="Software Dev",
                    EmploymentDate=DateTime.Now,
                    Salary=100000
                },

                 new Employee
                {
                    Name = "User10",
                    Title="Developer",
                    Department="Software Dev",
                    EmploymentDate=DateTime.Now,
                    Salary=90000
                },
                  new Employee
                {
                    Name = "User11",
                    Title="Devops",
                    Department="IT",
                    EmploymentDate=DateTime.Now,
                    Salary=8000
                },
                   new Employee
                {
                    Name = "User12",
                    Title="Developer",
                    Department="Software Dev",
                    EmploymentDate=DateTime.Now,
                    Salary=11000
                }
            });
        }

        public List<Employee> GetEmployeeList()
        {
            return _employees;
        }
    }
}
