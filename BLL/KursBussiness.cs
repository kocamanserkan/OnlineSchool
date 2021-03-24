using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;
using DAL;

namespace BLL
{
   public class KursBussiness
    {

        public bool InstertKurs(tbl_Kurs kurs)
        {

            //Kurs date should be greater than current date
            if (kurs.KursDate > DateTime.Now)
            {
                KursDB kursDb = new KursDB();
               
                return kursDb.InstertKurs(kurs);
                

            }
            else
            {
                return false;
            }


        }

        public List<tbl_Kurs> KursGetir()
        {

            KursDB kursdb = new KursDB();
            return kursdb.KursGetir();

        }

        public tbl_Kurs KursGetirById(int KursId)
        {
            KursDB kursDb = new KursDB();
            tbl_Kurs kurs = kursDb.KursGetirById(KursId);

            return kurs;


        }

        public bool UpdateKursById(tbl_Kurs kurs, int kursId)
        {

            KursDB kursDb = new KursDB();
            if (kurs.KursDate > DateTime.Now)
            {
                kursDb.UpdateKursById(kurs, kursId);
                return true;
            }
            else
            {

                return false;

            }



        }

        public bool DeleteKursById(int KursId)
        {
            KursDB kursDb = new KursDB();
            kursDb.DeleteKursById(KursId);
            return true;



        }

        public bool TrainerAta(List<tbl_Trainer_Kurs> Ls)
        {

            KursDB kDB = new KursDB();
            kDB.TrainerAta(Ls);

            return true;



        }










    }
}
