using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using MISA.Common.Models;
using MISA.DataLayer.Interfaces;

namespace MISA.DataLayer.Contexts
{
    public class DistrictRepository : DbContext<District>, IDistrictRepository
    {
        #region Method
        /// <summary>
        /// Tìm huyện/quận theo tỉnh/thành phố 
        /// </summary>
        /// <param name="ProvinceId">ID của tỉnh/thành phố muốn tìm</param>
        /// <returns>các huyện thuộc tỉnh có ID = ProvinceId</returns>
        /// CreatedBy: LVHOANG
        public IEnumerable<District> GetByProvinceId(string ProvinceId)
        {
            var sql = $"SELECT * FROM District WHERE ProvinceId = '{ProvinceId}' ";
            return _dbConnection.Query<District>(sql);
        }

        #endregion
    }
}
