using System;
using System.Collections.Generic;
using System.Text;
using MISA.Common.Models;
using MISA.DataLayer.Interfaces;
using MISA.Service.Interfaces;

namespace MISA.Service.Services
{
    public class StoreService: BaseService<Store>,IStoreService
    {
        IStoreRepository _dbContext;
        public StoreService(IStoreRepository dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }


        public IEnumerable<Store> GetFilter(string code, string name, string address, string phone, string status)
        {
            return _dbContext.GetByFilter(code, name, address, phone, status);
        }
    }
}
