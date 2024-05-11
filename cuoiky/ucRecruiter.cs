using cuoiky.BLL;
using cuoiky.ClassDAO;
using cuoiky.DAL;
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
//using System.Web.UI.WebControls;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Shell;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace cuoiky
{
    public partial class ucRecruiter : UserControl
    {
        ClassDAL dal = new ClassDAL();
        private string username;
        private static ucRecruiter _instance;
        public static ucRecruiter Instance(string username)
        {
            {
                if (_instance == null || _instance.IsDisposed)
                    _instance = new ucRecruiter(username);
                return _instance;             
            }
        }

        public ucRecruiter(string username)
        {
            InitializeComponent();
            this.username = username;
            //LoadListRV(username);
            LoadJobP(username);
            //Load Cv yeu thich
            LoadFavoriteCV(username);
            // Đăng ký sự kiện Click cho từng ucP trong flowLayoutPanel4
            foreach (Control control in flowLayoutPanel4.Controls)
            {
                if (control is ucP ucPItem)
                {
                    ucPItem.DetailButtonClicked += UcPItem_DetailButtonClicked;
                    ucPItem.ListCVClicked += UcPItem_ListCVButtonCliked;
                    ucPItem.StopRecruimentButtonClicked += ucP_StopRecruiterClicked;
                    ucPItem.DeleteBtnClicked += ucP_DeleteBtnClicked;
                }
                if (control is UCBusiness ucBusiness)
                    ucBusiness.ButtonClicked += UCBusiness_ButtonClicked;               
            }  
          
        }      

        //Button ngung tuyen
        private void ucP_StopRecruiterClicked(object sender, EventArgs e)
        {
            ucP selectedUCP = (ucP)sender;
            string Macv = selectedUCP.Macv;
            ClassDAL dal = new ClassDAL();           
            string currentStatusQuery = "SELECT [Trang thai] FROM Job WHERE [Ma cong viec] = '" + Macv + "'";
            string currentStatus = dal.GetData(currentStatusQuery);
            // Cập nhật trạng thái tương ứng
            string newStatus = (currentStatus == "Open") ? "Closed" : "Open";
            string updateQuery = "UPDATE Job SET [Trang thai] = '" + newStatus + "' WHERE [Ma cong viec] = '" + Macv + "'";
            dal.ThucThi(updateQuery);
            LoadJobP(username);
        }

        //Button xem jd
        private void UcPItem_DetailButtonClicked(object sender, EventArgs e)
        {
            // Ẩn UserControl ucRecruiter
            this.Controls.Clear();
            ucP selectedUCP = (ucP)sender;
            string Macv = selectedUCP.Macv;
            // Hiển thị UserControl ucJobDetail           
            ClassBLL objbll = new ClassBLL();
            string query = "Select j.*, c.[Anh] from Job j inner join Company c on j.[Username recruiter] = c.Username where [Ma cong viec] = '" + Macv + "'";
            DataTable dt = objbll.GetItems(query);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
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
                    ucJobDetail ucjd = new ucJobDetail(job);                   
                    ucjd.ButtonClicked += UcJobDetail_ExitButtonClicked;
                    this.Controls.Add(ucjd);
                    ucjd.BringToFront();
                }
            }
        }
        //Load lai man hinh khi tat jd
        private void UcJobDetail_ExitButtonClicked(object sender, EventArgs e)
        {
            // Hiển thị lại UserControl ucRecruiter
            ucRecruiter ucr1 = new ucRecruiter(username);
            this.Controls.Add(ucr1);
            this.Controls.Remove((ucJobDetail)sender);
        }

        //Button List CV
        public void UcPItem_ListCVButtonCliked(object sender, EventArgs e)
        {
            // Ẩn UserControl ucRecruiter
            this.Controls.Clear();
            //lay Macv hien tai
            ucP selectedUCP = (ucP)sender;
            string Macv = selectedUCP.Macv;
            //tai list cv
            UCListCV ucListCV = new UCListCV(Macv);
            ucListCV.BackClicked += UcListCV_BackClicked;
            this.Controls.Add(ucListCV);         
        }
        //button back trong UcListCV
        private void UcListCV_BackClicked(object sender, EventArgs e)
        {
            ucRecruiter ucr1 = new ucRecruiter(username);
            this.Controls.Add(ucr1);
            this.Controls.Remove((UCListCV)sender);
        }
      
        //Load list da dang
       public void LoadJobP(string username)
       {
            flowLayoutPanel4.Controls.Clear();
            ClassBLL objbll = new ClassBLL();
            ClassDAL dal = new ClassDAL();           

            string query = string.Format("Select Job.[Ma cong viec], Job.[Ten cong viec], COUNT(Sent.[Ma cong viec]) AS Sluong, Job.[Trang thai] " +
                "FROM Job LEFT JOIN Sent ON Sent.[Ma cong viec] = Job.[Ma cong viec]" +
                "where Job.[Username recruiter] = '{0}' or Sent.[Ma cong viec] is null" +
                " GROUP BY Job.[Ma cong viec], Job.[Trang thai], Job.[Ten cong viec]", username);
            DataTable dt = objbll.GetItems(query);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {                    
                    List<ucP> ucp = new List<ucP>();
                    foreach (DataRow row in dt.Rows)
                    {
                        PostedJob pj = new PostedJob(
                           dal.GetImage("Select [Anh] from Company where [Username] = '" + username + "'"),
                           row["Ten cong viec"].ToString(),
                           row["Ma cong viec"].ToString(),
                           Convert.ToInt32(row["Sluong"]),
                           row["Trang thai"].ToString()
                            );
                        ucP p = new ucP(pj);
                        ucp.Add(p);
                        p.Click += UcPItem_DetailButtonClicked;
                        //p.DetailButtonClicked += UcPItem_DetailButtonClicked;
                        flowLayoutPanel4.Controls.Add(p);
                        //cap nhat location
                        flowLayoutPanel4.Height += 125;
                    }                   
                }
            }
        }
        //Load list cv yeu thich
        public void LoadFavoriteCV(string username)
        {
            flowLayoutPanel2.Controls.Clear();
            ClassBLL objbll = new ClassBLL();
            ClassDAL dal = new ClassDAL();  
            //string query = "Select * from FavoriteCV where [Username recruiter] = '"+username+"'";
            string query = "Select f.*, p.[Ho ten] from FavoriteCV f inner join Profile p on f.[Username employee] = p.Username " +
                "where [Username recruiter] = '"+username+"'";
            DataTable dt = objbll.GetItems(query);
            List <UCFavoriteCV> favoritecv = new List <UCFavoriteCV>();
            int rowNum = 0;
            
            foreach (DataRow row in dt.Rows)
            {
                string usernamee = row["Username employee"].ToString();
                FavoriteCV cv = new FavoriteCV(
                    row["Username employee"].ToString(),
                    row["Username recruiter"].ToString(),
                    ((DateTime)row["Ngay ghim"]).ToString("dd/MM/yyyy"),
                    row["Ho ten"].ToString(),
                    dal.GetImage("Select [Anh] from Profile where [Username] = '" + usernamee + "'")
                    ); 
                UCFavoriteCV fcv = new UCFavoriteCV(cv);
                fcv.Usernamee = cv.Usernamee;
                fcv.Usernamer = cv.Usernamer;
                favoritecv.Add(fcv);
                flowLayoutPanel2.Controls.Add(fcv);
                //dki su kien xem cv
                fcv.BtnViewCVClicked += ucfavoritecv_ViewCVBtnClicked;
                //dki su kien xoa
                fcv.BtnDeleteClicked += ucfavoritecv_DeleteCVBtnClicked;
                //dieu chinh location
                flowLayoutPanel2.Height += 125;
                rowNum++;
            }           

        }
        //btn xoa job trong ucP
        private void ucP_DeleteBtnClicked(object sender, EventArgs e)
        {
            ClassDAL dal = new ClassDAL();
            ucP selectedUCP = (ucP)sender;
            string Macv = selectedUCP.Macv;            
            string username = dal.GetUsername();
            string query = "Delete from Job where [Ma cong viec] = '" + Macv + "'";
            if (dal.ThucThi1(query))
            {

                MessageBox.Show("Success!");
                flowLayoutPanel4.Controls.Clear();
                LoadJobP(username);
            }
        }
        //btn xem cv trong ucfavoritecv
        private void ucfavoritecv_ViewCVBtnClicked(object sender, EventArgs e)
        {
            UCFavoriteCV selectedCV = (UCFavoriteCV)sender;
            string username = selectedCV.Usernamee;
            ucProfile profile = new ucProfile(username, false);
            this.Controls.Add(profile);
            profile.BringToFront();
            profile.XButtonClicked += CurrentProfile_ExitClicked;
        }
        //btn xoa cv yeu thich
        private void ucfavoritecv_DeleteCVBtnClicked(object sender, EventArgs e)
        {

            ClassDAL dal = new ClassDAL();
            UCFavoriteCV selectedCV = (UCFavoriteCV)sender;
            string username = selectedCV.Usernamee;
            string query = "Delete from FavoriteCV where [Username employee] = '" + username + "'";
            if (dal.ThucThi1(query))
            {
                MessageBox.Show("Success!");
                LoadFavoriteCV(selectedCV.Usernamer);
            }
            
            
        }
        //xu li khi click thoat trong ucprofile
        private void CurrentProfile_ExitClicked(object sender, EventArgs e)
        {
            this.Controls.Remove((ucProfile)sender);
            //Dispose();
        }        
        //load info company
        private void LoadCompany()
        {            
            string query = "Select * from Company where [Username] ='"+this.username+"' ";          
            ClassDAL dal = new ClassDAL();           
            UCBusiness business = dal.LoadComPany(query);
            string countQuery = "Select count (*) from Job where [Username recruiter] = '" + this.username + "' and [Trang thai] = 'Open' ";
            business.Sluong = dal.GetCount(countQuery);
            this.Controls.Add(business);
            //business.Dock = DockStyle.Fill;
            business.BringToFront();
        }
        //Button your business
        private void guna2Button2_Click(object sender, EventArgs e)       
        {

            LoadCompany();
        }
        //Load lai man hinh khi tat your business
        private void UCBusiness_ButtonClicked(object sender, EventArgs e)
        {
            LoadJobP(username);
        }
        //button add new job
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            AddJob addjob = new AddJob();
            addjob.isAddingNewJob = true;
            string username = dal.GetUsername();           
            addjob.Username = username;
            addjob.Tencongty = dal.GetData("Select [Ten cong ty] from Company where [Username] = '" + username + "'");
            addjob.Anh = dal.GetImage("Select [Anh] from Company where [Username] = '" + username + "' ");
            addjob.ShowDialog();

        }

       
    }
}
