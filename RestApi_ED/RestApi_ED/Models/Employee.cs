using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi_ED.Models
{
    public class Employee
    {
        public int Id { get; set; }


       [Required] 
       [MaxLength(50)]
       [MinLength(3)]
        public string Name { get; set; }
        
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        
        [Required]
        public string Password { get; set; }
        
        
        public int Salary { get; set; }
        //public string Token { get; internal set; }
    }
}
