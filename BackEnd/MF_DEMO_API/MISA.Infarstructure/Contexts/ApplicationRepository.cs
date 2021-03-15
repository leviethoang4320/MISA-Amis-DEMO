using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;
using Dapper;
using MISA.Common.Models;
using MISA.DataLayer.Interfaces;

namespace MISA.DataLayer.Contexts
{
    public class ApplicationRepository : DbContext<Application>, IApplicationRepository
    {
        /// <summary>
        /// Hàm lấy dữ liệu sau khi phân trang, lọc, tìm kiếm
        /// </summary>
        /// <param name="pageInfo">Object chưa các thông tin lọc, phân trang, tìm kiếm</param>
        /// <returns>dữ liệu sau khi đã lọc, tìm kiếm, phân trang</returns>
        public object GetPaging(Paginate pageInfo)
        {
            var props = typeof(Paginate).GetProperties();
            DynamicParameters dynamicParameters = new DynamicParameters();
            foreach( var prop in props)
            {
                dynamicParameters.Add(prop.Name, prop.GetValue(pageInfo));
            }
            dynamicParameters.Add("count", dbType: DbType.Int32, direction: ParameterDirection.Output);
            var res = _dbConnection.Query<Application>($"Application_Paging", dynamicParameters, commandType: CommandType.StoredProcedure);
            int count = dynamicParameters.Get<Int32>("count");
            return new { res, count };
        }
        /// <summary>
        /// Xóa nhiều trường
        /// </summary>
        /// <param name="id">mảng id các trường cần xóa</param>
        /// <returns>số bản ghi đã xóa được</returns>
        public int deleteMultiple(List<string> id)
        {
            var effectRows = 0;
            foreach ( var item in id)
            {
                
                var sql = $"DELETE FROM Application Where ApplicationId = '{item}' ";
                effectRows += _dbConnection.Execute(sql);
                
            }
            return effectRows;
        }
    }
}
