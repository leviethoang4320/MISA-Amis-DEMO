using System;
using System.Collections.Generic;
using System.Text;
using MISA.Common.Models;

namespace MISA.DataLayer.Interfaces
{
    public interface IDistrictRepository: IDbContext<District>
    {
        /// <summary>
        /// Tìm huyện/quận theo tỉnh/thành phố 
        /// </summary>
        /// <param name="ProvinceId">ID của tỉnh/thành phố muốn tìm</param>
        /// <returns>các huyện thuộc tỉnh có ID = ProvinceId</returns>
        /// CreatedBy: LVHOANG
        public IEnumerable<District> GetByProvinceId(string ProvinceId);
    }
}
