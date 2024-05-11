using cuoiky.BLL;
using cuoiky.ClassDAO;
using cuoiky.DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace cuoiky
{
    public partial class SendMail : Form
    {
        Mail m;
        //ClassBLL objbll = new ClassBLL();
        //ClassDAL dal = new ClassDAL();
        public SendMail()
        {
            InitializeComponent();
        }
        public SendMail(Mail m)
        {
            InitializeComponent();
            this.m = m;
            textBox1.Text = m.Usernamee;
            textBox2.Text = m.Noidung;
            textBox3.Text = m.Macv;
            guna2DateTimePicker1.Text = m.Henlich;
        }
      
        public string Username
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }  
        }
        public string Macv
        {
            get { return textBox3.Text; }
            set { textBox3.Text = value; }
        }
        public string Noidung
        {
            get { return textBox2.Text; }
            set { textBox2.Text = value; } 
        }
        public string Henlich
        {
            get { return guna2DateTimePicker1.Value.ToString(); }
            set { guna2DateTimePicker1.Text = value; }
        }
        public string UserRole { get; set; }    
        public bool IsAddingNewMail { get; set; }
        
        //btn send mail
        private void button1_Click(object sender, EventArgs e)
        {
            ClassDAL dal = new ClassDAL();
            string usernamer = dal.GetUsername();
            Mail m = new Mail(textBox1.Text, usernamer, textBox2.Text, DateTime.Now.ToString(), textBox3.Text, guna2DateTimePicker1.Value.ToString());
            if (IsAddingNewMail)
            {
                ClassBLL objbll = new ClassBLL();
                if (objbll.SaveMail(m))
                {
                    MessageBox.Show("Success!");
                    //gui thu den cho employee
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error!");
                }
            }
            if (!IsAddingNewMail)
            {
                ClassBLL objbll = new ClassBLL();
                if (objbll.UpdateMail(m))
                {
                    MessageBox.Show("Success!");
                    //gui thu den cho employee
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error!");
                }
            }
        }
        private bool isReadOnly { get;set; }
        public bool IsReadOnly
        {
            get { return isReadOnly; }
            set
            {
                isReadOnly = value;
                DisplayMode(); // Cập nhật trạng thái của control khi thuộc tính thay đổi
            }
        }
        private void DisplayMode()
        {
            if (IsReadOnly)
            {
                label1.Text = "From";
                button1.Visible = false;
                button1.Enabled = false;
                label3.Text = "Messager to you"; 
                guna2DateTimePicker1.Enabled = false;   
            }
        }
        public void LoadMail(string username, string macv)
        {
            ClassDAL dal = new ClassDAL();
            ClassBLL objbll = new ClassBLL();
            //string username = dal.GetUsername();
            string query = "Select * from Mail where [Username] = '" + username + "'  ";
          
            DataTable dt = objbll.GetItems(query);
            DataRow[] rows = dt.Select("[Ma cong viec] = '" +macv+ "' ");
            dt = objbll.GetItems(query);
            if (rows.Length > 0)
            {
                DataRow row = rows[0];                
                Noidung = row["Noidung"].ToString();
                Henlich = row["Hen lich"].ToString();
                if (UserRole == "Employee")
                    Username = row["Owner"].ToString();
                else
                    Username = row["Username"].ToString();

            }
        }
        //btn exit
        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
