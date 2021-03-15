using System;
using System.Collections.Generic;
using System.Text;
using MISA.Common.Enum;
using MISA.Common.Models;
using MISA.DataLayer.Interfaces;
using MISA.Service.Interfaces;

namespace MISA.Service.Services
{
    public class ApplicationService: BaseService<Application>,IApplicationService
    {
        IApplicationRepository _dbContext;

        /// <summary>
        /// Hàm lấy dữ liệu sau khi phân trang, lọc, tìm kiếm
        /// </summary>
        /// <param name="pageInfo">Object chưa các thông tin lọc, phân trang, tìm kiếm</param>
        /// <returns>object dữ liệu sau khi đã lọc, tìm kiếm, phân trang</returns>
        public ApplicationService(IApplicationRepository dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public object GetPaging(Paginate pageInfo)
        {
           return _dbContext.GetPaging(pageInfo);
        }
        /// <summary>
        /// Xóa nhiều trường
        /// </summary>
        /// <param name="id">mảng id các trường cần xóa</param>
        /// <returns>số bản ghi đã xóa được</returns>
        public ServiceResult deleteMultiple(List<string> id)
        {
            
                return new ServiceResult()
                {
                    Data = _dbContext.deleteMultiple(id),
                    Messenger = new List<string>() { Properties.Resources.Msg_Success },
                    MISACode = MISAServiceCode.Success
                }; 
        }
    }

}
