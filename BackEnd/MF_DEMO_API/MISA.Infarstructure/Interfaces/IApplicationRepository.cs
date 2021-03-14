using System;
using System.Collections.Generic;
using System.Text;
using MISA.Common.Models;

namespace MISA.DataLayer.Interfaces
{
    public interface IApplicationRepository: IDbContext<Application>
    {
        public IEnumerable<Application> GetPaging(Paginate pageInfo);
        public int deleteMultiple(List<string> id);
    }
}
