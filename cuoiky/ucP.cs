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
    public partial class ucP : UserControl
    {
        PostedJob pj;
        public ucP()
        {
            InitializeComponent();
        }
        public ucP(PostedJob pj)
        {
            InitializeComponent(); 
            this.pj = pj;
            guna2HtmlLabel1.Text = pj.Tencongviec;
            label2.Text = pj.Sluong.ToString();
            label3.Text = pj.Trangthai;
            this.Macv = pj.Macv;
            guna2PictureBox1.Image = pj.Img;
        }

        public event EventHandler DetailButtonClicked;
        public event EventHandler ListCVClicked;
        public event EventHandler StopRecruimentButtonClicked;       
        public event EventHandler DeleteBtnClicked;
        //btn xoa (chuyen huong trong ucrecruiter)
        private void iconButton1_Click(object sender, EventArgs e)
        {
            DeleteBtnClicked?.Invoke(this, EventArgs.Empty);
        }
        //btn list cv chuyen huong trong ucrecruiter
        private void iconButton2_Click(object sender, EventArgs e)
        {
            ListCVClicked?.Invoke(this, EventArgs.Empty);
        }
        //btn dong mo job chuyen huong trong ucrecruiter
        private void iconButton3_Click(object sender, EventArgs e)
        {
            StopRecruimentButtonClicked?.Invoke(this, EventArgs.Empty);
        }
        public string Tencongviec
        {
            get { return guna2HtmlLabel1.Text; }
            set { guna2HtmlLabel1.Text = value; }
        }
        public int Sluong
        {
            get { return int.Parse(label2.Text); }
            set { label2.Text = value.ToString(); }
        }
        public string Trangthai
        {
            get { return label3.Text; }
            set { label3.Text = value; }
        }
        public Image Img
        {
            get { return guna2PictureBox1.Image; }
            set { guna2PictureBox1.Image = value; }
        }
        public string Macv { get; set; }
       
    }
}
