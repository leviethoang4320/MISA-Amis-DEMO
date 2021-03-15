using System;
using System.Collections.Generic;
using System.Text;
using MISA.Common.Models;

namespace MISA.Service.Interfaces
{
    public interface IApplicationService: IBaseService<Application>
    {
        public object GetPaging(Paginate pageInfo);
        public ServiceResult deleteMultiple(List<string> id);
    }
}
