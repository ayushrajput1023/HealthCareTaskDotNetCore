using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCareInformaticsWebAPI.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeCode { get; set; }

        [Column]
        [Required]
        [StringLength(50)]
        public string EmployeeName { get; set; }

        [Column]
        [Required]
        public DateTime DateOfBirth { get; set; }

        [Column]
        [Required]
        public char Gender { get; set; }

        [Column]
        [Required]
        [StringLength(20)]
        public string Department { get; set; }

        [Column]
        [Required]
        [StringLength(20)]
        public string Designation { get; set; }

        [Column]
        [Required]
        public float BasicSalary { get; set; }


    }
}
