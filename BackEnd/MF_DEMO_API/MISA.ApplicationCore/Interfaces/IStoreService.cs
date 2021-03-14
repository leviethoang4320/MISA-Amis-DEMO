using System;
using System.Collections.Generic;
using System.Text;
using MISA.Common.Models;

namespace MISA.Service.Interfaces
{
    public interface IStoreService: IBaseService<Store>
    {
        /// <summary>
        /// Lọc dữ liệu cửa hàng theo điều kiện
        /// </summary>
        /// <param name="code">Mã cửa hàng muốn lọc</param>
        /// <param name="name">Tên cửa hàng muốn lọc</param>
        /// <param name="address">Địa chỉ cửa hàng muốn lọc</param>
        /// <param name="phone">Số điện thoại cửa hàng muốn lọc</param>
        /// <param name="status">Trạng thái hoạt động cửa hàng muốn lọc</param>
        /// <returns>Các cửa hàng được lọc theo điều kiện</returns>
        /// CreatedBy: LVHOANG (21/02/2021)
        public IEnumerable<Store> GetFilter(string code, string name, string address, string phone, string status);
    }
}
