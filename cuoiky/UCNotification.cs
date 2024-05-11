using cuoiky.BLL;
using cuoiky.ClassDAO;
using cuoiky.DAL;
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

namespace cuoiky
{
    public partial class UCNotification : UserControl
    {
        ClassDAL dal = new ClassDAL();
        ClassBLL objbll = new ClassBLL();
        private static UCNotification _instance;
        public static UCNotification Instance()
        {
            {
                if (_instance == null || _instance.IsDisposed)
                    _instance = new UCNotification();
                return _instance;
            }
        }
        public UCNotification()
        {
            InitializeComponent();
            LoadMail();
            LoadPost();
            LoadJob();
        }
        //Load list mail
        private void LoadMail()
        {
            flowLayoutPanel2.Controls.Clear();
            string username = dal.GetUsername();
            string query = "Select j.[Ten cong viec], c.[Anh], j.[Ten cong ty], m.* from Job j inner join Mail m " +
                "on m.[Ma cong viec] = j.[Ma cong viec] inner join Company c on c.Username = j.[Username recruiter] where m.[Username] = '" + username + "' ";
            DataTable dt = objbll.GetItems(query);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    UCMail[] listItems = new UCMail[dt.Rows.Count];
                    for (int i = 0; i < listItems.Length; i++)
                    {
                        DataRow row = dt.Rows[i];
                        listItems[i] = new UCMail();
                        listItems[i].Tencongviec = row["Ten cong viec"].ToString();
                        listItems[i].Tencongty = row["Ten cong ty"].ToString();
                        listItems[i].Img = new Bitmap(new MemoryStream((byte[])row["Anh"]));
                        listItems[i].Macv = row["Ma cong viec"].ToString();
                        flowLayoutPanel2.Controls.Add(listItems[i]);
                        flowLayoutPanel2.Height += 125;
                    }
                }
            }
        }
        //Load list uc home
        public void LoadPost()
        {
            flowLayoutPanel1.Controls.Clear();
            string username = dal.GetUsername();
            string query = "Select * from HomePost where [Username] = '" + username + "' ";
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
                    row["Noi dung"].ToString().Trim(),
                    ((DateTime)row["Ngay dang"]).ToString()
                    );
                UCHome_List uchomelist = new UCHome_List(p);
                uchomelist.Username = username;
                //uchomelist.Noidung = p.Noidung;
                uchomelist.Ngaydang = p.Ngaydang;
                uchomelist.IsNotification = true;   
                uchomelist.BtnDeleteClicked += uchomelist_BtnDeleteClicked;
                ucHome_List.Add(uchomelist);
                flowLayoutPanel1.Controls.Add(uchomelist);
                flowLayoutPanel1.Height += 237;
            }
        }
        //xu ly khi delete post
        private void uchomelist_BtnDeleteClicked(object sender, EventArgs e)
        {
            ClassDAL dal = new ClassDAL();
            UCHome_List selectedhomelist = (UCHome_List)sender;
            string username = selectedhomelist.Username;
            string ngaydang = selectedhomelist.Ngaydang;           
            string query = "delete from HomePost where [Username] = '"+username+"' and [Ngay dang] = '"+ngaydang+"' ";
            if (dal.ThucThi1(query))
            {
                MessageBox.Show("Success!");
                LoadPost();
                UCHome.Instance().LoadList();
            }
            else
            {
                MessageBox.Show("Error!");
            }              
        }
        //load lich su ung tuyen 
        private void LoadJob()
        {
            flowLayoutPanel3.Controls.Clear();
            string username = dal.GetUsername();
            string query = "Select j.*, s.[Ngay gui], c.[Anh] from Job j inner join Sent s on j.[Ma cong viec] = s.[Ma cong viec] inner join Company c on j.[Username recruiter] = c.Username where s.[Username] = '" + username + "'";
            DataTable dt = objbll.GetItems(query);
            // Sort the DataTable by the [Ngay dang] column
            dt.DefaultView.Sort = "[Ngay gui] DESC"; // ASC for ascending order, DESC for descending order
            DataTable sortedDt = dt.DefaultView.ToTable();
            List<UCJobList> jl = new List<UCJobList>();
            foreach (DataRow row in sortedDt.Rows)
            {
                Job j = new Job(
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

                UCJobList job = new UCJobList(j);
                job.IsReadOnly = true;
                job.Jobdetail = new ucJobDetail(j);
                flowLayoutPanel3.Controls.Add(job);
                flowLayoutPanel3.Height += 150;
                job.Click += new System.EventHandler(this.UserControl_Click);

            }
        }
        //xu ly khi nhan vao uc
        private void UserControl_Click(object sender, System.EventArgs e)
        {          
            UCJobList clickedControl = sender as UCJobList;
            ucJobDetail jobDetail = clickedControl.Jobdetail;
            ucFindJob fj = new ucFindJob();
            jobDetail.ButtonClicked += UcJobDetail_ButtonClicked;//button exit
            jobDetail.LinkLabelClicked += fj.UcJobDetail_LinkLabelClicked;//link label cty
            this.Controls.Add(jobDetail);
            jobDetail.BringToFront();
        }
        private void UcJobDetail_ButtonClicked(object sender, System.EventArgs e)
        {            
            LoadJob();            
        }
    }
}
