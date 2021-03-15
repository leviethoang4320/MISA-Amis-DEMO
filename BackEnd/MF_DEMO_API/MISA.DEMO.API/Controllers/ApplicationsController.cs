using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Common.Models;
using MISA.Service;
using MISA.Service.Interfaces;

namespace MISA.DEMO.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationsController : BaseEntityController<Application>
    {
        IApplicationService _baseService;
        public ApplicationsController(IApplicationService baseService) : base(baseService)
        {
            _baseService = baseService;
        }
        /// <summary>
        /// Hàm lấy dữ liệu sau khi phân trang, lọc, tìm kiếm
        /// </summary>
        /// <param name="pageInfo">Object chưa các thông tin lọc, phân trang, tìm kiếm</param>
        /// <returns>object dữ liệu sau khi đã lọc, tìm kiếm, phân trang</returns>
        [HttpPost("paging")]
        public IActionResult GetPaging([FromBody] Paginate pageInfo)
        {
            
            var applications = _baseService.GetPaging(pageInfo);
            return Ok(applications);
        }
        /// <summary>
        /// Xóa nhiều trường
        /// </summary>
        /// <param name="id">mảng id các trường cần xóa</param>
        /// <returns>số bản ghi đã xóa được</returns>
        [HttpPost("multiple-delete")]
        public IActionResult deleteMultiple([FromBody] List<string> id)
        {

            var effectRows = _baseService.deleteMultiple(id);
            return Ok(effectRows);
        }
    }
}
