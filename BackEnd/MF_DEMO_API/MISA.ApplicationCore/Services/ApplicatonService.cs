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
        public ApplicationService(IApplicationRepository dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public object GetPaging(Paginate pageInfo)
        {
           return _dbContext.GetPaging(pageInfo);
        }
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
