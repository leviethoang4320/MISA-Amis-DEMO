using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Common.Models
{
    public class Application
    {
        /// <summary>
        /// Id của đơn nộp
        /// </summary>
        public int ApplicationId { get; set; }
        /// <summary>
        /// Id của người duyệt đơn
        /// </summary> 
        [Required("Người duyệt")]
        public int CensorId { get; set; }
        /// <summary>
        /// Tên người duyệt đơn
        /// </summary>
        public string CensorName { get; set; }
        /// <summary>
        /// ngày viết đơn
        /// </summary>
        [Required("Ngày viết đơn")]
        public DateTime DateSuggest { get; set; }
        /// <summary>
        /// Id người nộp đơn
        /// </summary>
        [Required("Người nộp đơn")]
        public int PeopleSuggestId { get; set; }
        /// <summary>
        /// tên người nộp đơn
        /// </summary>
        public string PeopleSuggestName { get; set; }
        /// <summary>
        /// ngày bắt đầu công tác
        /// </summary>
        [Required("Ngày đi")]
        public DateTime DateMove { get; set; }
        /// <summary>
        /// ngày công tác trở về
        /// </summary>
        [Required("Ngày về")]
        public DateTime DateDone { get; set; }
        /// <summary>
        /// Địa điểm công tác
        /// </summary>
        public string Place { get; set; }
        /// <summary>
        /// Lý do công tác
        /// </summary>
        public string Reason { get; set; }
        /// <summary>
        ///mã trạng thái duyệt cảu đơn
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// Tên trạng thái duyệt của đơn
        /// </summary>
        public string StatusName
        {

            get
            {
                switch (Status)
                {
                    case 1: return "Chờ duyệt";
                    case 2: return "Đã Duyệt";
                    case 0: return "Từ chối";
                    default: return "";
                }

            }
        }
        /// <summary>
        /// ghi chú thêm
        /// </summary>
        public string Note { get; set; }
        /// <summary>
        /// chuỗi id của những người hỗ trợ
        /// </summary>
        public string PeopleSupportIds { get; set; }
       
        /// <summary>
        /// Yêu cầu hỗ trợ
        /// </summary>
        public string RequestSupport { get; set; }
        /// <summary>
        /// Chuỗi Id của những người có liên quan
        /// </summary>
        public string PeopleInvolIds { get; set; }
        

    }
}
