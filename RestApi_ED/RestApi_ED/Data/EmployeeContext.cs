using Microsoft.EntityFrameworkCore;
using RestApi_ED.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi_ED.Data
{
    public class EmployeeContext:DbContext
    { 

        public EmployeeContext(DbContextOptions<EmployeeContext> opt) :base(opt)
        {
            
        }
        public DbSet<Employee> Employees { get; set; }

        internal object SingleOrDefault(Func<object, bool> p)
        {
            throw new NotImplementedException();
        }
    }
}
