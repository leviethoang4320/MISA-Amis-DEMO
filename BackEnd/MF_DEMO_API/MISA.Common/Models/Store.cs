using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Common.Models
{
   /// <summary>
   /// Cửa hàng
   /// </summary>
    public class Store
    {
        #region Constructor


        public Store()
            {

                StoreId = Guid.NewGuid();
                Status = "Đang hoạt động";
            }

        #endregion

        #region Properties
        /// <summary>
        /// Id cửa hàng
        /// </summary>
        public Guid StoreId { get; set; }
        
        /// <summary>
        /// Mã cửa hàng
        /// </summary>

        [Required("Mã cửa hàng")]
        [CheckDuplicate("Mã cửa hàng")]
        [MaxLength("Mã cửa hàng", 20)]
        public string StoreCode { get; set; }

        /// <summary>
        /// Tên cửa hàng
        /// </summary>
        [Required("Tên cửa hàng")]
        public string StoreName { get; set; }

        /// <summary>
        /// Địa chỉ cửa hàng
        /// </summary>
        [Required("Địa chỉ")]
        public string Address { get; set; }

        /// <summary>
        /// Số điện thoại
        /// </summary>
        [CheckDuplicate("Số điện thoại")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Trạng thái hoạt động
        /// </summary>
        public string Status { get; set; }
           

            
        public string TaxCode { get; set; }
        public string Street { get; set; }

        public String StoreId_
        {

            get
            {
                return StoreId.ToString();
            }
        }
        public string WardId { get; set; }
        
        public string DistrictId { get; set; }
        
        public string ProvinceId { get; set; }

        #endregion

    }

}
