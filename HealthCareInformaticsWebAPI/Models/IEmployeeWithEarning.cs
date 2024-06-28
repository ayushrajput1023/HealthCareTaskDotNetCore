using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCareInformaticsWebAPI.Models
{
    public interface IEmployeeWithEarning
    {
        public int EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public char Gender { get; set; }
        public string Department { get; set; }
        public string Designation { get; set; }
        public float BasicSalary { get; set; }
        public float DearnessAllowance { get; set; }
        public float ConveyanceAllowance { get; set; }
        public float HouseRentAllowance { get; set; }
        public float GrossSalary { get; set; }
        public float PT { get; set; }
        public float TotalSalary { get; set; }
    }
}
