using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MiniProjet
{
    public partial class addMember : Form
    {
        public addMember()
        {
            InitializeComponent();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
        
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox13_TextChanged(object sender, EventArgs e)
        {
            
            
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nom = nomTB.Text;
            string prenom = prenomTB.Text;
            string cin = cinTB.Text;
            string ville = villeTB.Text;
            string code_postal = cpTB.Text;
            char sexe = genderCBX.Text == "Masculin" ?'M' : 'F';
            string email = emailTB.Text;
            string tele = phoneTB.Text;
            string date_naiss = birthdayCAL.Value.ToShortDateString();
            string lieu_naiss = birthplaceTB.Text;
            string statut = statutCBX.Text;
            string statut_civil = statutCivilCBX.Text;
            string position = positionCBX.Text;
            decimal somme_arg = decimal.Parse(argentTB.Text);
            string methode_pay = methodeCBX.Text;

            
            SqlConnection sc = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\Folder\MiniProjet\Gestion_Association\MiniProjet\MiniProjet.mdf;Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter sda = new SqlDataAdapter("select * from MEMBRE",sc);
            DataSet ds = new DataSet();
            sda.Fill(ds,"membre");
            sda = new SqlDataAdapter("select * from Payement", sc);
            sda.Fill(ds, "payement");
            SqlCommandBuilder cmd = new SqlCommandBuilder(sda);
            DataRow MemberRows = ds.Tables["membre"].NewRow();
            MemberRows["nom"] = nom;
            MemberRows["prenom"] = prenom;
            MemberRows["cin"] = cin;
            MemberRows["ville"] = ville;
            MemberRows["Code_Postal"] = code_postal;
            MemberRows["sexe"] = sexe;
            MemberRows["email"] = email;
            MemberRows["num_tele"] = tele;
            MemberRows["date_naissance"] = date_naiss;
            MemberRows["lieu_naissance"] = lieu_naiss;
            MemberRows["statut"] = statut;
            MemberRows["statut_civil"] = statut_civil;
            MemberRows["position"] = position;
            ds.Tables["membre"].Rows.Add(MemberRows);
            cmd.GetInsertCommand();
            sda.Update(ds, "membre");
            sda = new SqlDataAdapter("select TOP 1 id from MEMBRE order by id DESC ", sc);
            sda.Fill(ds,"member_id");
            int member_id = int.Parse(ds.Tables["member_id"].Rows[0]["id"].ToString());

            /*
            int i = ds.Tables[0].Rows.Count;
            // .????
            int member_id = ds.Tables[0].Rows[i - 1]["id"];
            //*/
            DataRow PayementRows = ds.Tables["payement"].NewRow();
            PayementRows["membre_id"] = member_id;
            PayementRows["methode_payement"] = methode_pay;
            PayementRows["somme_argent"] = somme_arg;
            ds.Tables["payement"].Rows.Add(PayementRows);
            sda.Update(ds, "payement");
            //sda.Update(ds);
            var mb = MessageBox.Show(this, "Membre Ajouté!", "Operation réussi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            if (mb == DialogResult.OK)
            {
                this.Hide();
                GestionAssoc ga = new GestionAssoc();
                ga.Show();
            }

        }


        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            /*Object selectedItem = comboBox6.SelectedItem;
            if (selectedItem.ToString() == "Carte Bancaire")
                panel2.Visible = true;
            if (selectedItem.ToString() != "Carte Bancaire")
                panel2.Visible = false;*/
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            panel2.Visible = true;
            if (String.IsNullOrEmpty(argentTB.Text))
                panel2.Visible = false;
        }

        private void methodeTB_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
