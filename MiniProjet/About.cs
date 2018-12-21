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
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\Folder\MiniProjet\Gestion_Association\MiniProjet\MiniProjet.mdf;Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter sda;
            string query;
            query = "select * from Association";
            sda = new SqlDataAdapter(query,conn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            this.label5.Text = ds.Tables[0].Rows[0][1].ToString();
            this.label10.Text = ds.Tables[0].Rows[0][2].ToString();
            this.label11.Text = ds.Tables[0].Rows[0][3].ToString();
            this.label12.Text = ds.Tables[0].Rows[0][4].ToString();
            this.label13.Text = ds.Tables[0].Rows[0][5].ToString();
            this.richTextBox1.Text = ds.Tables[0].Rows[0][6].ToString();
            this.label15.Text = ds.Tables[0].Rows[0][7].ToString();

        }
        
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            GestionAssoc ga = new GestionAssoc();
            ga.Show();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Dispose();
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

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            
        }
    }
}
