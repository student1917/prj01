using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using cuoiky.DAL;
using System.Drawing;
using System.Data;
using System.Runtime.CompilerServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using cuoiky.ClassDAO;
namespace cuoiky.BLL
{
    internal class ClassBLL
    {       
      

        //Save Job
        public bool SaveJob(Job job)
        {
            try
            {
                ClassDAL objdal = new ClassDAL();
                return objdal.AddJobToTable(job);
            }
            catch (Exception e)
            {
                DialogResult result = MessageBox.Show(e.Message.ToString());
                return false;
            }
        }
        //Update Job
        public bool UpdateJob(Job job)
        {
            try
            {
                ClassDAL objdal = new ClassDAL();
                return objdal.UpdateJobToTable(job);
            }
            catch (Exception e)
            {
                DialogResult result = MessageBox.Show(e.Message.ToString());
                return false;
            }
        }
        //Save Profile
      
        public bool SaveProfile(ProfileDAO pf)
        {
            try
            {
                ClassDAL objdal = new ClassDAL();               
                return objdal.AddProfileToTable(pf);
            }
            catch (Exception e)
            {
                DialogResult result = MessageBox.Show(e.Message.ToString());
                return false;
            }
        }
        //Update Profile 
      
        public bool UpdateProfile(ProfileDAO pf)
        {
            try
            {
                ClassDAL objdal = new ClassDAL();               
                return (objdal.UpdateProfileToTable(pf));
            }
            catch (Exception e)
            {
                DialogResult result = MessageBox.Show(e.Message.ToString());
                return false;
            }
        }
        //Save Company
        public bool SaveCompany(Company cmp)
        {
            try
            {
                ClassDAL objdal = new ClassDAL();
                return objdal.AddCompanyToTable(cmp);
            }
            catch (Exception e)
            {
                DialogResult result = MessageBox.Show(e.Message.ToString());
                return false;
            }
        }
        //Update Company
        public bool UpdateCompany(Company cmp)
        {
            try
            {
                ClassDAL objdal = new ClassDAL();
                return objdal.UpdateCompanyToTable(cmp);
            }
            catch (Exception e)
            {
                DialogResult result = MessageBox.Show(e.Message.ToString());
                return false;
            }
        }
        //Save Post
        public bool SavePost(Post p)
        {
            try
            {
                ClassDAL objdal = new ClassDAL();
                return objdal.AddPostToTable(p);
            }
            catch (Exception e)
            {
                DialogResult result = MessageBox.Show(e.Message.ToString());
                return false;
            }
        }
        //Update Post
        public bool UpdatePost(Post p)
        {
            try
            {
                ClassDAL objdal = new ClassDAL();
                return objdal.UpdatePostToTable(p);
            }
            catch (Exception e)
            {
                DialogResult result = MessageBox.Show(e.Message.ToString());
                return false;
            }
        }
        //Save Mail
        public bool SaveMail(Mail m)
        {
            try
            {
                ClassDAL objdal = new ClassDAL();
                return objdal.AddMailToTable(m);
            }
            catch (Exception e)
            {
                DialogResult result = MessageBox.Show(e.Message.ToString());
                return false;
            }
        }
        //Update Mail
        public bool UpdateMail(Mail m)
        {
            try
            {
                ClassDAL objdal = new ClassDAL();
                return objdal.UpdateMailToTable(m);
            }
            catch (Exception e)
            {
                DialogResult result = MessageBox.Show(e.Message.ToString());
                return false;
            }
        }
        //Get Items
        public DataTable GetItems(string query)
        {
            try
            {
                ClassDAL objdal = new ClassDAL();
                return objdal.ReadItemsTable(query);

            }
            catch (Exception e ) 
            {
                DialogResult result = MessageBox.Show(e.Message.ToString());
                return null;
            }
        }
        
    }
}
