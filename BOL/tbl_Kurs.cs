using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class tbl_Kurs

    {

        public int KursId { get; set; }
        public string KursTitle { get; set; }
        public DateTime KursDate { get; set; }
        public string KursSure { get; set; }
        public string KursTopics { get; set; }

        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

    }
}
