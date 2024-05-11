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
    public partial class UCBusiness : UserControl
    {
        Company company;
        string username;
        public UCBusiness()
        {
            InitializeComponent();
        }

        public UCBusiness(Company company)
        {
            InitializeComponent();
            this.company = company;
            guna2PictureBox1.Image = company.Img;
            label1.Text = company.Tencongty;
            label2.Text = company.Trusochinh;
            label9.Text = company.Nguoidungdau;
            label10.Text = company.Masothue;
            label11.Text = company.Chinhanh;
            label12.Text = company.Gioithieucty;
            guna2PictureBox2.Image = company.Gpkd;
            this.username = company.Username;
            DetermineOwnership();
        }
        //
        public int Sluong
        {
            get { return int.Parse(label3.Text); }
            set { label3.Text = value.ToString(); }
        }
        //
        public bool isOwner { get; set; }
        //
        private void DetermineOwnership()
        {
            ClassDAL dal = new ClassDAL();
            string currentusername = dal.GetUsername();
            if (currentusername == username)
                isOwner = true;
            else if (currentusername != username)
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

        //Button exit (chuyen huong trong ucRecruiter)
        public event EventHandler ButtonClicked;

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ButtonClicked?.Invoke(this, EventArgs.Empty);
        }
        //Button sua company
        private void iconButton2_Click(object sender, EventArgs e)
        {
            AddCty addCty = new AddCty();
            addCty.isAddingNewCompany = false;
            addCty.LoadCompany(username);
        }

    
    }
}
