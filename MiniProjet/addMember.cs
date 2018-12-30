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

            //TextBox tb = new TextBox();
            //if (tb != argentTB && string.IsNullOrEmpty(tb.Text))
            //{
            //    MessageBox.Show(this, "Certains champs n'ont pas était remplit", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    //button1.Enabled = false;
            //    return;
            //}


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
            decimal somme_arg = 0;
            if (argentTB.Text != "")
            somme_arg = decimal.Parse(argentTB.Text);
            string methode_pay = methodeCBX.Text;

            

            //string query = "insert into MEMBRE (nom,prenom,cin,ville,Code_Postal,sexe,email,num_tele,date_naissance,lieu_naissance,statut,statut_civil,position) values('"+ nom + "','"+ prenom + "','"+ cin + "','"+ ville + "','"+ code_postal + "','"+ sexe + "','"+ email + "','"+ tele + "','"+ date_naiss + "','"+ lieu_naiss + "','"+ statut + "','"+ statut_civil + "','"+ position+"')";
            string query = "insert into MEMBRE (nom,prenom,cin,ville,Code_Postal,sexe,email,num_tele,date_naissance,lieu_naissance,statut,statut_civil) values(@nom,@prenom,@cin,@ville,@code_postal,@sexe,@email,@tele,@date_naiss,@lieu_naiss,@statut,@statut_civil)";

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\Folder\MiniProjet\Gestion_Association\MiniProjet\MiniProjet.mdf;Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlDataAdapter sda1 = new SqlDataAdapter("Select count(*) from [Membre] where cin='" + cin + "'", con);
            DataTable dt = new DataTable();
            sda1.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                MessageBox.Show(this, "Membre déja inscrit !", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
            sda.InsertCommand = new SqlCommand(query,con);
            sda.InsertCommand.Parameters.Add("@nom",SqlDbType.VarChar).Value = nom;
            sda.InsertCommand.Parameters.Add("@prenom", SqlDbType.VarChar).Value = prenom;
            sda.InsertCommand.Parameters.Add("@cin", SqlDbType.VarChar).Value = cin;
            sda.InsertCommand.Parameters.Add("@ville", SqlDbType.VarChar).Value = ville;
            sda.InsertCommand.Parameters.Add("@code_postal", SqlDbType.VarChar).Value = code_postal;
            sda.InsertCommand.Parameters.Add("@sexe", SqlDbType.Char).Value = sexe;
            sda.InsertCommand.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
            sda.InsertCommand.Parameters.Add("@tele", SqlDbType.VarChar).Value = tele;
            sda.InsertCommand.Parameters.Add("@date_naiss", SqlDbType.Date).Value = date_naiss;
            sda.InsertCommand.Parameters.Add("@lieu_naiss", SqlDbType.VarChar).Value = lieu_naiss;
            sda.InsertCommand.Parameters.Add("@statut", SqlDbType.VarChar).Value = statut;
            sda.InsertCommand.Parameters.Add("@statut_civil", SqlDbType.VarChar).Value = statut_civil;
            con.Open();
                try
                {
                     sda.InsertCommand.ExecuteNonQuery();
                     DataSet ds = new DataSet();
                     sda = new SqlDataAdapter("select MAX(id) from MEMBRE", con);
                     sda.Fill(ds, "member_id");
                     int membre_id = int.Parse(ds.Tables["member_id"].Rows[0][0].ToString());
                     query = "insert into Adhesion(id_membre,position) values (@membre_id,@position)";
                     sda.InsertCommand = new SqlCommand(query, con);
                     sda.InsertCommand.Parameters.Add("@membre_id", SqlDbType.Int).Value = membre_id;
                     sda.InsertCommand.Parameters.Add("@position", SqlDbType.VarChar).Value = position;
                     sda.InsertCommand.ExecuteNonQuery();
                     query = "insert into Payement (membre_id,methode_payement,somme_argent) values (@membre_id,@methode_payement,@somme_argent)";
                     sda.InsertCommand = new SqlCommand(query, con);
                     sda.InsertCommand.Parameters.Add("@membre_id", SqlDbType.Int).Value = membre_id;
                     sda.InsertCommand.Parameters.Add("@methode_payement", SqlDbType.VarChar).Value = methode_pay;
                     sda.InsertCommand.Parameters.Add("@somme_argent", SqlDbType.VarChar).Value = somme_arg;
               
                     sda.InsertCommand.ExecuteNonQuery();
                     var mb = MessageBox.Show(this, "Membre Ajouté!", "Operation réussi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                     if (mb == DialogResult.OK)
                     {
                        this.Hide();
                        GestionAssoc ga = new GestionAssoc();
                        ga.Show();
                     }
                }catch(Exception ex)
                {
                    MessageBox.Show("Certains champs n'ont pas était remplis");
                }

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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            GestionAssoc ga = new GestionAssoc();
            ga.Show();
        }

        private void minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void maximize_Click(object sender, EventArgs e)
        {
            WindowState = WindowState == FormWindowState.Maximized
                         ? FormWindowState.Normal
                         : FormWindowState.Maximized;
            this.CenterToScreen();
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.FromArgb(22, 160, 133);
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackColor = SystemColors.ButtonFace;
        }
    }
}
