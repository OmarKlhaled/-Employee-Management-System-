using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EFLab3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ID = int.Parse(comboBox1.Text);
            Model1 Ent = new Model1();
            Department Dept = (from d in Ent.Departments
                               where d.ID == ID
                               select d).First();
            textBox1.Text = Dept.ID.ToString();
            textBox2.Text = Dept.Name;
            comboBox2.Items.Clear();
            foreach (Employee emp in Dept.Employees)
            {
                comboBox2.Items.Add(emp.ID);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Model1 Ent = new Model1();
            foreach(Department d in Ent.Departments)
            {
                comboBox1.Items.Add(d.ID.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                Department dept = new Department();
                dept.ID = int.Parse(textBox1.Text);
                dept.Name = textBox2.Text;
                Model1 Ent = new Model1();
                Department dpt = Ent.Departments.Find(dept.ID);
                if (dpt == null)
                {
                    Ent.Departments.Add(dept);
                    Ent.SaveChanges();
                    comboBox1.Items.Add(dept.ID);
                    MessageBox.Show("Item Added");
                }
                else
                {
                    MessageBox.Show("Department is available!");
                }
                textBox1.Text = textBox2.Text = "";

            }
            else
            {
                MessageBox.Show("Empty Data!");
            }
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(textBox1.Text);
            Model1 Ent = new Model1();
            var Dept = (from d in Ent.Departments
                        where d.ID == ID
                        select d).First();
            if (Dept != null)
            {
                Dept.Name = textBox2.Text;
                Ent.SaveChanges();
                MessageBox.Show("Department name is changed.");
            }
            else
            {
                MessageBox.Show("Invalid ID!");
            }
            textBox1.Text = textBox2.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(textBox1.Text);
            Model1 Ent = new Model1();
            var Dept = from d in Ent.Departments
                       where d.ID == ID
                       select d;
            var emp = from em in Ent.Employees
                      where em.DeptID == ID
                      select em;
            int count = 0;
            foreach (var dpt in Dept)
            {
                Ent.Departments.Remove(dpt);
                comboBox1.Items.Remove(dpt.ID);
                count++;
            }
            foreach (var emm in emp)
            {
                Ent.Employees.Remove(emm);
                comboBox2.Items.Remove(emm.ID);
            }

            if (count > 0)
            {
                Ent.SaveChanges();
                MessageBox.Show(count + " Department Removed.");
            }
            else
            {
                MessageBox.Show("Department Doesn't Exist!");
            }
            textBox1.Text = textBox2.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Department dept = new Department();
            //dept.ID = int.Parse(textBox1.Text);
            Employee emp = new Employee();
            emp.ID = int.Parse(textBox4.Text);
            emp.Name = textBox3.Text;
            emp.DeptID = int.Parse(textBox1.Text);
            Model1 Ent = new Model1();
            Ent.Employees.Add(emp);
            comboBox2.Items.Add(emp.ID);
            Ent.SaveChanges();
            textBox3.Text = textBox4.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(textBox4.Text);
            Model1 Ent = new Model1();
            var emp = (from em in Ent.Employees
                       where em.ID == ID
                       select em).First();
            if (emp != null)
            {
                emp.Name = textBox3.Text;
                Ent.SaveChanges();
                MessageBox.Show("Employee name is changed.");
            }
            else
            {
                MessageBox.Show("Invalid ID!");
            }
            textBox4.Text = textBox3.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string str = textBox3.Text;
            Model1 Ent = new Model1();
            var emp = from em in Ent.Employees
                      where em.Name == str
                      select em;
            int count = 0;
            foreach (var emm in emp)
            {
                Ent.Employees.Remove(emm);
                comboBox2.Items.Remove(emm.ID);
                count++;
            }
            if (count > 0)
            {
                Ent.SaveChanges();
                MessageBox.Show(count + " Employee Removed.");
            }
            else
            {
                MessageBox.Show("Employee Doesn't Exist!");
            }
            textBox3.Text = textBox4.Text = "";
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ID = int.Parse(comboBox2.Text);
            Model1 Ent = new Model1();
            Employee Emp = (from em in Ent.Employees
                            where em.ID == ID
                            select em).First();
            textBox4.Text = Emp.ID.ToString();
            textBox3.Text = Emp.Name;
        }
    }
}
