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
    public class WardsController : BaseEntityController<Ward>
    {
        IWardService _baseService;
        public WardsController(IWardService baseService) : base(baseService)
        {
            _baseService = baseService;
        }
        [HttpGet("district/{id}")]
        public IActionResult Get(string id)
        {
            var wards = _baseService.GetByDistrictId(id);
            return Ok(wards);
        }
    }
}
