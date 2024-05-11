using cuoiky.ClassDAO;
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
    public partial class UCFavoriteCV : UserControl
    {
        FavoriteCV cv;
        public UCFavoriteCV()
        {
            InitializeComponent();
        }
        public UCFavoriteCV(FavoriteCV cv)
        {
            this.cv = cv;
            InitializeComponent();
            label1.Text = cv.Hoten;
            label2.Text = cv.Ngayghim;
            Usernamer = cv.Usernamer;
            Usernamee = cv.Usernamee;
            guna2PictureBox1.Image = cv.Img;

        }
        ////dki su kien click btn xem cv
        //public event EventHandler BtnViewCVClicked;
        ////btn xem cv chuyen huong trong ucrecruiter
        //private void guna2Button1_Click(object sender, EventArgs e)
        //{
        //    BtnViewCVClicked?.Invoke(this, EventArgs.Empty); 
        //}
        ////dki su kien click btn xoa 
        //public event EventHandler BtnDeleteClicked;
        ////btn xoa chuyen huong trong ucrecruitter
        //private void guna2Button4_Click(object sender, EventArgs e)
        //{
        //    BtnDeleteClicked?.Invoke(this, EventArgs.Empty);   
        //}
        public string Usernamer { get; set; }   
        public string Usernamee { get; set; }
        //dki su kien click btn xoa 
        public event EventHandler BtnDeleteClicked;
        //btn xoa chuyen huong trong ucrecruitter
        private void iconButton2_Click(object sender, EventArgs e)
        {
            BtnDeleteClicked?.Invoke(this, EventArgs.Empty);
        }
        //dki su kien click btn xem cv
        public event EventHandler BtnViewCVClicked;
        //btn xem cv chuyen huong trong ucrecruiter
        private void iconButton3_Click(object sender, EventArgs e)
        {
            BtnViewCVClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
