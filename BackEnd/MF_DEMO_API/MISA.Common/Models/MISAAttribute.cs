using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Common.Models
{
    public class MISAAttribute
    {

    }


    /// <summary>
    /// Attribute để xác định check bắt buộc nhập
    /// </summary>
    /// CreatedBy: LVHOANG (21/02/2021)
    [AttributeUsage(AttributeTargets.Property)]
    public class Required:Attribute
    {
        /// <summary>
        /// Tên của property
        /// </summary>
        public string PropertyName;

        /// <summary>
        /// Câu cảnh báo tùy chỉnh
        /// </summary>
        public string ErrorMessenger;
        public Required(string propertyName, string errorMessenger = null)
        {
            this.PropertyName = propertyName;
            this.ErrorMessenger = errorMessenger;
        }
    }

    /// <summary>
    /// Attribute để xác định check trùng
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class CheckDuplicate:Attribute
    {
        /// <summary>
        /// Tên của property
        /// </summary>
        public string PropertyName;

        /// <summary>
        /// Câu cảnh báo tùy chỉnh
        /// </summary>
        public string ErrorMessenger;
        public CheckDuplicate(string propertyName, string errorMessenger = null)
        {
            this.PropertyName = propertyName;
            this.ErrorMessenger = errorMessenger;
        }
    }


    /// <summary>
    /// Attribute để xác định check độ dài tối đa
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class MaxLength : Attribute
    {
        /// <summary>
        /// Tên của property
        /// </summary>
        public string PropertyName;

        /// <summary>
        /// Câu cảnh báo tùy chỉnh
        /// </summary>
        public string ErrorMessenger;

        /// <summary>
        /// Độ dài tối đa được phép
        /// </summary>
        public int Length { get; set; }
        public MaxLength(string propertyName,int length, string errorMessenger = null)
        {
            this.PropertyName = propertyName;
            this.ErrorMessenger = errorMessenger;
            Length = length;
        }
    }
}
