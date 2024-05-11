using cuoiky.ClassDAO;
using cuoiky.DAL;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cuoiky
{
    public partial class UCHome_List : UserControl
    {
       // Post p;
        public Post p { get; set; }
        public UCHome_List()
        {
            InitializeComponent();
         
        }
        public UCHome_List(Post p)
        {
            InitializeComponent();
            this.p = p;
            label1.Text = p.Username;
            label2.Text = p.Ngaydang;
            guna2TextBox1.Text = p.Noidung;
            guna2CirclePictureBox1.Image = p.Img;
            DetermineUserRole();
            DisplayMode();

        }
        private void DetermineUserRole()
        {
            ClassDAL dal = new ClassDAL();
            string currentUsername = dal.GetUsername();
            string userRole = dal.GetUserRole(currentUsername);
            if (userRole == "Recruiter")
            {
                iconButton1.Visible = true;
                iconButton1.Enabled = true;
            }
            else
            {
                iconButton1.Visible = false;
                iconButton1.Enabled = false;   
            }
        }
        //public string Username
        //{
        //    get { return label1.Text; }
        //    set { label1.Text = value; }
        //}
        public string Username { get; set; }
        public string Noidung { get; set; }
        //public DateTime Ngaydang { get; set; }
        public string Ngaydang { get; set; }

        //dki su kien btn xem cv
        public event EventHandler ButtonCVClicked;
        //dki su kien btn ghim
        public event EventHandler ButtonPinClicked;
        //btn ghim chuyen huong uc home
        private void iconButton1_Click(object sender, EventArgs e)
        {
            ButtonPinClicked?.Invoke(this, EventArgs.Empty);
        }
        //btn xem cv chuyen huong uc home 
        private void iconButton2_Click(object sender, EventArgs e)
        {
            ButtonCVClicked?.Invoke(this, EventArgs.Empty);
        }
        private bool isNotification;

        public bool IsNotification
        {
            get { return isNotification; }
            set
            {
                isNotification = value;
                DisplayMode(); // Cập nhật trạng thái của control khi thuộc tính thay đổi
            }
        }
        //
        private void DisplayMode()
        {
            if (isNotification)
            {
                iconButton2.Visible = false;
                iconButton3.Visible = true;
                iconButton3.Enabled = true;
                iconButton3.Location = new Point(912, 3);
            }        
            else
            {                 
                iconButton2.Visible = true;
            }
        }
        public event EventHandler BtnDeleteClicked;
        

        //btn xoa bai post (chuyen huong ucthongbao)
        private void iconButton3_Click(object sender, EventArgs e)
        {
            BtnDeleteClicked?.Invoke(this, EventArgs.Empty);    
        }

       
    }
}
