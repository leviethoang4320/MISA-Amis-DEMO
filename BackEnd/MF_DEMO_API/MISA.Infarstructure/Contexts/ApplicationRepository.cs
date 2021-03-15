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
        public object GetPaging(Paginate pageInfo)
        {
            var props = typeof(Paginate).GetProperties();
            DynamicParameters dynamicParameters = new DynamicParameters();
            foreach( var prop in props)
            {
                dynamicParameters.Add(prop.Name, prop.GetValue(pageInfo));
            }
            dynamicParameters.Add("count", dbType: DbType.Int32, direction: ParameterDirection.Output);
            var res = _dbConnection.Query<Application>($"Application_Paging", dynamicParameters, commandType: CommandType.StoredProcedure);
            int count = dynamicParameters.Get<Int32>("count");
            return new { res, count };
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
