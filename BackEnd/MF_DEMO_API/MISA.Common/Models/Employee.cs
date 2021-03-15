using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Common.Models
{
    public class Employee
    {
        /// <summary>
        /// ID của nhân viên
        /// </summary>
        public int  EmployeeId { get; set; }
        /// <summary>
        /// Tên của nhân viên
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Vai trò của nhân viên trong công ty
        /// </summary>
        public int Role { get; set; }
        /// <summary>
        /// Id phòng ban của nhân viên
        /// </summary>
        public int DepartmentId { get; set; }
        /// <summary>
        /// tên phòng ban của nhân viên
        /// </summary>
        public string DepartmentName { get; set; }
    }
}
