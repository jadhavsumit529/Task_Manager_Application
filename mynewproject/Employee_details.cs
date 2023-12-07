using Microsoft.Identity.Client;
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
    public partial class Employee_details : Form
    {
        String gender;
        public System.Windows.Forms.TextBox tb2;
        public System.Windows.Forms.TextBox tb3;
        public System.Windows.Forms.TextBox tb4;
        public System.Windows.Forms.TextBox tb5;
        public System.Windows.Forms.TextBox tb6;
        public System.Windows.Forms.TextBox tb7;
        public RadioButton rb1;
        public RadioButton rb2;
        public RadioButton rb3;
        public int? empid;
        public Employee_details()
        {
            InitializeComponent();
            tb2 = textBox2;
            tb3 = textBox3;
            tb4 = textBox4;
            tb5 = textBox5;
            tb6 = textBox6;
            tb7 = textBox7;
            rb1 = new RadioButton();
            rb2 = new RadioButton();
            rb3 = new RadioButton();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Admin_welcome aw = new Admin_welcome();
            aw.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            radioButton1.Checked = true;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //inserting new data
            if (empid == null)
            {
                Employee emp = new Employee();
                emp.Name = textBox2.Text;
                emp.Email = textBox3.Text;
                emp.Password = textBox4.Text;
                emp.Phone = long.Parse(textBox5.Text);
                emp.Designation = textBox6.Text;
                emp.Address = textBox7.Text;
                if (radioButton1.Checked == true)
                    this.gender = "Male";
                else if (radioButton2.Checked == true)
                    this.gender = "Female";
                else
                {
                    this.gender = "Other";
                }
                emp.Gender = gender;

                var context = new TaskManagerContext();
                context.Employees.Add(emp);
                context.SaveChanges();
                button2_Click(sender, e);
                MessageBox.Show("Employee added Successfully ");
            }
            //updating value if id is present already 
            if (empid != null)
            {
                using (var db = new TaskManagerContext())
                {
                    var result = db.Employees.SingleOrDefault(b => b.Empid == empid);
                    if (result != null)
                    {
                        result.Name = textBox2.Text;
                        result.Email = textBox3.Text;
                        //result.Password = textBox4.Text;
                        result.Phone = long.Parse(textBox5.Text);
                        result.Designation = textBox6.Text;
                        result.Address = textBox7.Text;
                        if (radioButton1.Checked == true)
                            this.gender = "Male";
                        else if (radioButton2.Checked == true)
                            this.gender = "Female";
                        else
                        {
                            this.gender = "Other";
                        }
                        result.Gender = gender;
                        db.SaveChanges();
                        button2_Click(sender,e);
                        Manage_Employee me = new Manage_Employee();
                        me.Show();
                        this.Close();
                        empid = null;
                        MessageBox.Show("Existing Employee Details updated succssfully...");
                    }
                }
            }
            
        }
    }
}
