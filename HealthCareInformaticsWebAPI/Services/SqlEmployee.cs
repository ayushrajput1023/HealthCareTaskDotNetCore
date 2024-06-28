using HealthCareInformaticsWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCareInformaticsWebAPI.Services
{
    public class SqlEmployee : IEmployee
    {
        private EmployeeContext _dbContext;

        public SqlEmployee(EmployeeContext _dbContext)
        {
            this._dbContext = _dbContext;
        }

        float dearnessAllowanceVar = 0;
        float conveyanceAllowanceVar = 0;
        float houseRentAllowanceVar = 0;
        float grossSalaryVar = 0;
        float pTVar = 0;
        float totalSalaryVar = 0;

        public async Task<List<EmployeeWithEarning>> GetAllEmployee()
        {
            if(_dbContext != null)
            {
                List<Employee> employees = await _dbContext.Employees.ToListAsync();
                List<EmployeeWithEarning> employeesWithEarningList = new List<EmployeeWithEarning>();
                for(int i=0;i<employees.Count;i++)
                {
                    //EmployeeWithEarning employeesWithEarning = new EmployeeWithEarning();
                    employeesWithEarningList.Add(new EmployeeWithEarning {

                    EmployeeCode = employees[i].EmployeeCode,
                    EmployeeName = employees[i].EmployeeName,
                    DateOfBirth = employees[i].DateOfBirth,
                    Gender = employees[i].Gender,
                    Department = employees[i].Department,
                    Designation = employees[i].Designation,
                    BasicSalary = employees[i].BasicSalary,
                    DearnessAllowance = calculateDearnessAllowance(employees[i].BasicSalary),
                    ConveyanceAllowance = calculateConveyanceAllowance(dearnessAllowanceVar),
                    HouseRentAllowance = calculateHouseRentAllowance(employees[i].BasicSalary),
                    GrossSalary = calculateGrossSalary(employees[i].BasicSalary, dearnessAllowanceVar, conveyanceAllowanceVar, houseRentAllowanceVar),
                    PT = calculatePT(grossSalaryVar),
                    TotalSalary = calculateTotalSalary(employees[i].BasicSalary, dearnessAllowanceVar, conveyanceAllowanceVar, houseRentAllowanceVar, pTVar)
                    });
                }

                return employeesWithEarningList;
            }

            return null;
        }

        private float calculateDearnessAllowance(float basicSalary)
        {
            float x = basicSalary * 0.4f;
            dearnessAllowanceVar = x;
            return x;
        }

        private float calculateConveyanceAllowance(float dearnessAllowance)
        {
            var x = dearnessAllowance * 0.1f;
            if(x < 250)
            {
                conveyanceAllowanceVar = x;
                return x;
            }
            conveyanceAllowanceVar = 250;
            return 250;
        }

        private float calculateHouseRentAllowance(float basicSalary)
        {
            var x = basicSalary * (25 / 100);
            if (x > 1500)
            {
                houseRentAllowanceVar = x;
                return x;
            }
            houseRentAllowanceVar = 1500;
            return 1500;
        }

        private float calculateGrossSalary(float bs, float da, float ca, float hra)
        {
            var x = bs + da + ca + hra;
            grossSalaryVar = x;
            return x;
        }

        private float calculatePT(float gSalary)
        {
            if(gSalary <= 3000)
            {
                pTVar = 100;
                return 100;
            }
            else if(gSalary > 3000 && gSalary<=6000)
            {
                pTVar = 150;
                return 150;
            }
            else
            {
                pTVar = 200;
                return 200;
            }
        }

        private float calculateTotalSalary(float bs, float da, float ca, float hra, float pt)
        {
            var x = bs + da + ca + hra - pt;
            totalSalaryVar = x;
            return x;
        }

        public async Task<Employee> GetEmployeeByCode(int code)
        {
            if (_dbContext != null)
            {
                return await _dbContext.Employees.FindAsync(code);
            }

            return null;
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            if (_dbContext != null)
            {
                _dbContext.Employees.Add(employee);
                await _dbContext.SaveChangesAsync();
                return employee;
            }

            return null;
        }

        public async Task<Employee> UpdateEmployeeName(int code, string name)
        {
            if (_dbContext != null)
            {
                var employee = await this.GetEmployeeByCode(code);
                if (employee != null)
                {
                    employee.EmployeeName = name;
                    _dbContext.Employees.Update(employee);
                    await _dbContext.SaveChangesAsync();
                    return employee;
                }
            }

            return null;
        }


    }
}
