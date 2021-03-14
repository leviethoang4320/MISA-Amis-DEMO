using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Common.Models
{
    public class Ward
    {
        public Ward()
        {
                 
        }
         /// <summary>
         ///  ID của Phường/Xã
         /// </summary>
        public string WardId { get; set; }

        /// <summary>
        /// tên Phường/xã
        /// </summary>
        public string WardName { get; set; }

        /// <summary>
        /// Id của Huyện mà xã trự thuộcs
        /// </summary>
        public string DistrictId { get; set; }

        
    }
}
