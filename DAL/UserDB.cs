using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;

namespace DAL
{
   public class UserDB
    {

        public List<tbl_User> GetTrainers()
        {
            List<tbl_User> Ls;
            Ls = new List<tbl_User>();


            string conString = "server =.; Initial Catalog = serkanKursDB; Integrated Security = SSPI";
            string cmdString = "Select tbl_User.UserId, tbl_User.FirstName, tbl_User.LastName from tbl_User inner join tbl_Role on tbl_User.RoleId = tbl_Role.RoleId where tbl_Role.RoleName = 'Trainer' ";
            SqlConnection con = new SqlConnection(conString);
            SqlCommand cmd = new SqlCommand(cmdString, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                tbl_User Tr = new tbl_User();
                Tr.UserId = int.Parse(dr["UserId"].ToString());
                Tr.FirstName = dr["FirstName"].ToString();
                Tr.LastName = dr["LastName"].ToString();
                
                Ls.Add(Tr);
               

            }
            dr.Close();
            con.Close();
            return Ls;


        }








    }
}
