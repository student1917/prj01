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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace cuoiky
{
    public partial class ucJobDetail : UserControl
    {
        Job job;

        private static ucJobDetail _instance;
        public static ucJobDetail Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                    _instance = new ucJobDetail();
                return _instance;
            }
            
        }
        public ucJobDetail()
        {
            InitializeComponent();
        }
        public ucJobDetail(Job job)
        {
            this.job = job;
            InitializeComponent();
            guna2PictureBox1.Image = job.Img;
            label1.Text = job.Tencongviec;
            linkLabel1.Text = job.Tencongty;
            label3.Text = job.Mucluong.ToString();
            label4.Text = job.Diadiem;
            label10.Text = job.Nganhnghe;
            label11.Text = job.Chucvu;
            label12.Text = job.Loaihinh;
            label13.Text = job.Chitiet;
            label14.Text = job.Gioithieucty;
            label16.Text = job.Ngaydang;
            label18.Text = job.Macv;
            this.Usernamerecruiter = job.Usernamerecruiter;
            DetermineOwnership();
        }
        //xac dinh owner
        private void DetermineOwnership()
        {
            ClassDAL dal = new ClassDAL();
            string currentusername = dal.GetUsername();
            if (currentusername == Usernamerecruiter)
                isOwner = true;
            else if (currentusername != Usernamerecruiter)
                isOwner = false;
            if (isOwner)
            {
                iconButton2.Enabled = true;
                iconButton2.Visible = true;
            }
            else
            {
                iconButton2.Enabled = false;
                iconButton2.Visible = false;
            }
        }

        public string Usernamerecruiter { get; set; }
        //Button exit (chuyen huong trong ucfindjob)
        public event EventHandler ButtonClicked;
        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ButtonClicked?.Invoke(this, EventArgs.Empty);
        }
        //
        public bool isOwner { get; set; }
        //Button sua job
        private void iconButton2_Click(object sender, EventArgs e)
        {
            //quyen truy cap 
            
            AddJob addjob = new AddJob();
            addjob.isAddingNewJob = false;
            addjob.Username = Usernamerecruiter;
            addjob.LoadJob(label18.Text);           
            
        }
        //dki su kkien click linklabel
        public event EventHandler LinkLabelClicked;
        //link cty (chuyen huong trong ucfindjob)
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabelClicked?.Invoke(this, EventArgs.Empty);
        }

       
    }
}
