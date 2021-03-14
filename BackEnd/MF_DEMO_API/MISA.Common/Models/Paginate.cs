using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Common.Models
{
    public class Paginate
    {
        public int firstDataItem { get; set; }
        public int pageSizeNow { get; set; }
        public int status { get; set; }
        public string filter { get; set; }
    }
}
