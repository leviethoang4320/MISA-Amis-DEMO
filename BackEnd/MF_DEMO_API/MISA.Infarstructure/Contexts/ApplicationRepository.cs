using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;
using Dapper;
using MISA.Common.Models;
using MISA.DataLayer.Interfaces;

namespace MISA.DataLayer.Contexts
{
    public class ApplicationRepository : DbContext<Application>, IApplicationRepository
    {
        public IEnumerable<Application> GetPaging(Paginate pageInfo)
        {  
            return _dbConnection.Query<Application>($"Application_Paging", pageInfo, commandType: CommandType.StoredProcedure);
            
        }
        public int deleteMultiple(List<string> id)
        {
            var effectRows = 0;
            foreach ( var item in id)
            {
                
                var sql = $"DELETE FROM Application Where ApplicationId = '{item}' ";
                effectRows += _dbConnection.Execute(sql);
                
            }
            return effectRows;
        }
    }
}
