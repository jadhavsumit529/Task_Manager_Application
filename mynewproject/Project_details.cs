using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
using static Azure.Core.HttpHeader;

namespace mynewproject
{
    public partial class Project_details : Form
    {
        public static Project_details instance;
        public TextBox tb1;
        public TextBox tb2;
        public DateTimePicker dtp1;
        public DateTimePicker dtp2;
        public ComboBox cb1;
        public int? id;
        public Project_details()
        {
            InitializeComponent();
            instance = this;
            //tb1 = textBox1;
            tb2 = textBox2;
            dtp1 = dateTimePicker1;
            dtp2 = dateTimePicker2;
            cb1 = comboBox1;
        }

        private void label4_Click(object sender, EventArgs e)
        {

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
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            comboBox1.Text = "New";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //inserting new data
            if (id == null)
            {
                Project p = new Project();
                p.Name = textBox2.Text;
                p.StartDate = dateTimePicker1.Value;
                p.Deadline = dateTimePicker2.Value;
                p.Status = comboBox1.Text;

                var context = new TaskManagerContext();
                context.Projects.Add(p);
                context.SaveChanges();
                button2_Click(sender, e);
                MessageBox.Show("Project Created Successfully ");
            }
            //updating value if id is present already 
            if (id != null)
            {
                using (var db = new TaskManagerContext())
                {
                    var result = db.Projects.SingleOrDefault(b => b.Pid == id);
                    if (result != null)
                    {
                        result.Name = textBox2.Text;
                        result.StartDate = dateTimePicker1.Value;
                        result.Deadline = dateTimePicker2.Value;
                        result.Status = comboBox1.Text; ;
                        MessageBox.Show("Existing project project updated succssfully...");
                        db.SaveChanges();
                        button2_Click(sender, e);
                        button3_Click(sender, e);
                        id = null;
                    }
                }
            }
            
        }
    }
}
