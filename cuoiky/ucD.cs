using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cuoiky
{
    public partial class ucD : UserControl
    {
        public ucD()
        {
            InitializeComponent();
        }
        //dki su kien btn xem cv
        public event EventHandler ViewCVDButtonClicked;
        //btn xem cv
        private void iconButton3_Click(object sender, EventArgs e)
        {
            ViewCVDButtonClicked?.Invoke(this, EventArgs.Empty);
        }
        public Image Img
        {
            get { return guna2PictureBox1.Image; }
            set { guna2PictureBox1.Image = value; }
        }
        public string Hoten
        {
            get { return label1.Text; }
            set { label1.Text = value; }
        }
        public string Henlich { get; set; }
        public string Ngayduyet
        {
            get { return label2.Text; }
            set { label2.Text = value; }
        }
        public string Ngaygui { get; set; }
        //public string Ngayduyet { get; set; }

        public string Macv { get; set; }          
        public string Owner { get; set; }
        public string Username { get;set; }
        //dki su kien gui thu
        public event EventHandler SendMailClicked;
        //btn gui thu (chuyen huong trong uc list cv)
        private void iconButton1_Click(object sender, EventArgs e)
        {
            SendMailClicked?.Invoke(this, EventArgs.Empty); 
        }
        public event EventHandler DeleteCVClicked;
        //btnxoa (chuyen huong uclistcv)
        private void iconButton2_Click(object sender, EventArgs e)
        {
            DeleteCVClicked?.Invoke(this, EventArgs.Empty); 
        }
    }
}
