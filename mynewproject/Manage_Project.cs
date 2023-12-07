using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using mynewproject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace mynewproject
{
    public partial class Manage_Project : Form
    {

        public Manage_Project()
        {
            InitializeComponent();
            /*DataGridView gv = new DataGridView();
            gv.DataSource = new List<string>() { "sss", "aaa" }.Select(x => new { Name = x }).ToList();
            this.Controls.Add(gv); // add gridview to current form or panel ( or container), then only it will display */
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Admin_welcome aw = new Admin_welcome();
            aw.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var context = new TaskManagerContext())
            {
                try
                {
                    int id = int.Parse(textBox1.Text);
                    var Project = context.Projects.Single(p => p.Pid == int.Parse(textBox1.Text));
                    if (Project != null)
                    {
                        Project_details pd = new Project_details();
                        pd.id = int.Parse(textBox1.Text);
                        pd.Show();
                        this.Visible = false;
                        pd.id = int.Parse(textBox1.Text);
                        pd.tb2.Text = Project.Name;
                        Project_details.instance.dtp1.Value = Convert.ToDateTime(Project.StartDate);
                        Project_details.instance.dtp2.Value = Convert.ToDateTime(Project.Deadline);
                        pd.cb1.Text = Project.Status;
                    }
                }
                catch
                {
                    MessageBox.Show("Cannot Fetch Data with Given Pid");
                }
            }
        }

        private void Manage_Project_Load(object sender, EventArgs e)
        {
            using (TaskManagerContext context = new TaskManagerContext())
            {
                dataGridView1.DataSource = context.Projects.ToList();
                dataGridView1.Columns.Remove("ptes");
                dataGridView1.Columns.Remove("tasks");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (TaskManagerContext context = new TaskManagerContext())
            {
                try
                {
                    context.Remove(context.Projects.Single(a => a.Pid == int.Parse(textBox1.Text)));
                    context.SaveChanges();
                    MessageBox.Show("Project Deleted successfully..");
                    Manage_Project_Load(sender, e);
                }
                catch
                {
                    MessageBox.Show("Something Went Wrong on server..");
                }
            }
        }
    }
}
