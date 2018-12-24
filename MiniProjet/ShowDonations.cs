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
    public partial class ShowDonations : Form
    {
        BindingSource dons = new BindingSource();
        public ShowDonations()
        {
            InitializeComponent();
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void maximize_Click(object sender, EventArgs e)
        {
            WindowState = WindowState == FormWindowState.Maximized
                         ? FormWindowState.Normal
                         : FormWindowState.Maximized;
            this.CenterToScreen();
        }

        private void minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\Folder\MiniProjet\Gestion_Association\MiniProjet\MiniProjet.mdf;Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter sda = new SqlDataAdapter("select * from Donation", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            dons.DataSource = ds.Tables[0];
            dataGridView1.DataSource = dt;
            panel2.Visible = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string cin = textBox1.Text;
            string query = "Select * from Donation where Donation.id_membre in (select id from membre where cin Like '%"+cin+"%')";
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\Folder\MiniProjet\Gestion_Association\MiniProjet\MiniProjet.mdf;Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter sda = new SqlDataAdapter(query,conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            GestionAssoc ga = new GestionAssoc();
            ga.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            dons.MovePrevious();
            UpdatDGV();
            records();
        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            dons.MoveNext();
            UpdatDGV();
            records();
        }
        private void records()
        {
            label3.Text = "Membre " + (dons.Position + 1) + " sur " + (dons.Count - 1);
        }
        private void UpdatDGV()
        {
            dataGridView1.ClearSelection();
            try
            {
                dataGridView1.Rows[dons.Position].Selected = true;
            }
            catch
            {
                MessageBox.Show("Donnés Insufissance", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            records();
        }

    }
}
