using cuoiky.BLL;
using cuoiky.ClassDAO;
using cuoiky.DAL;
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
    public partial class UCMail : UserControl
    {
        Mail m;
        public UCMail()
        {
            InitializeComponent();
        }

        public string Tencongty
        {
            get { return guna2HtmlLabel1.Text; }
            set {  guna2HtmlLabel1.Text = value;}
        }
        public string Tencongviec
        {
            get { return label2.Text; }
            set { label2.Text = value;} 
        }
        public Image Img
        {
            get { return guna2PictureBox1.Image; }
            set { guna2PictureBox1.Image = value;}
        }
        public string Macv { get;set; }
        //button xem mail 
        private void iconButton2_Click(object sender, EventArgs e)
        {
            ClassDAL dal = new ClassDAL();
            ClassBLL objbll = new ClassBLL();
            string username = dal.GetUsername();          
            SendMail sm = new SendMail();
            sm.UserRole = "Employee";
            sm.IsReadOnly = true;
            sm.Macv = Macv;
            sm.LoadMail(username, Macv);            
            sm.Show();
        }
        


    }
}
