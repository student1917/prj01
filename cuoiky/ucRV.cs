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
    public partial class ucRV : UserControl
    {
        public ucRV()
        {
            InitializeComponent();
        }
        //dang ki su kien btn v (pass)
        public event EventHandler VClicked;
        //btn V chuyen huong uclistcv
        private void iconButton2_Click(object sender, EventArgs e)
        {
            VClicked?.Invoke(this, EventArgs.Empty);
        }
        //dang ki su kien btn x (reject)
        public event EventHandler XClicked;
        //btn x chuyen huong uclistcv
        private void iconButton1_Click(object sender, EventArgs e)
        {
            XClicked?.Invoke(this, EventArgs.Empty);
        }
        //dang ki su kien btn xem cv
        public event EventHandler ViewCVButtonClicked;
        //btn xem cv chuyen huong uclistcv
        private void iconButton3_Click(object sender, EventArgs e)
        {
            ViewCVButtonClicked?.Invoke(this, EventArgs.Empty);
        }

        public string Username { get; set; }
        public string Tenungvien
        {
            get { return label1.Text; }
            set { label1.Text = value; }
        }
        public string Ngaygui
        {
            get { return label2.Text; }
            set { label2.Text = value; }
        }
        public Image Img
        {
            get { return guna2PictureBox1.Image; }
            set { guna2PictureBox1.Image = value; }
        }

        private void ucRV_Load(object sender, EventArgs e)
        {

        }
       
    }
}
