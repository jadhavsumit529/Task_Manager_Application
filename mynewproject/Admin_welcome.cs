using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mynewproject
{
    public partial class Admin_welcome : Form
    {
        public Admin_welcome()
        {
            InitializeComponent();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void buttonToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripContainer1_ContentPanel_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Employee_details ed = new Employee_details();
            ed.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Manage_Employee me = new Manage_Employee();
            me.Show();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Task_details td = new Task_details();
            td.Show();
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Manage_task mt = new Manage_task();
            mt.Show();
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Project_details pd = new Project_details();
            pd.Show();
            this.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Manage_Project mp = new Manage_Project();
            mp.Show();
            this.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form2.adminid = 0;
            Form2 f2 = new Form2();
            f2.Show();
            this.Close();
        }

        private void Admin_welcome_Load(object sender, EventArgs e)
        {

        }
    }
}
