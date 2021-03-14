using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Common.Models
{
    public class Employee
    {
        public int  EmployeeId { get; set; }
        public string Name { get; set; }
        public int Role { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }
}
