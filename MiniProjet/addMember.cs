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
            string somme_arg = argentTB.Text;
            string methode_pay = methodeCBX.Text;

            
            SqlConnection sc = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\Folder\MiniProjet\Gestion_Association\MiniProjet\MiniProjet.mdf;Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter sda = new SqlDataAdapter("select * from MEMBRE",sc);
            SqlCommandBuilder cmd = new SqlCommandBuilder(sda);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            DataRow MyRow = ds.Tables[0].NewRow();
            MyRow["nom"] = nom;
            MyRow["prenom"] = prenom;
            MyRow["cin"] = cin;
            MyRow["ville"] = ville;
            MyRow["Code_Postal"] = code_postal;
            MyRow["sexe"] = sexe;
            MyRow["email"] = email;
            MyRow["num_tele"] = tele;
            MyRow["date_naissance"] = date_naiss;
            MyRow["lieu_naissance"] = lieu_naiss;
            MyRow["statut"] = statut;
            MyRow["statut_civil"] = statut_civil;
            MyRow["position"] = position;
            ds.Tables[0].Rows.Add(MyRow);
            sda.Update(ds);
            MessageBox.Show(this, "Membre Ajouté!", "Operation réussi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
