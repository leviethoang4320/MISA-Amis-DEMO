using System;
using System.Collections.Generic;
using System.Text;
using MISA.Common.Models;
using MISA.DataLayer.Interfaces;
using MISA.Service.Interfaces;

namespace MISA.Service.Services
{
    public class WardService : BaseService<Ward>, IWardService
    {
        IWardRepository _dbContext;
        public WardService(IWardRepository dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Ward> GetByDistrictId(string DistrictId)
        {
            return _dbContext.GetByDistrictId(DistrictId);
        }

        public IEnumerable<Ward> GetByProvinceId(string DistrictId)
        {
            throw new NotImplementedException();
        }
    }
}
