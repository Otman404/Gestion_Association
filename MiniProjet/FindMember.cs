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
    public partial class FindMember : Form
    {
        BindingSource members = new BindingSource();
        SqlDataAdapter sda1;
        DataTable dt1;
        public FindMember()
        {
            InitializeComponent();
        }

        private void FindMember_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           /* SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\Folder\MiniProjet\Gestion_Association\MiniProjet\MiniProjet.mdf;Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter sda = new SqlDataAdapter("select * from Member where cin LIKE '%"+ textBox1.Text+"%'", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;*/

        }

        private void Afficher_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\Folder\MiniProjet\Gestion_Association\MiniProjet\MiniProjet.mdf;Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter sda = new SqlDataAdapter("getMemberByCIN", conn);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sda.SelectCommand.Parameters.AddWithValue("@cin",textBox1.Text);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            records();
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\Folder\MiniProjet\Gestion_Association\MiniProjet\MiniProjet.mdf;Integrated Security=True;Connect Timeout=30");
            sda1 = new SqlDataAdapter("select * from MEMBRE", conn);
            dt1 = new DataTable();
            sda1.Fill(dt1);
            dataGridView1.DataSource = dt1;
            DataSet ds = new DataSet();
            sda1.Fill(ds);
            members.DataSource = ds.Tables[0];
            records();
            panel2.Visible = true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            GestionAssoc ga = new GestionAssoc();
            ga.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ajouter_Click(object sender, EventArgs e)
        {
            this.Hide();
            addMember am = new addMember();
            am.Show();
        }

        private void modifier_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Donation fm = new Donation();
            this.Hide();
            fm.Show();
        }

        private void info_Click(object sender, EventArgs e)
        {
            this.Hide();
            About a = new About();
            a.Show();
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            members.MovePrevious();
            UpdatDGV();
            records();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            members.MoveNext();
            UpdatDGV();
            records();
        }
        private void UpdatDGV()
        {
            dataGridView1.ClearSelection();
            try
            {
            dataGridView1.Rows[members.Position].Selected = true;
            }
            catch
            {
                MessageBox.Show("Donnés Insufissance","Erreur",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

            records();
        }
        private void records()
        {
            label2.Text = "Membre "+ (members.Position + 1) + " sur " +(members.Count - 1);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlCommandBuilder scb = new SqlCommandBuilder(sda1);
            sda1.Update(dt1);
            MessageBox.Show(this, "Modification Effectuée !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string cin = textBox1.Text;
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\Folder\MiniProjet\Gestion_Association\MiniProjet\MiniProjet.mdf;Integrated Security=True;Connect Timeout=30");
            string query = "Delete from Membre where cin = @cin";
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.DeleteCommand = new SqlCommand(query, conn);
            sda.DeleteCommand.Parameters.Add("@cin", SqlDbType.VarChar).Value = cin;
            conn.Open();
            var res = MessageBox.Show(this, "Etes-vous sûr de supprimer ce membre ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if(res == DialogResult.Yes)
            {
            sda.DeleteCommand.ExecuteNonQuery();
            MessageBox.Show(this, "Membre Supprimé !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
            MessageBox.Show(this, "Operation annulée", "Annulation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            ShowDonations sd = new ShowDonations();
            sd.Show();
        }
    }
}
