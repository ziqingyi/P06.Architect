using System.ComponentModel.DataAnnotations;

namespace P06.BlazorServerApp.Data
{
    public class Person
    {
        [Required] 
        [Range(1, 10000)] 
        public int EmployeeId { get; set; }

        [Required] 
        [StringLength(100)] 
        public string FirstName { get; set; } 

        [Required] 
        [StringLength(100)] 
        public string LastName { get; set; }

        [Required] 
        [EmailAddress] 
        public string Email { get; set; } 




    }
}
