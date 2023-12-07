using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using mynewproject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace mynewproject
{
    public partial class Manage_task : Form
    {
        public int taskid;
        public int projectid;
        public Manage_task()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Admin_welcome aw = new Admin_welcome();
            aw.Show();
            this.Close();
        }

        private void Manage_task_Load(object sender, EventArgs e)
        {
            // data showing in grid view (implement edit button )
            using (TaskManagerContext context = new TaskManagerContext())
            {
                var person = (from p in context.Tasks
                              join t in context.Ptes
                              on p.Tid equals t.Tid
                              into gj from x in gj.DefaultIfEmpty()
                              select new
                              {
                                  TaskID = p.Tid,
                                  TaskName = p.TaskTitle,
                                  EmployeeID = (x == null ? null : x.Empid),
                                  ProjectID = p.Pid,
                                  Deadline = p.Deadline,
                                  Progress = p.Progress,
                                  Status = p.Status,
                              }).ToList();

                dataGridView1.DataSource = person.ToList();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var context = new TaskManagerContext())
            {
                try
                {
                    var task = context.Tasks.Single(t => t.Tid == int.Parse(textBox1.Text) && t.Pid == int.Parse(textBox2.Text));
                    Task_details td = new Task_details();
                    if (task != null)
                    {
                        td.Show();
                        this.Visible = false;
                        td.tb2.Text = textBox2.Text;
                        td.tb3.Text = task.TaskTitle;
                        td.tb5.Text = task.Progress.ToString();
                        td.tb6.Text = task.Comment;
                        td.rtb1.Text = task.Description;
                        td.cb1.Text = task.Priority;
                        td.cb2.Text = task.Status;
                        td.taskid = int.Parse(textBox1.Text);
                        td.projectid = int.Parse(textBox2.Text);
                        td.dtp1.Value = Convert.ToDateTime(task.Deadline);
                        
                    }
                    /*var pte = context.Ptes.Single(p => p.Tid == int.Parse(textBox1.Text) && p.Pid == int.Parse(textBox2.Text));
                    if (pte != null)
                    {
                        td.tb4.Text = pte.Empid.ToString();
                    }*/
                }
                catch
                {
                    MessageBox.Show("Cannot Fetch Data with Given task id & project id");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (TaskManagerContext context = new TaskManagerContext())
            {
                try
                {
                    context.Remove(context.Tasks.SingleOrDefault(b => b.Tid == int.Parse(textBox1.Text) && b.Pid == int.Parse(textBox2.Text)));
                    context.Remove(context.Ptes.SingleOrDefault(b => b.Tid == int.Parse(textBox1.Text) && b.Pid == int.Parse(textBox2.Text)));
                    context.SaveChanges();
                    MessageBox.Show("Task Deleted successfully..");
                    Manage_task_Load(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Something Went Wrong on server..");
                }
            }
        }
    }
}
