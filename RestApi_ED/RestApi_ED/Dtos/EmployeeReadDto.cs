using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi_ED.Dtos
{
    public class EmployeeReadDto
    {
            public int Id { get; set; }          
            public string Name { get; set; }            
            public string Email { get; set; }   
            public int Salary { get; set; }

    }
}




