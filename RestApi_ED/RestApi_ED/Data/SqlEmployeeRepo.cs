using Microsoft.AspNetCore.Mvc;
using RestApi_ED.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi_ED.Data
{
    
    public class SqlEmployeeRepo : IEmployeeRepo
    {
        private readonly EmployeeContext _context;
      

      
        public SqlEmployeeRepo(EmployeeContext context)
        {
            _context = context;
        }

      

        public void CreateEmployee(Employee emp)
        {
            if(emp==null)
            {
                throw new ArgumentNullException(nameof(emp)); 
            }
            _context.Employees.Add(emp);
        }

        

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _context.Employees.ToList(); 
        }

        public Employee GetEmployeeById(int id)
        {
            return _context.Employees.FirstOrDefault(c => c.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateEmployee(Employee emp)
        {
         
        }
        public void DeleteEmployee(Employee emp)
        {
           if(emp==null)
            {
                throw new ArgumentNullException(nameof(emp));
            }
            _context.Employees.Remove(emp);
        }


    }
}
