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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection;

namespace mynewproject
{
    public partial class view_tasks : Form
    {
        public string email;
        public string pass;
        public int empid;
        public view_tasks()
        {
            InitializeComponent();
        }

        private void view_tasks_Load(object sender, EventArgs e)
        {
            //if (email != null && pass != null)
            //{
            using (var db = new TaskManagerContext())
            {
                //MessageBox.Show("i am here 1");
                var result = db.Employees.SingleOrDefault(b => b.Email == email );
                if (result != null)
                {
                    empid = result.Empid;
                    //MessageBox.Show("i am here 2");
                    var result1 = db.Ptes.SingleOrDefault(b1 => b1.Empid == empid);
                    if (result1 != null)
                    {
                        //MessageBox.Show("i am here 3");
                        var person = (from p in db.Tasks
                                      join t in db.Ptes
                                      on p.Tid equals t.Tid
                                      where t.Empid == empid
                                      select new
                                      {
                                          TaskID = p.Tid,
                                          TaskName = p.TaskTitle,
                                          ProjectID = p.Pid,
                                          Deadline = p.Deadline,
                                          comment = p.Comment,
                                          Status = p.Status,
                                          priority = p.Priority,
                                      }).ToList();

                        dataGridView2.DataSource = person.ToList();
                        //MessageBox.Show("i am here 4");
                    }
                }
            }
            //TaskManagerContext db = new TaskManagerContext();
            //dataGridView2.DataSource = db.Tasks.ToList();
            //dataGridView1.Columns.Remove("ptes");
            //dataGridView1.Columns.Remove("tasks");
        //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Action_on_Task aot = new Action_on_Task();
            aot.email = email;
            aot.pass = pass;
            aot.Show();
            aot.taskid = int.Parse(textBox1.Text);
            aot.projectid = int.Parse(textBox2.Text);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Employee_welcome ew = new Employee_welcome();
            ew.email = email;
            ew.pass = pass;
            ew.Show();
            this.Close();
        }
    }
}
