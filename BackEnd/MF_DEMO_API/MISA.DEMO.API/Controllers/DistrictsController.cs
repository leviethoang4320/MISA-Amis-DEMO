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
    
    public class DistrictsController : BaseEntityController<District>
    {
        IDistrictService _baseService;
        public DistrictsController(IDistrictService baseService) : base(baseService)
        {
            _baseService = baseService;
        }
        [HttpGet("province/{id}")]
        public IActionResult Get(string id)
        {
            var districts = _baseService.GetByProvinceId(id);
            return Ok(districts);
        }
    }
}