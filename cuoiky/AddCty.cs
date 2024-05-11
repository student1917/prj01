using cuoiky.BLL;
using cuoiky.DAL;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace cuoiky
{
    public partial class AddCty : Form
    {
        Company company;
        string username;
        public AddCty()
        {
            InitializeComponent();
            guna2Button1.Click += UploadButton_Click;
            guna2Button3.Click += UploadButton_Click;
        }
        //
        public AddCty(Company company)
        {
            this.company = company;
            InitializeComponent();
            guna2TextBox1.Text = company.Tencongty;
            guna2TextBox2.Text = company.Masothue;
            guna2PictureBox1.Image = company.Img;
            guna2TextBox3.Text = company.Chinhanh;
            guna2TextBox4.Text = company.Nguoidungdau;
            guna2PictureBox2.Image = company.Gpkd;
            guna2TextBox5.Text = company.Trusochinh;
            guna2TextBox10.Text = company.Gioithieucty;
            this.username = company.Username;
            guna2Button1.Click += UploadButton_Click;
            guna2Button3.Click += UploadButton_Click;
        }
        //Button Upload
        private void UploadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog opendlg = new OpenFileDialog();
            if (opendlg.ShowDialog() == DialogResult.OK)
            {
                if (sender == guna2Button1)
                {
                    guna2PictureBox1.Image = Image.FromFile(opendlg.FileName);
                }
                else if (sender == guna2Button3)
                {
                    guna2PictureBox2.Image = Image.FromFile(opendlg.FileName);
                }
            }
        }
        //Do date Company de update
        public void LoadCompany(string username)
        {
            ClassDAL dal = new ClassDAL();
            string query = "Select * from Company where [Username] = '" + username + "' ";
            Company company = dal.GetCompany(query);
            AddCty addCty = new AddCty(company);
            addCty.ShowDialog();
        }
        public string Username { get; set; }
        public bool isAddingNewCompany { get; set; }
        public bool IsCompanyCompleted { get; set; }
        //Button Save
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            ClassBLL objbll = new ClassBLL();
            Company cmp = new Company(guna2PictureBox1.Image, guna2TextBox1.Text, guna2TextBox2.Text, guna2TextBox4.Text, guna2PictureBox2.Image, guna2TextBox5.Text, guna2TextBox3.Text, guna2TextBox10.Text, username);
            //Add
            if (isAddingNewCompany)
            {
                //ClassBLL objbll = new ClassBLL();
                if (objbll.SaveCompany(cmp))
                {
                    MessageBox.Show("Success!");
                    IsCompanyCompleted = true;
                    //ucProfile.Instance(guna2TextBox2.Text, false).RefreshUserProfile(guna2TextBox2.Text);
                }
                else
                {
                    MessageBox.Show("Error!");
                }
            }
            //Update
            if (!isAddingNewCompany)
            {
                //ClassBLL objbll = new ClassBLL();
                if (objbll.UpdateCompany(cmp))
                {
                    MessageBox.Show("Success!");
                    IsCompanyCompleted = true;
                    ucProfile.Instance(guna2TextBox2.Text, false).RefreshUserProfile(guna2TextBox2.Text);
                }
                else
                {
                    MessageBox.Show("Error!");
                }
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
       
    }
}
