using System.Configuration;
using System.Data.SqlClient;
using System.Runtime.Versioning;
using System.Data.SqlTypes;
using mynewproject.Models;

namespace mynewproject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var context = new TaskManagerContext())
            {
                try
                {
                    var Emp = context.Employees.Single(e => e.Email == textBox1.Text && e.Password == textBox2.Text && e.Designation != "Admin");
                    if (Emp != null)
                    {
                        Employee_welcome ew = new Employee_welcome();
                        ew.email = textBox1.Text;
                        ew.pass = textBox2.Text; 
                        ew.Show();
                        this.Visible = false;
                    }
                }
                catch
                {
                    MessageBox.Show("Please Enter valid Email and Password.");
                    textBox1.Text = "";
                    textBox2.Text = "";

                    textBox1.Focus();

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";

            textBox1.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Home_page hp = new Home_page();
            hp.Show();
            this.Visible = false;
        }
    }
}