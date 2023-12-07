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

namespace mynewproject
{
    public partial class Action_on_Task : Form
    {
        public int taskid;
        public int projectid;
        public string email;
        public string pass;
        public Action_on_Task()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            view_tasks vt = new view_tasks();
            vt.email = email;
            vt.pass = pass;
            vt.Show();
            this.Close();
        }

        private void Action_on_Task_Load(object sender, EventArgs e)
        {
            using (TaskManagerContext context = new TaskManagerContext())
            {
                try
                {
                    var result = context.Tasks.SingleOrDefault(b => b.Tid == taskid & b.Pid == projectid);
                    {
                        if (result != null)
                        {
                            textBox1.Text = result.Progress.ToString();
                            comboBox1.Text = result.Status;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("cannot retrive information (something went wrong...)");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using(TaskManagerContext context = new TaskManagerContext())
            {
                try
                {
                    var result = context.Tasks.SingleOrDefault(b => b.Tid == taskid & b.Pid == projectid);
                    {
                        if (result != null)
                        {
                            result.Progress = int.Parse(textBox1.Text);
                            result.Status = comboBox1.Text;
                            context.SaveChanges();
                            view_tasks vt = new view_tasks();
                            vt.email = email;
                            vt.pass = pass;
                            vt.Show();
                            this.Close();
                            MessageBox.Show("Task updated successfully...");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("cannot edit info (something went wrong...)");
                }
            }
        }
    }
}
