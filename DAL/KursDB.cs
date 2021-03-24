using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;
using System.Data;
using System.Data.SqlClient;


namespace DAL
{
    public class KursDB
    {

        public bool InstertKurs(tbl_Kurs kurs)
        {
            try
            {
                string conString = "server =.; Initial Catalog = serkanKursDB; Integrated Security = SSPI";
                string cmdString = "insert into tbl_Kurs values(@KursTitle,@KursDate,@KursSure,@KursTopic,null,null,null,null)";

                SqlConnection con = new SqlConnection(conString);
                SqlCommand cmd = new SqlCommand(cmdString, con);
                cmd.Parameters.AddWithValue("@KursTitle", kurs.KursTitle);
                cmd.Parameters.AddWithValue("@KursDate", kurs.KursDate);
                cmd.Parameters.AddWithValue("@KursSure", kurs.KursSure);
                cmd.Parameters.AddWithValue("@KursTopic", kurs.KursTopics);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<tbl_Kurs> KursGetir()
        {
            List<tbl_Kurs> Ls = new List<tbl_Kurs>();


            string conString = "server =.; Initial Catalog = serkanKursDB; Integrated Security = SSPI";
            string cmdString = "select * from tbl_Kurs";
            SqlConnection con = new SqlConnection(conString);
            SqlCommand cmd = new SqlCommand(cmdString, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                tbl_Kurs kurs = new tbl_Kurs();
                kurs.KursId = int.Parse(dr["KursId"].ToString());
                kurs.KursTitle = dr["KursTitle"].ToString();
                kurs.KursDate = DateTime.Parse(dr["KursDate"].ToString());
                kurs.KursSure = dr["KursSure"].ToString();
                kurs.KursTopics = dr["KursTopics"].ToString();


                Ls.Add(kurs);

            }
            dr.Close();
            con.Close();
            return Ls;


        }

        public tbl_Kurs KursGetirById(int KursId)
        {
            tbl_Kurs kurs = null;

            string conString = "server =.; Initial Catalog = serkanKursDB; Integrated Security = SSPI";
            string cmdString = "select * from tbl_Kurs where KursId=@KursId";
            SqlConnection con = new SqlConnection(conString);
            SqlCommand cmd = new SqlCommand(cmdString, con);
            cmd.Parameters.AddWithValue("@KursId", KursId);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                kurs = new tbl_Kurs();
                kurs.KursId = int.Parse(dr["KursId"].ToString());
                kurs.KursDate = Convert.ToDateTime(dr["KursDate"]);
                kurs.KursTitle = dr["KursTitle"].ToString();
                kurs.KursSure = dr["KursSure"].ToString();
                kurs.KursTopics = dr["KursTopics"].ToString();

            }
            dr.Close();
            con.Close();


            return kurs;

        }


        public bool UpdateKursById(tbl_Kurs Kurs, int KursId)
        {
            try 
            {

                string conString = "server =.; Initial Catalog = serkanKursDB; Integrated Security = SSPI";
                string cmdString = "Update tbl_Kurs  set KursTitle=@KursTitle, KursDate=@KurdDate,KursSure=@KursSure,KursTopics=@KursTopics where KursId=@KursId";
                SqlConnection con = new SqlConnection(conString);
                SqlCommand cmd = new SqlCommand(cmdString, con);
                cmd.Parameters.AddWithValue("@KursTitle", Kurs.KursTitle);
                cmd.Parameters.AddWithValue("@KurdDate", Kurs.KursDate);
                cmd.Parameters.AddWithValue("@KursSure", Kurs.KursSure);
                cmd.Parameters.AddWithValue("@KursTopics", Kurs.KursTopics);
                cmd.Parameters.AddWithValue("@KursId", KursId);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                return true;

              }
            catch
            {
                return false;
            }



        }


        public bool DeleteKursById(int KursId)
        {
            try 
            {

                string conString = "server =.; Initial Catalog = serkanKursDB; Integrated Security = SSPI";
                string cmdString = "Delete tbl_Kurs where KursId=@KursId";
                SqlConnection con = new SqlConnection(conString);
                SqlCommand cmd = new SqlCommand(cmdString, con);
                cmd.Parameters.AddWithValue("@KursId", KursId);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
               
            } 

                            
            catch
            {
                return false;
            }




        }



        public bool TrainerAta(List<tbl_Trainer_Kurs> Ls)
        {

            string conString = "server =.; Initial Catalog = serkanKursDB; Integrated Security = SSPI";

            try
            {
                foreach (var item in Ls)

                {
                    string cmdString = "insert into tbl_Trainer_Kurs values (@TrainerId,@KursId,null,null,null,null)";
                    SqlConnection con = new SqlConnection(conString);
                    SqlCommand cmd = new SqlCommand(cmdString, con);
                    cmd.Parameters.AddWithValue("@TrainerId", item.TrainerId);
                    cmd.Parameters.AddWithValue("@KursId", item.KursId);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    

                }

                return true;

            }
            catch
            {
                return false;

            }

           
        }











    }





}
