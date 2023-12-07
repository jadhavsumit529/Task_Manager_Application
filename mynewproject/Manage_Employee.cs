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
    public partial class Manage_Employee : Form
    {
        public static Manage_Employee instance;
        public Manage_Employee()
        {
            InitializeComponent();
            instance = this;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Admin_welcome aw = new Admin_welcome();
            aw.Show();
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Manage_Employee_Load(object sender, EventArgs e)
        {
            using (TaskManagerContext context = new TaskManagerContext())
            {
                dataGridView1.DataSource = context.Employees.ToList();
                dataGridView1.Columns.Remove("Password");
                //dataGridView1.Columns.Remove("Designation");
                //dataGridView1.Columns.Remove("Gender");
                dataGridView1.Columns.Remove("ptes");
            }
        }

        private void button1_Click(object sender, EventArgs e, Employee Employee)
        {
            using (var context = new TaskManagerContext())
            {
                try
                {
                    //int empid = int.Parse(textBox1.Text);
                    var Emp = context.Employees.Single(p => p.Empid == int.Parse(textBox1.Text));
                    if (Emp != null)
                    {
                        Employee_details ed = new Employee_details();
                        ed.Show();
                        this.Visible = false;
                        //ed.id = int.Parse(textBox1.Text);
                        ed.tb2.Text = Emp.Name;
                        ed.tb3.Text = Emp.Email;
                        ed.tb5.Text = Emp.Phone.ToString();
                        ed.tb6.Text = Emp.Designation;
                        ed.tb7.Text = Emp.Address;
                        String radiobutton = Emp.Gender;
                        if (radiobutton == "Male")
                            ed.rb1.Checked = true;
                        else if (radiobutton == "Female")
                            ed.rb2.Checked = true;
                        else if (radiobutton == "Other")
                            ed.rb3.Checked = true;
                        ed.empid = Emp.Empid;
                    }

                }
                catch
                {
                    MessageBox.Show("Cannot Fetch Data with Given Employee id");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (TaskManagerContext context = new TaskManagerContext())
            {
                try
                {
                    context.Remove(context.Employees.SingleOrDefault(b => b.Empid == int.Parse(textBox1.Text)));
                    context.SaveChanges();
                    MessageBox.Show("Employee Deleted successfully..");
                    Manage_Employee_Load(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Something Went Wrong on server..");
                }
            }
        }
    }
}
