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
        [HttpPost("paging")]
        public IActionResult GetPaging([FromBody] Paginate pageInfo)
        {
            
            var applications = _baseService.GetPaging(pageInfo);
            return Ok(applications);
        }
        [HttpPost("multiple-delete")]
        public IActionResult deleteMultiple([FromBody] List<string> id)
        {

            var effectRows = _baseService.deleteMultiple(id);
            return Ok(effectRows);
        }
    }
}
