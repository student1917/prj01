using cuoiky.BLL;
using cuoiky.ClassDAO;
using cuoiky.DAL;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cuoiky
{
    public partial class UCJobList : UserControl
    {
        Job job;
        sJob sj;
        public UCJobList()
        {
            InitializeComponent();
        }
        //
        public UCJobList(Job job)
        {
            InitializeComponent();
            this.job = job;
            guna2PictureBox1.Image = job.Img;
            label1.Text = job.Tencongviec;
            label2.Text = job.Tencongty;
            label3.Text = job.Mucluong.ToString();
            label4.Text = job.Diadiem;
            this.Macv = job.Macv;
            //this.Owner = job.Usernamerecruiter;
        }
        public UCJobList(sJob sj)
        {            
            InitializeComponent();
            this.sj = sj;
            guna2PictureBox1.Image = sj.Img;
            label1.Text = sj.Tencongviec;
            label2.Text = sj.Tencongty;
            label3.Text = sj.Mucluong.ToString();
            label4.Text = sj.Diadiem;
            this.Macv = sj.Macv;
        }
        public string Macv
        { get; set; }
        public string Username
        { get; set; }
        //public string Owner { get; set; }
        public ucJobDetail Jobdetail
        { get; set; }
        //Button ung tuyen
        private void guna2GradientTileButton1_Click(object sender, EventArgs e)
        {
            ketnoi kn = new ketnoi();
            kn.connect.Open();
            ClassDAL dal = new ClassDAL();
            DateTime ngaygui = DateTime.Now;
            string userRole = dal.GetUserRole(this.Username);
            if (userRole == "Employee")
            {
                string checkQuery = string.Format("Select count(*) from Sent where Username = '{0}' and [Ma cong viec] = '{1}' ", this.Username, this.Macv);
                SqlCommand checkcmd = new SqlCommand(checkQuery, kn.connect);
                int count = (int)checkcmd.ExecuteScalar();
                if (count > 0)
                {
                    MessageBox.Show("Ban da ung tuyen truoc do.");
                }
                else
                {
                    string query = string.Format("Insert into Sent(Username, [Ma cong viec], [Ngay gui]) Values ('{0}', '{1}', '{2}')", this.Username, this.Macv, ngaygui);
                    SqlCommand cmd = new SqlCommand(query, kn.connect);
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Ung tuyen thanh cong.");
                    };
                }
            }
            else
            {
                MessageBox.Show("Day la chuc nang danh cho nguoi tim viec");
            }
           
        }
        //khong hien thi btn ung tuyen khi xem lich su job da ung
        private bool isReadOnly { get; set; }
        public bool IsReadOnly
        {
            get { return isReadOnly; }
            set
            {
                isReadOnly = value;
                DisplayMode(); // Cập nhật trạng thái của control khi thuộc tính thay đổi
            }
        }
        private void DisplayMode()
        {
            if (IsReadOnly)
            {
                guna2GradientTileButton1.Visible = false;               
            }
        }

       
    }
}
