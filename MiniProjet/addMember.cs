using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            if (!String.IsNullOrEmpty(textBox1.Text) && textBox1.Text != "0"){
                tabControl1.SelectedTab = tabPage3;
            }
            else
            {
                //connect to db and send data to add member
            }
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            Object selectedItem = comboBox6.SelectedItem;
            if (selectedItem.ToString() == "Carte Bancaire")
                panel2.Visible = true;
            if (selectedItem.ToString() != "Carte Bancaire")
                panel2.Visible = false;
        }
    }
}
