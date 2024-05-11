using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Shapes;
using cuoiky.BLL;
using cuoiky.DAL;


namespace cuoiky
{
    public partial class ucFindJob : UserControl
    {

        private static ucFindJob _instance;
      

        public static ucFindJob Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                    _instance = new ucFindJob();
                return _instance;
            }
        }
        public ucFindJob()
        {
            InitializeComponent();
        }
        //lay username cua user dang nhap hien tai
        private Form1 form1;
        public void SetForm1(Form1 form)
        {
            form1 = form;
        }
        private void ucFindJob_Load(object sender, EventArgs e)
        {
            SetForm1((Form1)this.ParentForm);
            GenerateDynamicUserControl("select j.*, c.[Anh] from Job j inner join Company c on j.[Username recruiter] = c.Username where [Trang thai] = 'Open'");
        }
        //do du lieu len list uc
        private void GenerateDynamicUserControl(string query)
        {
            flowLayoutPanel1.Controls.Clear();
            
            //
            ClassBLL objbll = new ClassBLL();            
            DataTable dt = objbll.GetItems(query);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    List<UCJobList> ucJobList = new List<UCJobList>();

                    foreach (DataRow row in dt.Rows)
                    {
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
                        
                        UCJobList ucJob = new UCJobList(job);
                        ucJob.Username = form1.Username;
                        ucJob.Jobdetail = new ucJobDetail(job);
                        ucJobList.Add(ucJob); // Thêm UCJobList vào danh sách
                        flowLayoutPanel1.Controls.Add(ucJob);
                        ucJob.Click += new System.EventHandler(this.UserControl_Click);

                    }
                }
            }
        }

        //xu ly khi nhan vao uc
        private void UserControl_Click(object sender, System.EventArgs e)
        {
            //dieu chinh hien thi             
            flowLayoutPanel1.Height += 84;
            flowLayoutPanel1.Location = new System.Drawing.Point(1, 82);
            flowLayoutPanel1.Controls.Clear();
            //
            UCJobList clickedControl = sender as UCJobList;
            ucJobDetail jobDetail = clickedControl.Jobdetail;
            jobDetail.ButtonClicked += UcJobDetail_ButtonClicked;//button exit
            jobDetail.LinkLabelClicked += UcJobDetail_LinkLabelClicked;//link label cty
            //flowLayoutPanel1.Controls.Add(jobDetail);
            this.Controls.Add(jobDetail);
            //jobDetail.Dock = DockStyle.Fill;
            jobDetail.BringToFront();
        }

        //load lai man hinh khi tat jobdetail        
        private void UcJobDetail_ButtonClicked(object sender, EventArgs e)
        {
            //this.Controls.Remove((ucJobDetail)sender);
            flowLayoutPanel1.Controls.Clear();            
            GenerateDynamicUserControl("select j.*, c.[Anh] from Job j inner join Company c on j.[Username recruiter] = c.Username where [Trang thai] = 'Open'");
        }
        //load cty
        public void UcJobDetail_LinkLabelClicked(object sender, EventArgs e)
        {            
            ucJobDetail jobDetail = sender as ucJobDetail;
            string usernameRecruiter = jobDetail.Usernamerecruiter;       
            ClassDAL dal = new ClassDAL();
            string query = "Select * from Company where [Username] ='" + usernameRecruiter + "' ";
            string countQuery = "Select count (*) from Job where [Username recruiter] = '" + usernameRecruiter + "' and [Trang thai] = 'Open' ";            
            UCBusiness business = dal.LoadComPany(query);
            business.Sluong = dal.GetCount(countQuery);
            this.Controls.Add(business);
            //business.Dock = DockStyle.Fill;
            business.BringToFront();
        }
        //btn tim kiem
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            //ClassDAL dal = new ClassDAL();
            string query = "select j.*, c.[Anh] from Job j inner join Company c on j.[Username recruiter] = c.Username where [Trang thai] = 'Open' and [Ten cong viec] like '%" + guna2TextBox1.Text+ "%' ";
            GenerateDynamicUserControl(query);
        }
        //ho tro btn tim kiem 
        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            string query = "select j.*, c.[Anh] from Job j inner join Company c on j.[Username recruiter] = c.Username where [Trang thai] = 'Open' and [Ten cong viec] like '%" + guna2TextBox1.Text + "%' ";
            GenerateDynamicUserControl(query);
        }
        //btn loc - hien thi day loc
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            guna2Panel1.Height += 84;
            flowLayoutPanel1.Location = new System.Drawing.Point(1, 169);          
            guna2Panel1.Controls.Add(panel1);
            guna2Panel1.Controls.SetChildIndex(panel1, 1);            
            GenerateDynamicUserControl("select j.*, c.[Anh] from Job j inner join Company c on j.[Username recruiter] = c.Username where [Trang thai] = 'Open'");
        }
        //btn an - an day loc
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            //flowLayoutPanel1.Controls.Remove(panel1);
            guna2Panel1.Controls.Remove(panel1);
            guna2Panel1.Height -= 84;
            flowLayoutPanel1.Height += 84;
            flowLayoutPanel1.Location = new System.Drawing.Point(1, 82);
        }
        //Loc chuc vu
        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = "select j.*, c.[Anh] from Job j inner join Company c on j.[Username recruiter] = c.Username where [Trang thai] = 'Open' and [Chuc vu] like '%" + guna2ComboBox1.Text + "%'  ";
            GenerateDynamicUserControl(query);            
        }
        //Loc nganh nghe
        private void guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = "select j.*, c.[Anh] from Job j inner join Company c on j.[Username recruiter] = c.Username where [Trang thai] = 'Open' [Nganh nghe] and like '%" + guna2ComboBox2.Text + "%'";
            GenerateDynamicUserControl(query);            
        }
        //Loc loai hinh
        private void guna2ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = "select j.*, c.[Anh] from Job j inner join Company c on j.[Username recruiter] = c.Username where [Trang thai] = 'Open' and [Loai hinh] like '%" + guna2ComboBox3.Text + "%' ";
            GenerateDynamicUserControl(query);            
        }
        //Loc muc luong
        private void guna2ComboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox4.SelectedItem == null)
            {
                return; // Không có mục nào được chọn, không thực hiện gì cả
            }
            string selectedRange = guna2ComboBox4.SelectedItem.ToString();            
            string filterExpression = "";
            switch (selectedRange)
            {
                case "<200":
                    filterExpression = "[Muc luong] < 200";
                    break;
                case "200-500":
                    filterExpression = "[Muc luong] >= 200 AND [Muc luong] <= 500";
                    break;
                case "500-1000":
                    filterExpression = "[Muc luong] > 500 AND [Muc luong] <= 1000";
                    break;
                case ">1000":
                    filterExpression = "[Muc luong] > 1000";
                    break;
                default:
                    break;
            }
            string query = "select j.*, c.[Anh] from Job j inner join Company c on j.[Username recruiter] = c.Username where [Trang thai] = 'Open' AND " + filterExpression;
            GenerateDynamicUserControl(query);
            
        }
        //loc dia diem
        private void guna2ComboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = "select j.*, c.[Anh] from Job j inner join Company c on j.[Username recruiter] = c.Username where [Trang thai] = 'Open' and [Dia diem] like '%" + guna2ComboBox5.Text + "%'";
            GenerateDynamicUserControl(query);
        }
        //btn reset bo loc
        private void guna2Button4_Click(object sender, EventArgs e)
        {            
            guna2ComboBox1.SelectedIndex = -1;
            guna2ComboBox2.SelectedIndex = -1;
            guna2ComboBox3.SelectedIndex = -1;
            guna2ComboBox4.SelectedIndex = -1;
            guna2ComboBox5.SelectedIndex = -1;
            GenerateDynamicUserControl("select j.*, c.[Anh] from Job j inner join Company c on j.[Username recruiter] = c.Username where [Trang thai] = 'Open'");
        }

    }
}
