using System;
using System.Collections.Generic;
using System.Text;
using MISA.Common.Models;

namespace MISA.Service.Interfaces
{
   public interface IDistrictService: IBaseService<District>
    {
        /// <summary>
        /// Tìm huyện/quận theo tỉnh/thành phố 
        /// </summary>
        /// <param name="ProvinceId">ID của tỉnh/thành phố muốn tìm</param>
        /// <returns>các huyện thuộc tỉnh có ID = ProvinceId</returns>
        /// CreatedBy: LVHOANG (21/02/2021)
        public IEnumerable<District> GetByProvinceId(string ProvinceId);
    }
}
