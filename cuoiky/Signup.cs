using cuoiky.BLL;
using cuoiky.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace cuoiky
{
    public partial class Signup : Form
    {       
        public Signup()
        {
            InitializeComponent();
        }       
        //Button Dangki
        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text)
                && !string.IsNullOrEmpty(textBox3.Text))
            {
                if (IsUsernameExist(textBox1.Text))
                {
                    MessageBox.Show("Ten dang nhap da ton tai.");
                }
                else
                {
                    string username = textBox1.Text;
                    string role = "";
                    if (textBox2.Text == textBox3.Text && checkBox3.Checked && !checkBox1.Checked)
                    {
                        //string username = textBox1.Text;
                        role = "Employee";                       
                        Profile addProfile = new Profile();
                        addProfile.Username = username;
                        addProfile.isAddingNewProfile = true;
                        addProfile.ShowDialog();
                        if (addProfile.IsProfileCompleted)
                        {
                            //string username = textBox1.Text;
                            string matkhau = textBox2.Text;
                            ClassDAL dal = new ClassDAL();
                            string query = string.Format("Insert into Login(Username, [Mat khau], [As]) values ('{0}', '{1}', '{2}')", username, matkhau, role);
                            dal.ThucThi(query);
                        };
                    }
                    else if (textBox2.Text == textBox3.Text && !checkBox3.Checked && checkBox1.Checked)
                    {
                        role = "Recruiter";
                        AddCty addCty = new AddCty();
                        addCty.Username = username;
                        addCty.isAddingNewCompany = true;
                        addCty.ShowDialog();
                        if (addCty.IsCompanyCompleted)
                        {
                            string matkhau = textBox2.Text;
                            ClassDAL dal = new ClassDAL();
                            string query = string.Format("Insert into Login(Username, [Mat khau], [As]) values ('{0}', '{1}', '{2}')", username, matkhau, role);
                            dal.ThucThi(query);
                        };
                    }
                    else
                    {
                        MessageBox.Show("Error.");
                    }

                }
            }
            else
            {
                MessageBox.Show("Vui long nhap du thong tin");
            }
        }      
        //kiem tra username co ton tai 
        private bool IsUsernameExist(string username) 
        {
            ClassDAL dal = new ClassDAL();
            string query = string.Format("SELECT COUNT(*) FROM Login WHERE Username = '{0}'", username);
           int count = dal.GetCount(query);
            return count > 0;           
        }
    

        //Button exit
        private void iconButton1_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            lg.Show();
            this.Close();
        }


    }
}
