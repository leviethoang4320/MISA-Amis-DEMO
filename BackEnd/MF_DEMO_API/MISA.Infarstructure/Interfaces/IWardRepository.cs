using System;
using System.Collections.Generic;
using System.Text;
using MISA.Common.Models;

namespace MISA.DataLayer.Interfaces
{
   public interface IWardRepository: IDbContext<Ward>
    {
        /// <summary>
        /// Lọc dữ liệu theo xã/phường theo huyện
        /// </summary>
        /// <param name="DistrictId">ID của huyện các xã/phường muốn tìm</param>
        /// <returns>Các xã thuộc huyện có ID = DistrictId</returns>
        /// CreatedBy: LVHOANG (21/02/2021)
        public IEnumerable<Ward> GetByDistrictId(string DistrictId);
    }
}
