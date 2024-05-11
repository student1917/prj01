using cuoiky.BLL;
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
    public partial class CreatePost : Form
    {
        Post p;
        ClassDAL dal = new ClassDAL();
        public CreatePost()
        {
            InitializeComponent();
        }       
        //
        public string Username
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }
        //button up bai
        private void button1_Click(object sender, EventArgs e)
        {
            ClassDAL dal = new ClassDAL();
            Image img = dal.GetImage("Select [Anh] from Profile where Username = '" + Username + "'");
            Post p = new Post(img, Username, textBox2.Text, DateTime.Now.ToString());
            ClassBLL objbll = new ClassBLL();
            if (objbll.SavePost(p))
            {
                MessageBox.Show("Success!");
                UCHome.Instance().LoadList();
                UCNotification.Instance().LoadPost();
                this.Close();
            }
            else
            {
                MessageBox.Show("Error!");
            }
        }
        //button exit
        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
