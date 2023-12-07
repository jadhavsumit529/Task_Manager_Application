using mynewproject.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace mynewproject
{
    public partial class Task_details : Form
    {
        public System.Windows.Forms.TextBox? tb2;
        public System.Windows.Forms.TextBox? tb3;
        public System.Windows.Forms.TextBox? tb5;
        public System.Windows.Forms.TextBox? tb6;
        public System.Windows.Forms.ComboBox? cb1;
        public System.Windows.Forms.ComboBox? cb2;
        public System.Windows.Forms.ComboBox? cb3;
        public System.Windows.Forms.RichTextBox? rtb1;
        public System.Windows.Forms.DateTimePicker? dtp1;
        public int? taskid = null;
        public int projectid;

        public object Empid { get; private set; }

        public Task_details()
        {
            InitializeComponent();
            tb2 = textBox2;
            tb3 = textBox3;
            tb5 = textBox5;
            tb6 = textBox6;
            cb1 = comboBox1;
            cb2 = comboBox2;
            cb3 = comboBox3;
            rtb1 = richTextBox1;
            dtp1 = dateTimePicker1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Admin_welcome aw = new Admin_welcome();
            aw.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            //comboBox3.Items.Clear();
            richTextBox1.Text = "";
            dateTimePicker1.Text = DateTime.Now.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (taskid == null)
            {
                //adding task details in task table
                Models.Task t = new Models.Task();
                t.Pid = int.Parse(textBox2.Text);
                t.TaskTitle = textBox3.Text;
                t.Description = richTextBox1.Text;
                t.Priority = comboBox1.Text;
                t.Status = comboBox2.Text;
                t.Deadline = dateTimePicker1.Value;
                t.Progress = int.Parse(textBox5.Text);
                t.Comment = textBox6.Text;
                var context = new TaskManagerContext();
                context.Tasks.Add(t);
                context.SaveChanges();

                //adding task and employee in pte table
                if (comboBox3.Text != "Please select")
                {
                    Models.Pte pte = new Models.Pte();
                    using (var context1 = new TaskManagerContext())
                    {
                        try
                        {
                            var task = context1.Tasks.SingleOrDefault(t => t.TaskTitle == textBox3.Text);
                            if (t != null)
                            {
                                pte.Empid = int.Parse(comboBox3.SelectedValue.ToString());
                                pte.Pid = int.Parse(textBox2.Text);
                                pte.Tid = t.Tid;
                                context1.SaveChanges();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("something went wrong");
                        }
                    }
                    var cont = new TaskManagerContext();
                    cont.Ptes.Add(pte);
                    cont.SaveChanges();
                }
                button2_Click(sender, e);
                MessageBox.Show("Task Created Successfully ");
            }

            //updating value if id is present already 
            if (taskid != null)
            {
                using (var db = new TaskManagerContext())
                {
                    var result = db.Tasks.SingleOrDefault(b => b.Tid == taskid && b.Pid == projectid);
                    if (result != null)
                    {
                        // updating task details in task table
                        result.TaskTitle = textBox3.Text;
                        result.Description = richTextBox1.Text;
                        result.Priority = comboBox1.Text;
                        result.Status = comboBox2.Text;
                        result.Deadline = dateTimePicker1.Value;
                        result.Progress = int.Parse(textBox5.Text);
                        result.Comment = textBox6.Text;

                        using (var context1 = new TaskManagerContext())
                        {
                            try
                            {
                                var t = context1.Ptes.SingleOrDefault(t => t.Tid == taskid && t.Pid == projectid);
                                if (t != null)
                                {
                                    t.Empid = int.Parse(comboBox3.SelectedValue.ToString());
                                    t.Pid = int.Parse(textBox2.Text);
                                    context1.SaveChanges();
                                }
                                else
                                {
                                    var pte = new Models.Pte();
                                    var task = context1.Tasks.SingleOrDefault(s => s.TaskTitle == textBox3.Text);
                                    if (task != null)
                                    {
                                        pte.Empid = int.Parse(comboBox3.SelectedValue.ToString());
                                        pte.Pid = int.Parse(textBox2.Text);
                                        pte.Tid = task.Tid;
                                        context1.Ptes.Add(pte);
                                        context1.SaveChanges();
                                    }
                       
                                }
                            }

                            catch (Exception ex)
                            {
                                MessageBox.Show("something went wrong");
                            }
                        }
                        db.SaveChanges();
                        button2_Click(sender, e);
                        Manage_task mt = new Manage_task();
                        mt.Show();
                        this.Close();
                        MessageBox.Show("Task Updated Successfully...");
                    }
                }
            }
        }

        private void Task_details_Load(object sender, EventArgs e)
        {
            //Fetch the records from Table using Entity Framework.
            TaskManagerContext entities = new TaskManagerContext();

            List<Employee> customers = (from Employee in entities.Employees
                                        select Employee).Take(10).ToList();

            //Insert the Default Item to List.
            customers.Insert(0, new Employee
            {
                Name = "Please select"
            });

            //Assign Entity as DataSource.
            comboBox3.DataSource = customers;
            comboBox3.DisplayMember = "name";
            comboBox3.ValueMember = "Empid";
        }
    }
}
