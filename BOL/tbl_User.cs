using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class tbl_User
    {

        public int UserId { get; set; }
        public string UserName_Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int UserCinsiyet { get; set; }
        public string Telefon { get; set; }
        public int Isactive { get; set; }
        public DateTime UserDbo { get; set; }
        public string Skillset { get; set; }
        public string Experince { get; set; }
        public int RoleId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Createdby { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdateDate { get; set; }

    }
}
