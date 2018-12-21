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
using System.Data.SqlClient;

namespace MiniProjet
{
    public partial class Donation : Form
    {
        public Donation()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            GestionAssoc ga = new GestionAssoc();
            ga.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\Folder\MiniProjet\Gestion_Association\MiniProjet\MiniProjet.mdf;Integrated Security=True;Connect Timeout=30");
            string query = "Select count(*) from [Membre] where cin ='" + textBox2.Text + "' ";
            SqlDataAdapter sda;
            sda = new SqlDataAdapter( query, conn);

            DataTable dt = new DataTable();
            sda.Fill(dt);
            if ((dt.Rows[0][0].ToString() == "1") && (!string.IsNullOrEmpty(textBox2.Text)))
            {
                panel3.Visible = true;   
                DataSet ds = new DataSet();
                query = "Select * from MEMBRE where cin ='" + textBox2.Text + "' ";
                sda = new SqlDataAdapter(query, conn);
                sda.Fill(ds, "membre");
                label5.Text = ds.Tables["membre"].Rows[0][1].ToString();
                label6.Text = ds.Tables["membre"].Rows[0][2].ToString();
            }
            else
            {
                panel3.Visible = false;
                MessageBox.Show(this, "Membre Introuvable", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Donation_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\Folder\MiniProjet\Gestion_Association\MiniProjet\MiniProjet.mdf;Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter sda;
            string query;
            query = "Select * from MEMBRE where cin ='" + textBox2.Text + "' ";
            sda = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            sda.Fill(ds, "membre");
            
            int member_id = int.Parse(ds.Tables[0].Rows[0][0].ToString());
            if (!String.IsNullOrEmpty(textBox1.Text) && !String.IsNullOrEmpty(methodeCBX.Text))
            {

                decimal montant = decimal.Parse(textBox1.Text);
                string methode = methodeCBX.Text;
                query = "insert into Payement (membre_id,methode_payement,somme_argent) values(@membre_id,@methode_payement,@somme_argent)";
                sda.InsertCommand = new SqlCommand(query, conn);
                sda.InsertCommand.Parameters.Add("@membre_id", SqlDbType.Int).Value = member_id;
                sda.InsertCommand.Parameters.Add("@methode_payement", SqlDbType.VarChar).Value = methode;
                sda.InsertCommand.Parameters.Add("@somme_argent", SqlDbType.Decimal).Value = montant;
                conn.Open();
                sda.InsertCommand.ExecuteNonQuery();
                MessageBox.Show(this, "Payement effectué avec succès", "Operation Effectué", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
            else
            {
                MessageBox.Show(this, "Champs Vide", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

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

        private void close_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
