using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MISA.Common.Enum;
using MISA.Common.Models;

using MISA.DataLayer;


using System.Collections;


namespace MISA.Service.Services
{
    public class BaseService<TEntity>:IBaseService<TEntity>
    {
        #region Declare

        IDbContext<TEntity> _dbContext;
        ServiceResult _serviceResult;
        private bool _checkPost = true;

        #endregion

        #region Constructor
        public BaseService(IDbContext<TEntity> dbContext)
        {
            _dbContext = dbContext;
            _serviceResult = new ServiceResult();
        }

        #endregion

        #region MeThod
        /// <summary>
        /// Lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns>toàn bộ dữ liệu</returns>
        /// CreatedBy: LVHOANG (21/02/2021)
        public IEnumerable<TEntity> GetAll()
        {
            return _dbContext.GetAll();
        }

        /// <summary>
        /// Lấy dữ liệu theo Id
        /// </summary>
        /// <param name="id">Id của đối tượng cần lấy</param>
        /// <returns>đối tượng cần lấy</returns>
        /// CreatedBy: LVHOANG (21/02/2021)
        public TEntity GetById(int id)
        {
            return _dbContext.GetById(id);
        }

        /// <summary>
        /// Thêm dữ liệu mới
        /// </summary>
        /// <param name="entity"> đối tượng dữ liệu muốn thêm</param>
        /// <returns> thêm thành công hay thất bại và câu thông báo tùy thuộc</returns>
        /// CreatedBy: LVHOANG (21/02/2021)
        public ServiceResult Insert(TEntity entity)
        {

            // validate dữ liệu:
            ValidateObject(entity, _checkPost);
            if (_serviceResult.MISACode == MISAServiceCode.BadRequest)
            {
                return _serviceResult;
            }


            return new ServiceResult()
            {
                Data = _dbContext.Insert(entity),
                Messenger = new List<string>() { Service.Properties.Resources.Msg_Success },
                MISACode = MISAServiceCode.Success

            };
        }



        /// <summary>
        /// Sửa dữ liệu 
        /// </summary>
        /// <param name="id"> ID của đối tượng cần sửa</param>
        /// <param name="entity"> Đối tượng sau khi đã sửa</param>
        /// <returns>kết quả sau khi thực hiện và câu thông báo tùy chỉnh</returns>
        /// CreatedBy: LVHOANG (21/02/2021)
        public ServiceResult Update(int id, TEntity entity)
        {
            _checkPost = false;
            string className = typeof(TEntity).Name;
            var type = entity.GetType();
            var delegateProperty = type.GetProperty($"{className}Id");
            delegateProperty.SetValue(entity, id);
            ValidateObject(entity, _checkPost);
            
            
            if (_serviceResult.MISACode == MISAServiceCode.BadRequest)
            {
                return _serviceResult;
            }

            return new ServiceResult()
            {
                Data = _dbContext.Update(entity,id),
                Messenger = new List<string>() { Properties.Resources.Msg_Success },
                MISACode = MISAServiceCode.Success
            };
        }

        /// <summary>
        /// Xóa dữ liệu
        /// </summary>
        /// <param name="id">ID đối tượng cần xóa</param>
        /// <returns> số dòng xóa được</returns>
        /// CreatedBy: LVHOANG (21/02/2021)
        public ServiceResult Delete(int id)
        {
            return new ServiceResult()
            {
                Data = _dbContext.Delete(id),
                Messenger = new List<string>() { Properties.Resources.Msg_Success },
                MISACode = MISAServiceCode.Success
            };
        }

        /// <summary>
        /// Hàm check Validate dữ liệu cho Insert
        /// </summary>
        /// <param name="entity">Đối tượng cần check</param>
        /// Created by LVHOANG
        private void ValidateObject(TEntity entity, bool _checkPost)
        {
            var properties = typeof(TEntity).GetProperties();
            string className = typeof(TEntity).Name;
            foreach (var property in properties)
            {

                var propValue = property.GetValue(entity);
                var propName = property.Name;

                // Nếu có attribute là [Required] thì thực hiện kiểm tra bắt buộc nhập
                if (property.IsDefined(typeof(Required), true) && (propValue == null || propValue.ToString() == string.Empty))
                {
                    var requiredAttribute = property.GetCustomAttributes(typeof(Required), true).FirstOrDefault();
                    if (requiredAttribute != null)
                    {
                        var propertyText = (requiredAttribute as Required).PropertyName;
                        var errorMsg = (requiredAttribute as Required).ErrorMessenger;
                        _serviceResult.Messenger.Add((errorMsg == null ? $"{propertyText} {Properties.Resources.Msg_Required} " : errorMsg));

                    }
                    _serviceResult.MISACode = MISAServiceCode.BadRequest;

                }

                // Nếu có attribute là [CheckDuplicate] thì thực hiện kiểm tra trùng dữ liệu
                if (property.IsDefined(typeof(CheckDuplicate), true))
                {

                    var requiredAttribute = property.GetCustomAttributes(typeof(CheckDuplicate), true).FirstOrDefault();
                    if (requiredAttribute != null)
                    {
                        var propertyText = (requiredAttribute as CheckDuplicate).PropertyName;
                        var errorMsg = (requiredAttribute as CheckDuplicate).ErrorMessenger;
                        string sql = "";
                        if (_checkPost)
                        {
                            sql = $"SELECT {propName} FROM {typeof(TEntity).Name} WHERE {propName} = '{propValue}'";
                        }
                        else
                        {

                            var id = entity.GetType().GetProperty($"{className}Id").GetValue(entity, null).ToString();
                            sql = $"SELECT {propName} FROM {typeof(TEntity).Name} WHERE {propName} = '{propValue}' && {className}Id !='{id}'";
                        }
                        var _entity = _dbContext.GetData(sql).FirstOrDefault();
                        if (_entity != null)
                        {
                            _serviceResult.Messenger.Add((errorMsg == null ? $"{propertyText} {Properties.Resources.Msg_Duplicate} " : errorMsg));
                            _serviceResult.MISACode = MISAServiceCode.BadRequest;
                        }

                    }

                }



                // Nếu có attribute là [MaxLength] thì thực hiện kiểm tra độ dài
                if (property.IsDefined(typeof(MaxLength), true) && propValue != null)
                {

                    var requiredAttribute = property.GetCustomAttributes(typeof(MaxLength), true).FirstOrDefault();
                    if (requiredAttribute != null)
                    {
                        var propertyText = (requiredAttribute as MaxLength).PropertyName;
                        var errorMsg = (requiredAttribute as MaxLength).ErrorMessenger;
                        var length = (requiredAttribute as MaxLength).Length;
                        if (propValue.ToString().Trim().Length > length)
                        {
                            _serviceResult.Messenger.Add((errorMsg == null ? $"{propertyText} {Properties.Resources.Msg_Maxlength} " : errorMsg));
                            _serviceResult.MISACode = MISAServiceCode.BadRequest;
                        }
                    }
                }
            }
        }
        #endregion
    }
}
