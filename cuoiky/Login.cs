using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using cuoiky.BLL;
using cuoiky.DAL;

namespace cuoiky
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            CheckRememberMe();
        }        
      
        //button dang nhap
        private void button1_Click(object sender, EventArgs e)
        {            
            ketnoi kn = new ketnoi();
            try
            {
                ClassBLL objbll = new ClassBLL();
                ClassDAL dal = new ClassDAL();
                string userRole = dal.GetUserRole(textBox1.Text);
                string query = "";
                if (userRole == "Employee" )
                {
                    query = "SELECT Login.*, Profile.[Anh] FROM Login INNER JOIN Profile ON Login.Username = Profile.Username WHERE Login.Username = '" +textBox1.Text+ "' and Login.[Mat khau] = '" +textBox2.Text+ "'";
                }
                else if (userRole == "Recruiter")
                {
                   query = "SELECT Login.*, Company.[Anh] FROM Login INNER JOIN Company ON Login.Username = Company.Username WHERE Login.Username = '" + textBox1.Text + "' and Login.[Mat khau] = '" + textBox2.Text + "'";
                }               
                DataTable dt = objbll.GetItems(query);
                if (dt != null && dt.Rows.Count > 0)
                {                  
                    LoginSuccess();
                    string username = textBox1.Text;                    
                    Form1 f = new Form1();
                    f.Username = username;
                   

                    if (dt.Rows[0]["Anh"] != DBNull.Value)
                    {
                        MemoryStream ms = new MemoryStream((byte[])dt.Rows[0]["Anh"]);
                        f.Img = new Bitmap(ms);
                    }
                    else
                    {
                        f.Img = Image.FromFile(@"D:\NMCNTT\WF\h2.jpg");
                    }                 

                    f.Show();
                    this.Hide();                   
                }
                else
                {
                    MessageBox.Show("Tai khoan khong hop le");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox1.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Error");
            }
            finally
            {
                kn.connect.Close();
            }
        }
        private void LoginSuccess()
        {
            string username = textBox1.Text;
            string matkhau = textBox2.Text;

            if (checkBox3.Checked)
            {
                Properties.Settings.Default.Username = username;
                Properties.Settings.Default.Password = matkhau;
                Properties.Settings.Default.RememberMe = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.Username = string.Empty;
                Properties.Settings.Default.Password = string.Empty;
                Properties.Settings.Default.RememberMe = false;
                Properties.Settings.Default.Save();
            }
        }
        private void CheckRememberMe()
        {
            if (Properties.Settings.Default.RememberMe)
            {
                string savedUsername = Properties.Settings.Default.Username;
                string savedPassword = Properties.Settings.Default.Password;
                textBox1.Text = savedUsername;
                textBox2.Text = savedPassword;
                checkBox3.Checked = true;
            }
        }
        //Dong
        private void iconButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Signup signup = new Signup();
            signup.Show();
            this.Hide();
        }
    }
}
