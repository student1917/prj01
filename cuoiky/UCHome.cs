using cuoiky.BLL;
using cuoiky.ClassDAO;
using cuoiky.DAL;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Resources;

namespace cuoiky
{
    public partial class UCHome : UserControl
    {
      
        ClassDAL dal = new ClassDAL();
        private static UCHome _instance;
        public static UCHome Instance()
        {            
            {
                if (_instance == null || _instance.IsDisposed)
                    _instance = new UCHome();
                return _instance;
            }
        }        
        public UCHome()
        {
            InitializeComponent();
            ClassDAL dal = new ClassDAL();
            //username dang nhap hien tai
            string currentUsername = dal.GetUsername();
            guna2CirclePictureBox1.Image = dal.GetImage("Select [Anh] from Profile where [Username] = '"+currentUsername+"' ");
            DisplayMode();
            LoadList();           
        }           
        //Load list 
        public void LoadList()
        {
            
            flowLayoutPanel1.Controls.Clear();
            ClassBLL objbll = new ClassBLL();
            string query = "Select * from HomePost";
            DataTable dt = objbll.GetItems(query);
            // Sort the DataTable by the [Ngay dang] column
            dt.DefaultView.Sort = "[Ngay dang] DESC"; // ASC for ascending order, DESC for descending order
            DataTable sortedDt = dt.DefaultView.ToTable();

            List<UCHome_List> ucHome_List = new List<UCHome_List>();
            foreach (DataRow row in sortedDt.Rows)
            {
                Post p = new Post(
                    new Bitmap(new MemoryStream((byte[])row["Anh"])),
                    row["Username"].ToString(),
                    row["Noi dung"].ToString(),
                    ((DateTime)row["Ngay dang"]).ToString("dd/MM/yyyy")
                    );
                UCHome_List uchomelist = new UCHome_List(p);                                       
                uchomelist.Username = p.Username;                       
                
                uchomelist.ButtonCVClicked += homelist_ViewCVClicked;
                uchomelist.ButtonPinClicked += homelist_PinClicked;
                ucHome_List.Add(uchomelist);
                flowLayoutPanel1.Controls.Add(uchomelist);               
            }
        }
        // xem cv trong uc home list
        private void homelist_ViewCVClicked(object sender, EventArgs e)
        {            
            UCHome_List selectedUCHL = sender as UCHome_List;
            string username = selectedUCHL.Username;
            ucProfile profile = new ucProfile(username, false);
            this.Controls.Add(profile);
            profile.BringToFront();          
            // Đăng ký sự kiện ExitClicked
            profile.XButtonClicked += (s, ev) =>
            {
                this.Controls.Remove(profile);               
                profile.Dispose();
            };
        }
        //ghim yeu thich
        private void homelist_PinClicked(object sender, EventArgs e)
        {
               
            ClassDAL dal = new ClassDAL();
            //username dang nhap hien tai
            string currentUsername = dal.GetUsername();
            //chu so huu post
            UCHome_List selectedUCHL = sender as UCHome_List;
            string username = selectedUCHL.Username;
            //check ghim chua
            string checkQuery = "Select count(*) from FavoriteCV where [Username employee] = '" + username + "' and [Username recruiter] = '"+currentUsername+"' ";
            int count = dal.GetCount(checkQuery);
            if (count == 0 )
            {
                string query = "Insert into FavoriteCV([Username employee], [Username recruiter], [Ngay ghim]) values " +
                                "('" + username + "','" + currentUsername + "','" + DateTime.Now + "')";
                //dal.ThucThi(query);
                if (dal.ThucThi1(query))
                {
                    MessageBox.Show("Success!");
                    ucRecruiter.Instance(currentUsername).LoadFavoriteCV(currentUsername);
                }
            }
            else
            {
                MessageBox.Show("Bạn đã ghim trước đó!");
            }
        }
        //chi hien thi dang bai cho employee
        public void DisplayMode()
        {
            ClassDAL dal = new ClassDAL();
            string currentUsername = dal.GetUsername();
            string role = dal.GetUserRole(currentUsername);
            if (role=="Recruiter")
            {
                panel1.Hide();
                flowLayoutPanel1.Dock = DockStyle.Fill;
            }
            else
            { 
                this.Controls.Add(panel1);
                panel1.Dock = DockStyle.Top;           
            }

        }           
       
        //click vao textbox thi se hien thi ra form create post
        private void guna2TextBox1_Click(object sender, EventArgs e)
        {
            CreatePost createPost = new CreatePost();
            createPost.Username = dal.GetUsername();
            createPost.ShowDialog();    
        }



      
    }
}
