using Dapper;

using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MISA.DataLayer
{
    public class DbContext<TEntity> : IDbContext<TEntity>
    {
        #region Declare

        /// <summary>
        /// chuỗi kết nối đến DB: MS2_16_LVHoang_CUKCUK
        /// </summary>
        public string connectionString = "Host = 47.241.69.179; Port= 3306; Database =LVHOANG_AMIS_DEMO; User Id = dev; password = 12345678;  Character Set=utf8";

        protected IDbConnection _dbConnection; 

        #endregion

        #region Constructor

        public DbContext()
        {
            _dbConnection = new MySqlConnection(connectionString);
        }
        #endregion

        #region Methods

        /// <summary>
        /// Lấy toàn bộ danh sách 
        /// </summary>
        /// <typeparam name="TEntity">kiểu của đối tượng cần lấy về</typeparam>
        /// <returns>Trả về danh sách các object</returns>
        /// CreatedBy: LVHOANG (21/02/2021)
        public IEnumerable<TEntity> GetAll()
        {
            string className = typeof(TEntity).Name;
            
            var entities = _dbConnection.Query<TEntity>($"{className}_GetAll", commandType: CommandType.StoredProcedure);
            return entities;
        }

        /// <summary>
        /// Lấy dữ liệu theo commandText truyền vào
        /// </summary>
        /// <typeparam name="TEntity">kiểu của object</typeparam>
        /// <param name="commandText">mã SQL</param>
        /// <returns>mảng các object lấy được từ db</returns>
        /// CreatedBy: LVHOANG (21/02/2021)
        public IEnumerable<TEntity> GetData(string commandText)
        {
            string className = typeof(TEntity).Name;
            var sql = commandText;
            var entities = _dbConnection.Query<TEntity>(sql);
            return entities;
        }


        /// <summary>
        /// Lấy danh sách theo Id truyền vào
        /// </summary>
        /// <typeparam name="TEntity">kiểu của đối tượng cần lấy về</typeparam>
        /// <returns>Trả về dánh sách 1 object</returns>
        /// CreatedBy: LVHOANG (21/02/2021)
        public TEntity GetById(object id)
        {
            string className = typeof(TEntity).Name;
            var sql = $"SELECT * FROM {className} WHERE {className}Id = '{id.ToString()}'";
            return _dbConnection.Query<TEntity>(sql).FirstOrDefault();
        }

        /// <summary>
        /// Thêm mới 1 đối tượng 
        /// </summary>
        /// <typeparam name="TEntity"> Kiểu đối tượng thêm</typeparam>
        /// <param name="entity">đối tượng thêm mới </param>
        /// <returns>số dòng dữ liệu ảnh hưởng</returns>
        /// CreatedBy: LVHOANG (21/02/2021)
        public int Insert(TEntity entity)
        {
            string className = typeof(TEntity).Name;

            var effectRows = _dbConnection.Execute($"{className}_Insert", entity, commandType: CommandType.StoredProcedure);
            return effectRows;
        }

        /// <summary>
        /// Sửa bản ghi
        /// </summary>
        /// <typeparam name="TEntity">Kiểu đối tượng muốn sửa</typeparam>
        /// <param name="entity">đối tượng sau khi sửa</param>
        /// <returns>số dòng ảnh hưởng</returns>
        /// CreatedBy: LVHOANG (21/02/2021)
        public int Update(TEntity entity, int id)

        {
            
            string className = typeof(TEntity).Name;
            

            var effectRows = _dbConnection.Execute($"{className}_Update", entity, commandType: CommandType.StoredProcedure);
            return effectRows;
        }

        /// <summary>
        /// Xóa bản ghi
        /// </summary>
        /// <typeparam name="TEntity">Kiểu đối tượng cần xóa</typeparam>
        /// <param name="id">Id đối tượng cần xóa</param>
        /// <returns>số dòng ảnh hưởng</returns>
        /// CreatedBy: LVHOANG (21/02/2021)
        public int Delete(object id)
        {
            string className = typeof(TEntity).Name;
            var sql = $"DELETE FROM {className} Where {className}Id = '{id}' ";
            var effectRows = _dbConnection.Execute(sql);
            return effectRows;
        }

        #endregion

    }
}
