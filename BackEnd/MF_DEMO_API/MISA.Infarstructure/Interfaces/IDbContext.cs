using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DataLayer
{
    public interface IDbContext<TEntity>
    {
        /// <summary>
        /// Lấy toàn bộ danh sách 
        /// </summary>
        /// <typeparam name="TEntity">kiểu của đối tượng cần lấy về</typeparam>
        /// <returns>Trả về danh sách các object</returns>
        /// CreatedBy: LVHOANG (21/02/2021)
        public IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Lấy dữ liệu theo commandText truyền vào
        /// </summary>
        /// <typeparam name="TEntity">kiểu của object</typeparam>
        /// <param name="commandText">mã SQL</param>
        /// <returns>mảng các object lấy được từ db</returns>
        /// CreatedBy: LVHOANG (21/02/2021)
        public IEnumerable<TEntity> GetData(string commandText);

        /// <summary>
        /// Lấy danh sách theo Id truyền vào
        /// </summary>
        /// <typeparam name="TEntity">kiểu của đối tượng cần lấy về</typeparam>
        /// <returns>Trả về dánh sách 1 object</returns>
        /// CreatedBy: LVHOANG (21/02/2021)
        public TEntity GetById(object id);

        /// <summary>
        /// Thêm mới 1 đối tượng 
        /// </summary>
        /// <typeparam name="TEntity"> Kiểu đối tượng thêm</typeparam>
        /// <param name="entity">đối tượng thêm mới </param>
        /// <returns>số dòng dữ liệu ảnh hưởng</returns>
        /// CreatedBy: LVHOANG (21/02/2021)
        public int Insert(TEntity entity);

        /// <summary>
        /// Sửa bản ghi
        /// </summary>
        /// <typeparam name="TEntity">Kiểu đối tượng muốn sửa</typeparam>
        /// <param name="entity">đối tượng sau khi sửa</param>
        /// <returns>số dòng ảnh hưởng</returns>
        /// CreatedBy: LVHOANG (21/02/2021)
        public int Update(TEntity entity,int id);

        /// <summary>
        /// Xóa bản ghi
        /// </summary>
        /// <typeparam name="TEntity">Kiểu đối tượng cần xóa</typeparam>
        /// <param name="id">Id đối tượng cần xóa</param>
        /// <returns>số dòng ảnh hưởng</returns>
        /// CreatedBy: LVHOANG (21/02/2021)
        public int Delete(object id);
    }
}
