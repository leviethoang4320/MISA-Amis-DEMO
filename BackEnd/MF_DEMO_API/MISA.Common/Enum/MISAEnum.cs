using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Common.Enum
{
    public enum MISAServiceCode
    {
        /// <summary>
        /// Lỗi dữ liệu không hợp lệ
        /// </summary>
        BadRequest = 400,

        /// <summary>
        /// Thực hiện thành công
        /// </summary>
        Success = 200,

        /// <summary>
        /// Có lỗi Exception
        /// </summary>
        Exception = 500
    }


   
}
