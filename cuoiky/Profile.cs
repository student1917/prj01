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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace cuoiky
{
    public partial class Profile : Form
    {
        ProfileDAO pf;
        public Profile()
        {
            InitializeComponent();         

        }
        //
        public Profile(ProfileDAO pf)
        {
            InitializeComponent();
            this.pf = pf;
            guna2PictureBox1.Image = pf.Img;
            guna2DateTimePicker1.Text = pf.Ngaysinh;
            guna2TextBox1.Text = pf.Hoten;
            guna2TextBox2.Text = pf.Username;
            guna2TextBox4.Text = pf.Hocvan;
            guna2TextBox5.Text = pf.Mongmuon;
            guna2TextBox6.Text = pf.Email;
            guna2TextBox7.Text = pf.Sdt;
            guna2TextBox8.Text = pf.Zlfb;
            guna2TextBox9.Text = pf.Kynang;
            guna2TextBox10.Text = pf.Kinhnghiem;
            guna2TextBox11.Text = pf.Diachi;
            guna2TextBox11.Text = pf.Diachi;
            checkBox1.Checked = (pf.Gioitinh == "Nam");
            checkBox2.Checked = (pf.Gioitinh == "Nu");

        }
        //Do data de Update profile
        public void LoadProfile(string username)
        {
            ketnoi kn = new ketnoi();
            kn.connect.Open();
            ClassBLL objbll = new ClassBLL();
            string query = string.Format("SELECT * FROM Profile WHERE Username = '{0}'", username);
            DataTable dt = objbll.GetItems(query);         
            DataRow[] rows = dt.Select("Username = '"+username+"'");
            if (rows.Length > 0)
            {
                DataRow row = rows[0];               
                ProfileDAO pdf = new ProfileDAO(
                                new Bitmap(new MemoryStream((byte[])row["Anh"])),
                                row["Ho ten"].ToString(),
                                row["Gioi tinh"].ToString(),                
                                row["Ngay sinh"].ToString(),
                                row["So dien thoai"].ToString(),
                                row["Email"].ToString(),
                                row["Zalofb"].ToString(),
                                row["Dia chi"].ToString(),
                                row["Hoc van"].ToString(),
                                row["Ky nang"].ToString(),
                                row["Kinh nghiem"].ToString(),               
                                row["Mong muon"].ToString(),
                                row["Username"].ToString()               
                             );
                Profile pf = new Profile(pdf);
                pf.Show();

            }
          
        }
        //getter va setter cho username
        public string Username
        {
            get { return guna2TextBox2.Text; }
            set { guna2TextBox2.Text = value;}
        }
        //
        private void AddProfile_Load(object sender, EventArgs e)
        {

        }
        //Button Upload
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog opendlg = new OpenFileDialog();
            if (opendlg.ShowDialog() == DialogResult.OK)
            {
                guna2PictureBox1.Image = Image.FromFile(opendlg.FileName);
            }
        }

        //button Save
        public bool isAddingNewProfile { get; set; }
        public bool IsProfileCompleted { get; set; }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            //lay gioi tinh
            string gioitinh = "";
            if (checkBox1.Checked)
                gioitinh = "Nam";
            if (checkBox2.Checked)
                gioitinh = "Nu";
            //
            ProfileDAO pfd = new ProfileDAO(guna2PictureBox1.Image, guna2TextBox1.Text, gioitinh, guna2DateTimePicker1.Value.ToString(),
                    guna2TextBox7.Text, guna2TextBox6.Text, guna2TextBox8.Text, guna2TextBox11.Text, guna2TextBox4.Text,
                    guna2TextBox9.Text, guna2TextBox10.Text, guna2TextBox5.Text, guna2TextBox2.Text);

            //Add
            if (isAddingNewProfile)
            {
                ClassBLL objbll = new ClassBLL();
                if (objbll.SaveProfile(pfd))
                {
                    MessageBox.Show("Success!");
                    IsProfileCompleted = true;
                    ucProfile.Instance(guna2TextBox2.Text, false).RefreshUserProfile(guna2TextBox2.Text);
                }
                else
                {
                    MessageBox.Show("Error!");
                }                
            }
            //Update
            if (!isAddingNewProfile)
            {
                ClassBLL objbll = new ClassBLL();
                if (objbll.UpdateProfile(pfd))
                {
                    MessageBox.Show("Success!");
                    ucProfile.Instance(guna2TextBox2.Text, false).RefreshUserProfile(guna2TextBox2.Text);
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
