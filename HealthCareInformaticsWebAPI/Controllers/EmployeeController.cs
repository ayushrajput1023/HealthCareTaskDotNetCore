using HealthCareInformaticsWebAPI.Models;
using HealthCareInformaticsWebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCareInformaticsWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public readonly IEmployee iEmployee;

        public EmployeeController(IEmployee iEmployee)
        {
            this.iEmployee = iEmployee;
        }

        [HttpGet]
        [Route("GetAllEmployee")]
        public async Task<IActionResult> GetAllEmployee()
        {
            try
            {
                var employees = await iEmployee.GetAllEmployee();
                if (employees != null)
                {
                    return Ok(employees);
                }
                else
                {
                    return NotFound("No employee available");
                }
            }
            catch
            {
                return BadRequest("Database is empty");
            }
        }


        [HttpGet]
        [Route("GetEmployeeByCode/{code}")]
        public async Task<IActionResult> GetEmployeeByCode(int code)
        {
            try
            {
                var employee = await iEmployee.GetEmployeeByCode(code);
                if (employee != null)
                {
                    return Ok(employee);
                }
                else
                {
                    return NotFound("Employee with " + code + " Not available");
                }
            }
            catch
            {
                return BadRequest("Employee not available");
            }
        }

        [HttpPost]
        [Route("AddEmployee")]
        public async Task<IActionResult> AddEmployee([FromBody] Employee employee)
        {
            try
            {
                var addemployee = await iEmployee.AddEmployee(employee);
                if (addemployee != null)
                {
                    return Ok(addemployee);
                }
                else
                {
                    return NotFound("Employee Not added");
                }
            }
            catch
            {
                return BadRequest("Employee Not added");
            }
        }


        [HttpPatch]
        [Route("UpdateEmployeeName/{code}/{name}")]
        public async Task<IActionResult> UpdateEmployeeName(int code, string name)
        {
            try
            {
                var employee = await iEmployee.UpdateEmployeeName(code, name);
                if (employee != null)
                {
                    return Ok(employee);
                }
                else
                {
                    return NotFound("Employee Not updated");
                }
            }
            catch 
            {
                return BadRequest("Employee Not updated");
            }
        }
    }
}
