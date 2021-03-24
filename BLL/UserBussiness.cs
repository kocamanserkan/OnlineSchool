using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;
using DAL;

namespace BLL
{
   public class UserBussiness
    {

        public List<tbl_User> GetTrainers()
        {

            UserDB trDB = new UserDB();

            return trDB.GetTrainers();




        }






    }
}
