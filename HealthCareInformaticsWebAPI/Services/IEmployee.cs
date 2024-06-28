using HealthCareInformaticsWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCareInformaticsWebAPI.Services
{
    public interface IEmployee
    {
        Task<List<EmployeeWithEarning>> GetAllEmployee();

        Task<Employee> GetEmployeeByCode(int code);

        Task<Employee> AddEmployee(Employee employee);

        Task<Employee> UpdateEmployeeName(int code, string name);
    }
}
