using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using RestApi_ED.Data;
using RestApi_ED.Dtos;
using RestApi_ED.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace RestApi_ED.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/Employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
         private readonly IEmployeeRepo _repository;
        private readonly IMapper _mapper;
        public EmployeesController(IEmployeeRepo context, IMapper mapper)
        {
            _repository = context;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<EmployeeReadDto>> GettAllSqlEmployees()
        {
            var employees = _repository.GetAllEmployees();
            return Ok(_mapper.Map<IEnumerable<EmployeeReadDto>>(employees));
        }
        [HttpGet("{id}", Name = "GetEmpById")]
        public ActionResult<EmployeeReadDto> GetEmpById(int id)
        {
            var employee = _repository.GetEmployeeById(id);
            if (employee != null)
            {
                return Ok(_mapper.Map<EmployeeReadDto>(employee));
            }
            return NotFound();
        }
        [HttpPost]
        public ActionResult<EmployeeReadDto> CreateEmployee(EmployeeCreateDto employeeCreateDto)
        {
            var empModel = _mapper.Map<Employee>(employeeCreateDto);
            _repository.CreateEmployee(empModel);
            _repository.SaveChanges();

            var employeeReadDto = _mapper.Map<EmployeeReadDto>(empModel);
            return CreatedAtRoute(nameof(GetEmpById), new { id = employeeReadDto.Id }, employeeReadDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateEmployee(int id, EmployeeUpdateDto employeeUpdateDto)
        {
            var employeeModelFromRepo = _repository.GetEmployeeById(id);
            if (employeeModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(employeeUpdateDto, employeeModelFromRepo);

            _repository.UpdateEmployee(employeeModelFromRepo);
            _repository.SaveChanges();
            return NoContent();

        }

        [HttpPatch("{id}")]
        public ActionResult PartialEmployeeUpdate(int id,JsonPatchDocument<EmployeeUpdateDto> patchdoc)
        {
            var employeeModelFromRepo = _repository.GetEmployeeById(id);
            if (employeeModelFromRepo == null)
            {
                return NotFound();
            }
            var employeeToPatch = _mapper.Map<EmployeeUpdateDto>(employeeModelFromRepo);
            patchdoc.ApplyTo(employeeToPatch, ModelState);


            if(!TryValidateModel(employeeToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(employeeToPatch, employeeModelFromRepo);
            _repository.UpdateEmployee(employeeModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }
        [HttpDelete("{id}")]


        public ActionResult DeleteEmployee(int id)
        {
            var employeeModelFromRepo = _repository.GetEmployeeById(id);
            if (employeeModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteEmployee(employeeModelFromRepo);
            _repository.SaveChanges();

            return NoContent();





        }





    }



    
}
