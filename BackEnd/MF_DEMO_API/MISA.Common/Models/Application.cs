using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Common.Models
{
    public class Application
    {
        public int ApplicationId { get; set; }
        public int CensorId { get; set; }
        public string CensorName { get; set; }

        public DateTime DateSuggest { get; set; }
        public int PeopleSuggestId { get; set; }
        public string PeopleSuggestName { get; set; }

        public DateTime DateMove { get; set; }
        public DateTime DateDone { get; set; }
        public string Place { get; set; }
        public string Reason { get; set; }
        public int Status { get; set; }
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
        public string Note { get; set; }
        public string PeopleSupportIds { get; set; }
       

        public string RequestSupport { get; set; }
        public string PeopleInvolIds { get; set; }
        

    }
}
