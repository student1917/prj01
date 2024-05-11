using cuoiky.BLL;
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
    public partial class UCListCV : UserControl
    {
        private string Macv;

        public UCListCV(string Macv)
        {
            InitializeComponent();
            this.Macv = Macv;
            RefreshData(Macv);

            //Dang ki su kien click cho tung ucRV trong flowlayout panel 1
            foreach (Control control in flowLayoutPanel1.Controls)
            {
                if (control is ucRV ucRVItem)
                {
                    ucRVItem.ViewCVButtonClicked += ucRVItem_ViewCVButtonClicked;
                    ucRVItem.VClicked += ucRVItem_VButtonClicked;
                    ucRVItem.XClicked += ucRVItem_XButtonClicked;
                }
            }
            foreach (Control control in flowLayoutPanel2.Controls)
            {
                if (control is ucD ucDItem)
                    ucDItem.ViewCVDButtonClicked += ucDItem_ViewCVButtonClicked;
            }
            foreach (Control control in flowLayoutPanel3.Controls)
            {
                if (control is ucD ucDItem)
                {
                    ucDItem.ViewCVDButtonClicked += ucDItem_ViewCVButtonClicked;
                    ucDItem.DeleteCVClicked += ucD_DeleteCV;
                }
            }
        }
        //xu ly khi click vao button v trong ucRV
        private void ucRVItem_VButtonClicked(object sender, EventArgs e)
        {
            ucRV selectedUCRV = (ucRV)sender;
            string username = selectedUCRV.Username;          
            ClassDAL dal = new ClassDAL();
            string query = "Update Sent set [Trang thai] = 'Passed', [Ngay duyet] = '" + DateTime.Now.ToString("yyyy-MM-dd") + "'" +
                " where [Username] = '" + username + "'  and [Ma cong viec] = '" + Macv + "'";
            dal.ThucThi(query);
            RefreshData(Macv);
        }
        //xu ly khi click vao button x (reject)
        private void ucRVItem_XButtonClicked(object sender, EventArgs e)
        {
            ucRV selectedUCRV = (ucRV)sender;
            string username = selectedUCRV.Username;           
            ClassDAL dal = new ClassDAL();
            string query = "Update Sent set [Trang thai] = 'Rejected', [Ngay duyet] = '" + DateTime.Now.ToString("yyyy-MM-dd") + "' where " +
                "[Username] = '" + username + "' and [Ma cong viec] = '" + Macv + "' ";
            dal.ThucThi(query);
            RefreshData(Macv);
        }
        //xu ly khi click vao button xem cv trong ucRV
        private void ucRVItem_ViewCVButtonClicked(object sender, EventArgs e)
        {
            ucRV selectedUCRV = (ucRV)sender;
            string username = selectedUCRV.Username;
            ucProfile profile = new ucProfile(username, false);
            this.Controls.Add(profile);
            profile.BringToFront();
            profile.XButtonClicked += CurrentProfile_ExitClicked;
        }
        // Xử lý sự kiện ExitClicked của ucProfile
        private void CurrentProfile_ExitClicked(object sender, EventArgs e)
        {
            this.Controls.Remove((ucProfile)sender);            
        }
        //xu ly khi click vao button xem cv trong ucD
        private void ucDItem_ViewCVButtonClicked(object sender, EventArgs e)
        {

            ucD selectedUCD = (ucD)sender;
            string username = selectedUCD.Username;
            ucProfile profile = new ucProfile(username, false);
            this.Controls.Add(profile);
            profile.BringToFront();
            profile.XButtonClicked += CurrentProfile_ExitClicked;
        }
        //su kien button back
        public event EventHandler BackClicked;
        private void iconButton1_Click(object sender, EventArgs e)
        {
            BackClicked?.Invoke(this, EventArgs.Empty);
        }
        //RefreshData
        public void RefreshData(string Macv)
        {
            LoadListCV(Macv);
            LoadPassedCVList(Macv);
            LoadRejectedCVList(Macv);   
        }

        //Load list cv
        public void LoadListCV(string Macv)
        {
            flowLayoutPanel1.Controls.Clear();
            ClassBLL objbll = new ClassBLL();
            ClassDAL dal = new ClassDAL();           
            string query = "select p.[Ho ten], s.* from Profile as p inner join Sent as s on p.Username = s.Username where s.[Ma cong viec] = '" + Macv + "' and s.[Trang thai] is null";
            DataTable dt = objbll.GetItems(query);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    ucRV[] listItems = new ucRV[dt.Rows.Count];
                    for (int i = 0; i < listItems.Length; i++)
                    {
                        DataRow row = dt.Rows[i];
                        listItems[i] = new ucRV();
                        listItems[i].Username = row["Username"].ToString();
                        listItems[i].Tenungvien = row["Ho ten"].ToString();
                        listItems[i].Ngaygui = ((DateTime)row["Ngay gui"]).ToString("dd/MM/yyyy");
                        string username = row["Username"].ToString();
                        Image img = dal.GetImage("Select [Anh] from Profile where [Username] = '" + username + " '");
                        listItems[i].Img = img;
                        flowLayoutPanel1.Controls.Add(listItems[i]);
                        //dieu chinh location
                        flowLayoutPanel1.Height += 125;
                    }

                }

            }
        }

        //load list da pass
        public void LoadPassedCVList(string Macv)
        {
            flowLayoutPanel2.Controls.Clear();
            ClassBLL objbll = new ClassBLL();
            ClassDAL dal = new ClassDAL();          
            string query = "Select p.[Ho ten], s.* from Profile p inner join Sent s on p.Username = s.Username" +
                " where s.[Trang thai] = 'Passed' and s.[Ma cong viec] = '" + Macv + "' ";
            DataTable dt = objbll.GetItems(query);
            if (dt.Rows.Count > 0)
            {
                ucD[] listItems = new ucD[dt.Rows.Count];
                for (int i = 0; i < listItems.Length; i++)
                {
                    DataRow row = dt.Rows[i];
                    listItems[i] = new ucD();
                    listItems[i].Username = row["Username"].ToString();
                    listItems[i].Hoten = row["Ho ten"].ToString();
                    listItems[i].Ngaygui = ((DateTime)row["Ngay gui"]).ToString("dd/MM/yyyy");
                    listItems[i].Ngayduyet = ((DateTime)row["Ngay duyet"]).ToString("dd/MM/yyyy");
                    string username = row["Username"].ToString();
                    Image img = dal.GetImage("Select [Anh] from Profile where [Username] = '" + username + " '");
                    listItems[i].Img = img;
                    listItems[i].SendMailClicked += ucD_SendMailClicked;
                    flowLayoutPanel2.Controls.Add(listItems[i]);
                    //dieu chinh location
                    flowLayoutPanel2.Height += 125;
                }
            }
        }

        //load list da tu choi
        public void LoadRejectedCVList(string Macv)
        {
            flowLayoutPanel3.Controls.Clear();
            ClassBLL objbll = new ClassBLL();
            ClassDAL dal = new ClassDAL();           
            string query = "Select p.[Ho ten], s.* from Profile p inner join Sent s on p.Username = s.Username" +
               " where s.[Trang thai] = 'Rejected' and s.[Ma cong viec] = '" + Macv + "' ";
            DataTable dt = objbll.GetItems(query);
            ucD[] listItems = new ucD[dt.Rows.Count];
            for (int i = 0; i < listItems.Length; i++)
            {
                DataRow row = dt.Rows[i];
                listItems[i] = new ucD();
                listItems[i].Username = row["Username"].ToString();                         
                listItems[i].Hoten = row["Ho ten"].ToString();
                listItems[i].Macv = Macv;
                listItems[i].Ngaygui = ((DateTime)row["Ngay gui"]).ToString("dd/MM/yyyy");
                listItems[i].Ngayduyet = ((DateTime)row["Ngay duyet"]).ToString("dd/MM/yyyy");
                string username = row["Username"].ToString();               
                Image img = dal.GetImage("Select [Anh] from Profile where [Username] = '" + username + " '");
                listItems[i].Img = img;
                flowLayoutPanel3.Controls.Add(listItems[i]);
                //dieu chinh location
                flowLayoutPanel3.Height += 125;
            }

        }
        //btn delete cv click
        private void ucD_DeleteCV(object sender, EventArgs e)
        {           
            ClassDAL dal = new ClassDAL();
            ucD selectedUCD = (ucD)sender;
            string username = selectedUCD.Username;
            string macv = selectedUCD.Macv;
            string query = "Delete from Sent where [Username] = '" + username + "' and [Ma cong viec] = '" + macv + "' ";
            dal.ThucThi(query);
            flowLayoutPanel3.Height -= 100;
            LoadRejectedCVList(Macv);
        }
    
        //gui mail
        private void ucD_SendMailClicked (object sender, EventArgs e)
        {
            ClassDAL dal = new ClassDAL();
            ucD selectedUCD = (ucD) sender;
            string username = selectedUCD.Username;           
            SendMail sm = new SendMail();
            sm.Username = username;
            sm.Macv = Macv;
            string checkquery = "Select count(*) from Mail where [Username] = '" + username + "' and [Ma cong viec] = '" + Macv + "' ";
            int count = dal.GetCount(checkquery);
            if (count > 0)
            {
                sm.IsAddingNewMail = false;
                sm.Show();
                sm.LoadMail(username, Macv);
            }
            else
            {
                sm.IsAddingNewMail= true;
                sm.Show();
            }         
        }
        //ba button exit
        private void iconButton2_Click(object sender, EventArgs e)
        {
            BackClicked?.Invoke(this, EventArgs.Empty);
        }        

        private void iconButton1_Click_1(object sender, EventArgs e)
        {
            BackClicked?.Invoke(this, EventArgs.Empty);
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            BackClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
