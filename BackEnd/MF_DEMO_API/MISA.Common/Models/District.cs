using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Common.Models
{
    /// <summary>
    /// Huyện/quận
    /// </summary>
    public class District { 
        public District()
        {
           
        }
         //ID của huyện
        public string DistrictId { get; set; }

        //Tên của huyện
        public string DistrictName { get; set; }

        //ID của tỉnh
        public string ProvinceId { get; set; }

        
    }
}
