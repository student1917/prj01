using cuoiky.BLL;
using cuoiky.DAL;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace cuoiky
{
    public partial class AddJob : Form
    {
        string username = ((Form1)Form1.ActiveForm).Username;
        Job job;
        public AddJob()
        {
            InitializeComponent();
        }

       public AddJob (Job job)
       {
            InitializeComponent();
            this.job = job;
            guna2TextBox1.Text = job.Tencongty;
            guna2PictureBox1.Image = job.Img;
            guna2TextBox2.Text = job.Tencongviec;
            guna2TextBox3.Text = job.Nganhnghe;
            guna2CheckBox1.Checked = (job.Trangthai == "Open");
            guna2CheckBox2.Checked = (job.Trangthai == "Closed");
            guna2TextBox5.Text = job.Chucvu;
            guna2TextBox6.Text = job.Loaihinh;
            guna2TextBox7.Text = job.Mucluong.ToString();
            guna2TextBox8.Text = job.Diadiem;
            guna2TextBox9.Text = job.Chitiet;
            guna2TextBox10.Text = job.Gioithieucty;
            guna2TextBox11.Text = job.Macv;
            
            username = job.Usernamerecruiter;
            DateTime ngaydang = DateTime.Parse(job.Ngaydang);
       }
      
        //do data job ra de update
        public void LoadJob(string Macv)
        {
            ketnoi kn = new ketnoi();
            kn.connect.Open();
            ClassBLL objbll = new ClassBLL();
            string query = string.Format("SELECT j.*, c.[Anh] FROM Job j inner join Company c on j.Username = c. Username WHERE [Username recruiter] = '{0}'", username);
            DataTable dt = objbll.GetItems(query);
            DataRow[] rows = dt.Select("[Ma cong viec] = '" +Macv+ "'");
            if (rows.Length > 0)
            {
                DataRow row = rows[0];
                Job job = new Job(
                          new Bitmap(new MemoryStream((byte[])row["Anh"])),
                          row["Ten cong viec"].ToString(),
                          row["Ten cong ty"].ToString(),
                          Convert.ToInt32(row["Muc luong"]),
                          row["Dia diem"].ToString(),
                          row["Nganh nghe"].ToString(),
                          row["Chuc vu"].ToString(),
                          row["Loai hinh"].ToString(),
                          row["Ngay dang"].ToString(),
                          row["Chi tiet"].ToString(),
                          row["Gioi thieu cong ty"].ToString(),
                          row["Ma cong viec"].ToString(),
                          row["Username recruiter"].ToString(),
                          row["Trang thai"].ToString()
                      );
                AddJob addjob = new AddJob(job);
                addjob.ShowDialog();

            }
        }

        //button upload anh
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog opendlg = new OpenFileDialog();
            if (opendlg.ShowDialog() == DialogResult.OK)
            {
                guna2PictureBox1.Image = Image.FromFile(opendlg.FileName);
            }
        }
        //khai bao bien username lay tu form 1
        public string Username { get; set; }
        //su kien co phai add new job
        public bool isAddingNewJob { get; set; }
        public string Tencongty
        {
            get { return guna2TextBox1.Text; }
            set { guna2TextBox1.Text = value; }
        }
        public Image Anh
        {
            get { return guna2PictureBox1.Image; }
            set { guna2PictureBox1.Image = value; }
        }
        //button save
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            ClassDAL dal = new ClassDAL();
            string username = dal.GetUsername();

            Job job = new Job(guna2PictureBox1.Image,guna2TextBox2.Text,guna2TextBox1.Text,int.Parse(guna2TextBox7.Text),guna2TextBox8.Text,guna2TextBox3.Text,    
                            guna2TextBox5.Text, guna2TextBox6.Text, DateTime.Now.ToString(), guna2TextBox9.Text,guna2TextBox10.Text, guna2TextBox11.Text,
                            username,guna2CheckBox1.Checked ? "Open" : "Closed");
            if (isAddingNewJob)
            {
                ClassBLL objbll = new ClassBLL();
                if (objbll.SaveJob(job))
                {
                    MessageBox.Show("Success!");
                    //refresh joblist tim viec
                    ucRecruiter.Instance(username).LoadJobP(username);


                }
                else
                {
                    MessageBox.Show("Error!");
                }
            }
            if (!isAddingNewJob)
            {
                ClassBLL objbll = new ClassBLL();
                if (objbll.UpdateJob(job))
                {
                    MessageBox.Show("Success!");
                    //refresh joblist tim viec
                    ucRecruiter.Instance(username).LoadJobP(username);

                }
                else
                {
                    MessageBox.Show("Error!");
                }
            }

        }
        //Button exit
        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
