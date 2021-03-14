using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Common.Models
{
    /// <summary>
    ///Tỉnh/thành phố
    /// </summary>
    public class Province
    {

        public Province()
        {
            
        }
         
        /// <summary>
        /// ID của tỉnh
        /// </summary>
        public string ProvinceId { get; set; }

       /// <summary>
       /// Tên của tỉnh
       /// </summary>
        public string ProvinceName { get; set; }
    }
}
