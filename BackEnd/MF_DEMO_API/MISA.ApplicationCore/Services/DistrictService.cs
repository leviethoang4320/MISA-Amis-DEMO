using System;
using System.Collections.Generic;
using System.Text;
using MISA.Common.Models;
using MISA.DataLayer.Interfaces;
using MISA.Service.Interfaces;

namespace MISA.Service.Services
{
    public class DistrictService: BaseService<District>, IDistrictService
    {
        IDistrictRepository _dbContext;
        public DistrictService(IDistrictRepository dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<District> GetByProvinceId(string ProvinceId)
        {
            return _dbContext.GetByProvinceId(ProvinceId);
        }
    }
}
