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
    public class StoresController : BaseEntityController<Store>
    {
        
        IStoreService _baseService;
        public StoresController(IStoreService baseService) : base(baseService)
        {
            _baseService = baseService;
        }

        /// <summary>
        /// Lọc dữ liệu theo điều kiện
        /// </summary>
        /// <param name="code">Mã cửa hàng</param>
        /// <param name="name">Tên cửa hàng</param>
        /// <param name="address">Địa chỉ cửa hàng</param>
        /// <param name="phone">Số điện thoại</param>
        /// <param name="status">Trạng thái hoạt động</param>
        /// <returns>Số dòng dữ liệu ảnh hưởng</returns>
        [HttpGet("filter/{code}&{name}&{address}&{phone}&{status}")]
        public IActionResult Get( string code, string name, string address, string phone, string status)
        {
            if (code == "all") code = "";

            if (name == "all") name = "";
            if (address == "all") address = "";
            if (phone == "all") phone = "";
            if (status == "all") status = "";
            var stores = _baseService.GetFilter(code,name,address,phone,status);
            return Ok(stores);
        }
    
}
}
