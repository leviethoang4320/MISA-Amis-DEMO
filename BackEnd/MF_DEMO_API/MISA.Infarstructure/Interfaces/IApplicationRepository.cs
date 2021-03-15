using System;
using System.Collections.Generic;
using System.Text;
using MISA.Common.Models;

namespace MISA.DataLayer.Interfaces
{
    public interface IApplicationRepository: IDbContext<Application>
    {
        /// <summary>
        /// Hàm lấy dữ liệu sau khi phân trang, lọc, tìm kiếm
        /// </summary>
        /// <param name="pageInfo">Object chưa các thông tin lọc, phân trang, tìm kiếm</param>
        /// <returns>dữ liệu sau khi đã lọc, tìm kiếm, phân trang</returns>
        public object GetPaging(Paginate pageInfo);
        /// <summary>
        /// Xóa nhiều trường
        /// </summary>
        /// <param name="id">mảng id các trường cần xóa</param>
        /// <returns>số bản ghi đã xóa được</returns>
        public int deleteMultiple(List<string> id);
    }
}
