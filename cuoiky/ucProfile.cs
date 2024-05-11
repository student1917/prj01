using cuoiky.BLL;
using cuoiky.DAL;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace cuoiky
{
    public partial class ucProfile : UserControl
    {
        
        public string username { get; set; }
        private static ucProfile _instance;
        public bool isAddingNewProfile;
        public static ucProfile Instance(string  username, bool isAddingNewProfile)
        {           
            {
                if (_instance == null || _instance.IsDisposed)
                    _instance = new ucProfile(username, isAddingNewProfile);
                return _instance;
            }
        }
        //
        
        //xac dinh owner
        public bool isOwner { get; set; }
        //public void 
        public void RefreshUserProfile(string username)
        {
            LoadUserProfile(username);
        }
        public ucProfile(string username, bool isAddingNewProfile)
        {
            InitializeComponent();
            this.username = username;
            this.isAddingNewProfile = isAddingNewProfile;            
            LoadUserProfile(this.username);
        }
        //Load user profile khi an button profile o form1
        private void LoadUserProfile(string username)
        {          
            ketnoi kn = new ketnoi();            
            kn.connect.Open();    
            ClassBLL objbll = new ClassBLL();
            ClassDAL dal = new ClassDAL();
            string query = string.Format("SELECT * FROM Profile WHERE Username = '{0}'", username);
            DataTable dt = objbll.GetItems(query);
            DataRow[] rows = dt.Select("Username = '" + username + "'");
            if (rows.Length > 0)
            {
                DataRow row = rows[0];
                MemoryStream ms = new MemoryStream((byte[])row["Anh"]);
                guna2CirclePictureBox1.Image = new Bitmap(ms);
                label1.Text = row["Ho ten"].ToString();
                label2.Text = row["So dien thoai"].ToString();
                label3.Text = ((DateTime)row["Ngay sinh"]).ToString("dd/MM/yyyy");
                label4.Text = row["Gioi tinh"].ToString();
                label5.Text = row["Email"].ToString();
                label6.Text = row["Zalofb"].ToString();
                label7.Text = row["Dia chi"].ToString();
                label8.Text = row["Hoc van"].ToString();
                label9.Text = row["Ky nang"].ToString();
                label10.Text = row["Kinh nghiem"].ToString();
                label11.Text = row["Mong muon"].ToString();
                this.username = row["Username"].ToString();
                string currentusername = dal.GetUsername();
                if (currentusername == username)
                    isOwner = true;
                else if (currentusername != username)
                    isOwner = false;

                if (isOwner)
                {
                    iconButton1.Enabled = true;
                    iconButton1.Visible = true;
                }
                else
                {                   
                    iconButton2.Enabled = true;
                    iconButton2.Visible = true;
                }
            }
           
        }

        //Button Sua Profile
        private void iconButton1_Click(object sender, EventArgs e)
        {
            Profile pf = new Profile();
            pf.isAddingNewProfile = false;
            pf.LoadProfile(username);           
            
        }
        //dki su kien click vao button exit
        public event EventHandler XButtonClicked;
        //button exit
        private void iconButton2_Click(object sender, EventArgs e)
        {
            XButtonClicked?.Invoke(this, EventArgs.Empty);
        }
        public void xbtnclicked()
        {
            iconButton2.Visible=false;
        }

       
    }
}
