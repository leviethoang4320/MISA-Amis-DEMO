using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using MISA.Common.Models;
using MISA.DataLayer.Interfaces;

namespace MISA.DataLayer.Contexts
{
    public class WardRepository: DbContext<Ward>, IWardRepository
    {
        #region Method
        /// <summary>
        /// Lọc dữ liệu theo xã/phường theo huyện
        /// </summary>
        /// <param name="DistrictId">ID của huyện các xã/phường muốn tìm</param>
        /// <returns>Các xã thuộc huyện có ID = DistrictId</returns>
        /// CreatedBy: LVHOANG (21/02/2021)
        public IEnumerable<Ward> GetByDistrictId(string DistrictId)
        {
            
            var sql = $"SELECT * FROM Ward WHERE DistrictId = '{DistrictId}' ";
            return _dbConnection.Query<Ward>(sql);
        }
        #endregion
    }
}
