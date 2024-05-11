using cuoiky.BLL;
using cuoiky.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using System.Windows.Media.TextFormatting;



namespace cuoiky
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();            
        }
        //tim viec
        private void iconButton2_Click(object sender, EventArgs e)
        {
            if (!flowLayoutPanel1.Controls.Contains(ucFindJob.Instance))
            {
                flowLayoutPanel1.Controls.Clear();
                flowLayoutPanel1.Controls.Add(ucFindJob.Instance);
                //ucFindJob.Instance.Dock = DockStyle.Fill;
                ucFindJob.Instance.BringToFront();
                this.Username = label1.Text;
            }
            else
                ucFindJob.Instance.BringToFront();
        }
        //btn exit
        private void iconButton5_Click(object sender, EventArgs e)
        {            
            Close();
            Login login = new Login();
            login.Show();           
        }
        public string Username
        {
            get { return label1.Text; }
            set { label1.Text = value; }
        }
        public Image Img
        {
            get { return guna2CirclePictureBox1.Image; }
            set { guna2CirclePictureBox1.Image = value; }
        }
        
        //profile
        private void iconButton4_Click(object sender, EventArgs e)
        {            
          
            ClassDAL dal = new ClassDAL();
            string userRole = dal.GetUserRole(label1.Text);
            //string userRole = GetUserRole(label1.Text);
            if (userRole == "Employee")
            {
                if (!flowLayoutPanel1.Controls.Contains(ucProfile.Instance(Username, false)))
                {                    
                    this.Username = label1.Text;                    
                    //ucProfile pf = new ucProfile(Username,false);
                    flowLayoutPanel1.Controls.Clear();
                    flowLayoutPanel1.Controls.Add(ucProfile.Instance(Username, false));                
                    ucProfile.Instance(Username, false).xbtnclicked();
                    ucProfile.Instance(Username, false).BringToFront();
                }
                else
                    ucProfile.Instance(Username, false).BringToFront();
            }

            else
            {
                MessageBox.Show("Day la chuc nang danh cho nguoi tim viec");
            }

        }

        //nha tuyen dung
        private void iconButton3_Click(object sender, EventArgs e)
        {
            ClassDAL dal = new ClassDAL();
            string userRole = dal.GetUserRole(label1.Text);
            if (userRole == "Recruiter")
            {
                if (!flowLayoutPanel1.Controls.Contains(ucRecruiter.Instance(Username)))
                {
                    this.Username = label1.Text;
                    //ucRecruiter.Username = label1.Text;
                    //ucRecruiter ucR = new ucRecruiter(Username);
                    flowLayoutPanel1.Controls.Clear();
                    flowLayoutPanel1.Controls.Add(ucRecruiter.Instance(Username));                   
                    //ucFindJob.Instance.Dock = DockStyle.Fill;
                    ucRecruiter.Instance(Username).BringToFront();
                }
                else
                    ucRecruiter.Instance(Username).BringToFront();
            }
            else
            {
                MessageBox.Show("Day la chuc nang danh cho nha tuyen dung");
            }
        }
        //Home
        private void iconButton1_Click(object sender, EventArgs e)
        {
            if (!flowLayoutPanel1.Controls.Contains(UCHome.Instance()))
            {
                flowLayoutPanel1.Controls.Clear();              
                flowLayoutPanel1.Controls.Add(UCHome.Instance());               
                UCHome.Instance().BringToFront();
                this.Username = label1.Text;
            }
            else
            {                
                UCHome.Instance().BringToFront();
            }
        }
        //btn thong bao danh cho emloyee
        private void iconButton6_Click(object sender, EventArgs e)
        {
            ClassDAL dal = new ClassDAL();
            string userRole = dal.GetUserRole(label1.Text);
            if (userRole == "Employee")
            {
                if (!flowLayoutPanel1.Controls.Contains(UCNotification.Instance()))
                {                    
                    flowLayoutPanel1.Controls.Clear();
                    flowLayoutPanel1.Controls.Add(UCNotification.Instance());
                    UCNotification.Instance().BringToFront();
                }
                else
                    UCNotification.Instance().BringToFront();
            }
            else
            {
                MessageBox.Show("Day la chuc nang danh cho nguoi tim viec");
            }

        }
        private void DisplayMode()
        {
            ClassDAL dal = new ClassDAL();
            
            string userRole = dal.GetUserRole(Username);
            if (userRole == "Recruiter")
            {
                iconButton4.Visible = false;
                iconButton4.Enabled = false;    
                iconButton6.Visible = false;
                iconButton6.Enabled = false;
                iconButton3.Visible = true;
                iconButton3.Enabled = true;
            }
            else
            {
                iconButton3.Visible = false;
                iconButton3.Enabled = false;
                iconButton4.Top = iconButton2.Bottom;
                iconButton6.Top = iconButton4.Bottom;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DisplayMode();
        }

      
    }
}
