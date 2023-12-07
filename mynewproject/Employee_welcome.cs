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

namespace mynewproject
{
    public partial class Employee_welcome : Form
    {
        public string email;
        public string pass;
        public Employee_welcome()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            view_tasks vt = new view_tasks();
            vt.email = email;
            vt.pass = pass;
            vt.Show();
            this.Close();
        }

        private void Employee_welcome_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (email != null)
            {
                using (var db = new TaskManagerContext())
                {
                    var result = db.Employees.SingleOrDefault(b => b.Email == email);
                    if (result != null)
                    {
                        result.Password = textBox1.Text;
                        pass = textBox1.Text;
                        db.SaveChanges();
                        textBox1.Clear();
                        MessageBox.Show("Password updated succssfully...");
                    }
                }
            }
        }
    }
}
