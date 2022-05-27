using System;

namespace P06.BlazorServerApp.Data
{

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Department { get; set; }

        public DateTime EmploymentDate { get; set; }

        public int Salary { get; set; }
    }
}
