using BLL;
using BOL;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Admin
{
    public partial class Kurs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                GridData();
                GetTrainers();
            }


        }

        private void GetTrainers()
        {

            UserBussiness UB = new UserBussiness();
            List<tbl_User> Ls = UB.GetTrainers();
            cblTrainers.DataSource = Ls;
            cblTrainers.DataTextField = "FirstName";
            cblTrainers.DataValueField = "UserId";
            cblTrainers.DataBind();

        }





        private void GridData()
        {
            KursBussiness kb = new KursBussiness();
            List<tbl_Kurs> Ls = kb.KursGetir();
            grdKurs.DataSource = Ls;
            grdKurs.DataBind();
        }

        protected void btnKursEkle_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(txtKursSure.Text) && !string.IsNullOrEmpty(txtKursTitle.Text) && !string.IsNullOrEmpty(txtKursTopic.Text) && !string.IsNullOrEmpty(dtpKursDate.Text))
            {

                tbl_Kurs kurs = new tbl_Kurs();

                kurs.KursTitle = txtKursTitle.Text;
                kurs.KursSure = txtKursSure.Text;
                kurs.KursTopics = txtKursTopic.Text;
                kurs.KursDate = Convert.ToDateTime(dtpKursDate.Text);

                KursBussiness kB = new KursBussiness();

                kB.InstertKurs(kurs);
                Response.Redirect(Request.Url.ToString(), false); //Sayfa yenilendiğinde tekrar eklemeyi önlüyor

                txtKursSure.Text = string.Empty;
                txtKursTitle.Text = string.Empty;
                txtKursTopic.Text = string.Empty;
                dtpKursDate.Text = string.Empty;
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Kurs Eklendi');", true);

                GridData();

            }
            else
            {

                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Kurs ekleme ekranındaki girişler boş olamaz!');", true);

            }

        }

        protected void grdKurs_SelectedIndexChanged(object sender, EventArgs e)
        {

            int id = int.Parse(grdKurs.SelectedValue.ToString());
            KursBussiness KursBussines = new KursBussiness();
            tbl_Kurs kurs = KursBussines.KursGetirById(id);
            txtKursSure.Text = kurs.KursSure.ToString();
            txtKursTitle.Text = kurs.KursTitle.ToString();
            txtKursTopic.Text = kurs.KursTopics.ToString();
            dtpKursDate.Text = kurs.KursDate.ToString("yyyy-MM-dd");

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);


        }

       

        protected void btnKursUpdate_Click(object sender, EventArgs e)
        {
            tbl_Kurs kurs = new tbl_Kurs();
            kurs.KursTitle = txtKursTitle.Text;
            kurs.KursSure = txtKursSure.Text;
            kurs.KursTopics = txtKursTopic.Text;
            kurs.KursDate = Convert.ToDateTime(dtpKursDate.Text);



            KursBussiness Kb = new KursBussiness();


            int id = Convert.ToInt32(grdKurs.SelectedValue.ToString());
            Kb.UpdateKursById(kurs, id);
            GridData();

        }

        protected void btnKursDelete_Click(object sender, EventArgs e)
        {
            KursBussiness kb = new KursBussiness();

            int id = Convert.ToInt32(grdKurs.SelectedValue.ToString());

            kb.DeleteKursById(id);


            GridData();

        }

        protected void btnTrainerAta_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(cblTrainers.SelectedValue.ToString()) && grdKurs.SelectedValue != null)
            {

                

                List<tbl_Trainer_Kurs> Ls = new List<tbl_Trainer_Kurs>();

                int KursId = int.Parse(grdKurs.SelectedValue.ToString());

                foreach (ListItem item in cblTrainers.Items)
                {
                    if (item.Selected)
                    {
                        int TrainerId = int.Parse(item.Value);
                        tbl_Trainer_Kurs tk = new tbl_Trainer_Kurs();
                        tk.TrainerId = TrainerId;
                        tk.KursId = KursId;
                        Ls.Add(tk);

                    }


                }

                if (Ls.Count > 0)
                {
                    KursBussiness kb = new KursBussiness();
                    kb.TrainerAta(Ls);


                }


            }
            else
            {
                if(string.IsNullOrEmpty(cblTrainers.SelectedValue.ToString()))
                {

                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Öğretmen Seçimi Yapmadınız');", true);


                }
                else
                {

                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Kurs Seçimi Yapmadınız');", true);


                }

            }






        }

        protected void btnEkranTemizle_Click(object sender, EventArgs e)
        {

        }
    }
}