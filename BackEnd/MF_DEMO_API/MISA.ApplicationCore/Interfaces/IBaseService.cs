using System;
using System.Collections.Generic;
using System.Text;
using MISA.Common.Models;

namespace MISA.Service
{
    public interface IBaseService<TEntity>
    {
        /// <summary>
        /// Lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns>toàn bộ dữ liệu</returns>
        /// CreatedBy: LVHOANG (21/02/2021)
        public IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Lấy dữ liệu theo Id
        /// </summary>
        /// <param name="id">Id của đối tượng cần lấy</param>
        /// <returns>đối tượng cần lấy</returns>
        /// CreatedBy: LVHOANG (21/02/2021)
        public TEntity GetById(int id);

        /// <summary>
        /// Thêm dữ liệu mới
        /// </summary>
        /// <param name="entity"> đối tượng dữ liệu muốn thêm</param>
        /// <returns> thêm thành công hay thất bại và câu thông báo tùy thuộc</returns>
        /// CreatedBy: LVHOANG (21/02/2021)
        public ServiceResult Insert(TEntity entity);

        /// <summary>
        /// Sửa dữ liệu 
        /// </summary>
        /// <param name="id"> ID của đối tượng cần sửa</param>
        /// <param name="entity"> Đối tượng sau khi đã sửa</param>
        /// <returns>kết quả sau khi thực hiện và câu thông báo tùy chỉnh</returns>
        /// CreatedBy: LVHOANG (21/02/2021)
        public ServiceResult Update(int id, TEntity entity);

        /// <summary>
        /// Xóa dữ liệu
        /// </summary>
        /// <param name="id">ID đối tượng cần xóa</param>
        /// <returns> số dòng xóa được</returns>
        /// CreatedBy: LVHOANG (21/02/2021)
        public ServiceResult Delete(int id);
    }
}
