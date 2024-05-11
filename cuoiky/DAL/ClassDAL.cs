using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Windows.Markup;
using System.Runtime.CompilerServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Security.Cryptography;
using System.Windows.Media;
using System.Linq.Expressions;
using System.Windows.Forms;
using System.Reflection.Emit;
using cuoiky.BLL;
using FontAwesome.Sharp;
using cuoiky.ClassDAO;
using System.Windows.Interop;
using static TheArtOfDevHtmlRenderer.Adapters.RGraphicsPath;
using System.Web.UI.WebControls;
namespace cuoiky.DAL
{
    internal class ClassDAL
    {
        //Add Job to Table
        public bool AddJobToTable(Job job)
        {
            ketnoi kn = new ketnoi();
            if (ConnectionState.Closed == kn.connect.State)
            {
                kn.connect.Open();
            }
            string query = "INSERT INTO Job ([Ten cong viec], [Ten cong ty], [Nganh nghe], [Chuc vu], [Loai hinh], [Muc luong], [Dia diem], [Ngay dang], [Chi tiet], [Gioi thieu cong ty], [Ma cong viec], [Username recruiter], [Trang thai]) " +
                "VALUES (@Tencongviec, @Tencongty, @Nganhnghe, @Chucvu, @Loaihinh, @Mucluong, @Diadiem, @Ngaydang, @Chitiet, @Gioithieucty, @Macv, @Username, @Trangthai)";
            try
            {
                using (SqlCommand cmd = new SqlCommand(query, kn.connect))
                {
                    //MemoryStream ms = new MemoryStream();
                    //job.Img.Save(ms, job.Img.RawFormat);
                    //cmd.Parameters.AddWithValue("@Anh", ms.ToArray());
                    cmd.Parameters.AddWithValue("@Tencongviec", job.Tencongviec);
                    cmd.Parameters.AddWithValue("@Tencongty", job.Tencongty);
                    cmd.Parameters.AddWithValue("@Nganhnghe", job.Nganhnghe);
                    cmd.Parameters.AddWithValue("@Chucvu", job.Chucvu);
                    cmd.Parameters.AddWithValue("@Loaihinh", job.Loaihinh);
                    cmd.Parameters.AddWithValue("@Mucluong", job.Mucluong);
                    cmd.Parameters.AddWithValue("@Diadiem", job.Diadiem);
                    cmd.Parameters.AddWithValue("@Ngaydang", job.Ngaydang);
                    cmd.Parameters.AddWithValue("@Chitiet", job.Chitiet);
                    cmd.Parameters.AddWithValue("@Gioithieucty", job.Gioithieucty);
                    cmd.Parameters.AddWithValue("@Macv", job.Macv);
                    cmd.Parameters.AddWithValue("@Username", job.Usernamerecruiter);
                    cmd.Parameters.AddWithValue("@Trangthai", job.Trangthai);
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch
            {
                throw;
            }
        }
        //Update Job
        public bool UpdateJobToTable(Job job)
        {
            ketnoi kn = new ketnoi();
            if (ConnectionState.Closed == kn.connect.State)
            {
                kn.connect.Open();
            }
            string query = "UPDATE Job SET [Ten cong viec] = @Tencongviec, [Ten cong ty] = @Tencongty, [Nganh nghe] = @Nganhnghe, [Chuc vu] = @Chucvu," +
                " [Loai hinh] = @Loaihinh, [Muc luong] = @Mucluong, [Dia diem] = @Diadiem, [Ngay dang] = @Ngaydang, [Chi tiet] = @Chitiet, [Gioi thieu cong ty] = @Gioithieucty," +
                "[Username recruiter] = @Username, [Trang thai] = @Trangthai WHERE [Ma cong viec] = @Macv";
            try
            {
                using (SqlCommand cmd = new SqlCommand(query, kn.connect))
                {
                    //MemoryStream ms = new MemoryStream();
                    //job.Img.Save(ms, job.Img.RawFormat);
                    //cmd.Parameters.AddWithValue("@Anh", ms.ToArray());
                    cmd.Parameters.AddWithValue("@Tencongviec", job.Tencongviec);
                    cmd.Parameters.AddWithValue("@Tencongty", job.Tencongty);
                    cmd.Parameters.AddWithValue("@Nganhnghe", job.Nganhnghe);
                    cmd.Parameters.AddWithValue("@Chucvu", job.Chucvu);
                    cmd.Parameters.AddWithValue("@Loaihinh", job.Loaihinh);
                    cmd.Parameters.AddWithValue("@Mucluong", job.Mucluong);
                    cmd.Parameters.AddWithValue("@Diadiem", job.Diadiem);
                    cmd.Parameters.AddWithValue("@Ngaydang", job.Ngaydang);
                    cmd.Parameters.AddWithValue("@Chitiet", job.Chitiet);
                    cmd.Parameters.AddWithValue("@Gioithieucty", job.Gioithieucty);
                    cmd.Parameters.AddWithValue("@Macv", job.Macv);
                    cmd.Parameters.AddWithValue("@Username", job.Usernamerecruiter);
                    cmd.Parameters.AddWithValue("@Trangthai", job.Trangthai);
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch
            {
                throw;
            }
        }
    
        //Add Profile to Table        
        public bool AddProfileToTable (ProfileDAO pf)
        {
            ketnoi kn = new ketnoi();
            if (ConnectionState.Closed == kn.connect.State)
            {
                kn.connect.Open();
            }
            string querry = "INSERT INTO Profile ([Ho ten], [Gioi tinh], [Ngay sinh], [So dien thoai], [Email], [Zalofb], [Dia chi], [Hoc van], [Ky nang], [Kinh nghiem], [Mong muon], [Username], [Anh]) " +
               "VALUES (@HoTen, @GioiTinh, @NgaySinh, @SoDienThoai, @Email, @ZaloFb, @DiaChi, @HocVan, @KyNang, @KinhNghiem, @MongMuon, @Username, @Anh)";
            try
            {
                using (SqlCommand cmd = new SqlCommand(querry, kn.connect))
                {
                   
                    cmd.Parameters.AddWithValue("@HoTen", pf.Hoten);
                    cmd.Parameters.AddWithValue("@GioiTinh", pf.Gioitinh);
                    cmd.Parameters.AddWithValue("@NgaySinh", pf.Ngaysinh);
                    cmd.Parameters.AddWithValue("@SoDienThoai", pf.Sdt);
                    cmd.Parameters.AddWithValue("@Email", pf.Email);
                    cmd.Parameters.AddWithValue("@ZaloFb", pf.Zlfb);
                    cmd.Parameters.AddWithValue("@DiaChi", pf.Diachi);
                    cmd.Parameters.AddWithValue("@HocVan", pf.Hocvan);
                    cmd.Parameters.AddWithValue("@KyNang", pf.Kynang);
                    cmd.Parameters.AddWithValue("@KinhNghiem", pf.Kinhnghiem);
                    cmd.Parameters.AddWithValue("@MongMuon", pf.Mongmuon);
                    cmd.Parameters.AddWithValue("@Username", pf.Username);
                    MemoryStream ms = new MemoryStream();
                    pf.Img.Save(ms, pf.Img.RawFormat);
                    cmd.Parameters.AddWithValue("@Anh", ms.ToArray());
                    cmd.ExecuteNonQuery();

                }
                return true;
            }
            catch
            {
                throw;
            }
        }
        //Update Profile to Table       
        public bool UpdateProfileToTable(ProfileDAO pf)
        {
            ketnoi kn = new ketnoi();
            if (ConnectionState.Closed == kn.connect.State)
            {
                kn.connect.Open();
            }
            string querry = "UPDATE Profile SET[Ho ten] = @HoTen, [Gioi tinh] = @GioiTinh, [Ngay sinh] = @NgaySinh, [So dien thoai] = @SoDienThoai, [Email] = @Email, [Zalofb] = @ZaloFb, " +
                "[Dia chi] = @DiaChi, [Hoc van] = @HocVan, [Ky nang] = @KyNang, [Kinh nghiem] = @KinhNghiem, [Mong muon] = @MongMuon, [Anh] = @Anh WHERE[Username] = @Username";
            try
            {
                using (SqlCommand cmd = new SqlCommand(querry, kn.connect))
                {
                    
                    cmd.Parameters.AddWithValue("@HoTen", pf.Hoten);
                    cmd.Parameters.AddWithValue("@GioiTinh", pf.Gioitinh);
                    cmd.Parameters.AddWithValue("@NgaySinh", pf.Ngaysinh);
                    cmd.Parameters.AddWithValue("@SoDienThoai", pf.Sdt);
                    cmd.Parameters.AddWithValue("@Email", pf.Email);
                    cmd.Parameters.AddWithValue("@ZaloFb", pf.Zlfb);
                    cmd.Parameters.AddWithValue("@DiaChi", pf.Diachi);
                    cmd.Parameters.AddWithValue("@HocVan", pf.Hocvan);
                    cmd.Parameters.AddWithValue("@KyNang", pf.Kynang);
                    cmd.Parameters.AddWithValue("@KinhNghiem", pf.Kinhnghiem);
                    cmd.Parameters.AddWithValue("@MongMuon", pf.Mongmuon);
                    cmd.Parameters.AddWithValue("@Username", pf.Username);
                    MemoryStream ms = new MemoryStream();
                    pf.Img.Save(ms, pf.Img.RawFormat);
                    cmd.Parameters.AddWithValue("@Anh", ms.ToArray());
                    cmd.ExecuteNonQuery();

                }
                return true;
            }
            catch
            {
                throw;
            }
        }

        //Add Company to Table
        public bool AddCompanyToTable(Company cmp)
        {
            ketnoi kn = new ketnoi();
            if (ConnectionState.Closed == kn.connect.State)
            {
                kn.connect.Open();
            }
            string query = "INSERT INTO Company ([Ten cong ty], [Ma so thue], [Nguoi dung dau], [Tru so chinh], [Chi nhanh], [Gioi thieu cong ty], [Giay phep kinh doanh], [Anh], [Username]) VALUES" +
                 "(@Ten, @MaSoThue, @NguoiDungDau, @TruSoChinh, @ChiNhanh, @GioiThieuCTY, @GiayPhep, @Anh, @Username)";
            try
            {
                using (SqlCommand cmd = new SqlCommand(query, kn.connect))
                {
                    cmd.Parameters.AddWithValue("@Ten", cmp.Tencongty);
                    cmd.Parameters.AddWithValue("@MaSoThue", cmp.Masothue);
                    cmd.Parameters.AddWithValue("@NguoiDungDau", cmp.Nguoidungdau);
                    cmd.Parameters.AddWithValue("@TruSoChinh", cmp.Trusochinh);
                    cmd.Parameters.AddWithValue("@ChiNhanh", cmp.Chinhanh);
                    cmd.Parameters.AddWithValue("@GioiThieuCTY", cmp.Gioithieucty);
                    cmd.Parameters.AddWithValue("@Username", cmp.Username);
                    MemoryStream ms = new MemoryStream();
                    cmp.Img.Save(ms, cmp.Img.RawFormat);
                    cmd.Parameters.AddWithValue("@Anh", ms.ToArray());
                    MemoryStream ms1 = new MemoryStream();
                    cmp.Gpkd.Save(ms1, cmp.Gpkd.RawFormat);
                    cmd.Parameters.AddWithValue("@GiayPhep", ms1.ToArray());
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch
            {
                throw;
            }            
        }
        //Update Company to Table
        public bool UpdateCompanyToTable(Company cmp)
            {
            ketnoi kn = new ketnoi();
            if (ConnectionState.Closed == kn.connect.State)
            {
                kn.connect.Open();
            }
            string query = "UPDATE Company SET [Ten cong ty] = @Ten, [Ma so thue] = @MaSoThue, [Nguoi dung dau] = @NguoiDungDau, " +
               "[Tru so chinh] = @TruSoChinh, [Chi nhanh] = @ChiNhanh, [Gioi thieu cong ty] = @GioiThieuCTY, " +
               "[Giay phep kinh doanh] = @GiayPhep, [Anh] = @Anh WHERE Username = @Username";
            try
            {
                using (SqlCommand cmd = new SqlCommand(query, kn.connect))
                {
                    cmd.Parameters.AddWithValue("@Ten", cmp.Tencongty);
                    cmd.Parameters.AddWithValue("@MaSoThue", cmp.Masothue);
                    cmd.Parameters.AddWithValue("@NguoiDungDau", cmp.Nguoidungdau);
                    cmd.Parameters.AddWithValue("@TruSoChinh", cmp.Trusochinh);
                    cmd.Parameters.AddWithValue("@ChiNhanh", cmp.Chinhanh);
                    cmd.Parameters.AddWithValue("@GioiThieuCTY", cmp.Gioithieucty);
                    cmd.Parameters.AddWithValue("@Username", cmp.Username);
                    MemoryStream ms = new MemoryStream();
                    cmp.Img.Save(ms, cmp.Img.RawFormat);
                    cmd.Parameters.AddWithValue("@Anh", ms.ToArray());
                    MemoryStream ms1 = new MemoryStream();
                    cmp.Gpkd.Save(ms1, cmp.Gpkd.RawFormat);
                    cmd.Parameters.AddWithValue("@GiayPhep", ms1.ToArray());
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch
            {
                throw;
            }

        }
        //Add Post to Table
        public bool AddPostToTable(Post p)
        {
            ketnoi kn = new ketnoi();
            if (ConnectionState.Closed == kn.connect.State)
            {
                kn.connect.Open();
            }
            string query = "INSERT INTO HomePost ([Username], [Noi dung], [Ngay dang], [Anh]) VALUES (@Username, @Text, @NgayDang, @Anh)";
            try
            {
                using (SqlCommand cmd = new SqlCommand(query, kn.connect))
                {
                    cmd.Parameters.AddWithValue("@Username", p.Username);
                    cmd.Parameters.AddWithValue("@Text", p.Noidung);
                    cmd.Parameters.AddWithValue("@NgayDang", p.Ngaydang);
                    MemoryStream ms = new MemoryStream();
                    p.Img.Save(ms, p.Img.RawFormat);
                    cmd.Parameters.AddWithValue("@Anh", ms.ToArray());


                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch
            {
                throw;
            }
           
        }
        //Update Post to Table
        public bool UpdatePostToTable(Post p)
        {
            ketnoi kn = new ketnoi();
            if (ConnectionState.Closed == kn.connect.State)
            {
                kn.connect.Open();
            }
            string query = "UPDATE HomePost SET [Text] = @Text, [Ngay dang] = @NgayDang, [Anh] = @Anh WHERE [Username] = @Username";
            try
            {
                using (SqlCommand cmd = new SqlCommand(query, kn.connect))
                {
                    cmd.Parameters.AddWithValue("@Text", p.Noidung);
                    cmd.Parameters.AddWithValue("@NgayDang", p.Ngaydang);
                    MemoryStream ms = new MemoryStream();
                    p.Img.Save(ms, p.Img.RawFormat);
                    cmd.Parameters.AddWithValue("@Anh", ms.ToArray());
                    cmd.Parameters.AddWithValue("@Username", p.Username);
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch
            {
                throw;
            }
        }
        //Add Mail to Table
        public bool AddMailToTable(Mail m)
        {
            ketnoi kn = new ketnoi();
            if (ConnectionState.Closed == kn.connect.State)
            {
                kn.connect.Open();
            }
            string query = "Insert into Mail([Owner], [Username], [Noidung], [Ngay gui], [Ma cong viec], [Hen lich]) values (@Owner, @Username, @Noidung, @Ngaygui, @Macv, @Henlich)";
            try
            {
                using (SqlCommand cmd = new SqlCommand(query, kn.connect))
                {
                    cmd.Parameters.AddWithValue("@Owner", m.Usernamer); 
                    cmd.Parameters.AddWithValue("@Username", m.Usernamee);
                    cmd.Parameters.AddWithValue("@Noidung", m.Noidung);
                    cmd.Parameters.AddWithValue("@Ngaygui", m.Ngaygui);
                    cmd.Parameters.AddWithValue("@Macv", m.Macv);
                    cmd.Parameters.AddWithValue("@Henlich", m.Henlich);
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch
            {
                throw;
            }
        }

        //Update Mail to Table 
        public bool UpdateMailToTable(Mail m)
        {
            ketnoi kn = new ketnoi();
            if (ConnectionState.Closed == kn.connect.State)
            {
                kn.connect.Open();
            }
            string query = "UPDATE Mail SET [Owner] = @Owner, [Noidung] = @Noidung, [Ngay gui] = @Ngaygui, [Hen lich] = @Henlich" +
                " WHERE [Username] = @Username and [Ma cong viec] = @Macv";
            try
            {
                using (SqlCommand cmd = new SqlCommand(query, kn.connect))
                {
                    cmd.Parameters.AddWithValue("@Owner", m.Usernamer);
                    cmd.Parameters.AddWithValue("@Username", m.Usernamee);
                    cmd.Parameters.AddWithValue("@Noidung", m.Noidung);
                    cmd.Parameters.AddWithValue("@Ngaygui", m.Ngaygui);
                    cmd.Parameters.AddWithValue("@Macv", m.Macv);
                    cmd.Parameters.AddWithValue("@Henlich", m.Henlich);
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch
            {
                throw;
            }
        }
        //Read Items to Table
        public DataTable ReadItemsTable(string query)
        {
            ketnoi kn = new ketnoi();
            if (ConnectionState.Closed == kn.connect.State)
            {
                kn.connect.Open();
            }
            //string query = "select * from Job";
            SqlCommand cmd  = new SqlCommand(query, kn.connect);
            try
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    return dt;
                }
            }
            catch
            {
                throw;
            }
        }
        //Thuc thi
        public void ThucThi(String sql)
        {
            ketnoi kn = new ketnoi();
            try
            {
                // Ket noi
                kn.connect.Open();
                SqlCommand cmd = new SqlCommand(sql, kn.connect);
                if (cmd.ExecuteNonQuery() > 0)
                    MessageBox.Show("Success!");
            }
            catch 
            {
                MessageBox.Show("Error");
            }
            finally
            {
                kn.connect.Close();
            }
        }
        //Bool Thuc Thi
        public bool ThucThi1(String sql)
        {
            ketnoi kn = new ketnoi();
            try
            {
                // Ket noi
                kn.connect.Open();
                SqlCommand cmd = new SqlCommand(sql, kn.connect);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
                else
                    return false;
            }
            catch
            {
                throw;
            }
            finally
            {
                kn.connect.Close();
            }
        }
        //Get data
        public string GetData(string query)
        {
            string result = null;
            ketnoi kn = new ketnoi();
            kn.connect.Open();
            using (SqlCommand cmd = new SqlCommand(query, kn.connect))
            {
                result = cmd.ExecuteScalar()?.ToString();
            }
            return result;       
        }
        // Get count
        public int GetCount(string query)
        {
            int count = 0;
            ketnoi kn = new ketnoi();
            kn.connect.Open();
            using (SqlCommand cmd = new SqlCommand(query, kn.connect))
            {
                count = (int)cmd.ExecuteScalar();
            }
            return count;
        }
        //Get user role
        public string GetUserRole(string username)
        {
            string role = "";
            ketnoi kn = new ketnoi();
            kn.connect.Open();
            string query = "Select [As] from Login where Username = '" +username+ "' ";
            SqlCommand cmd = new SqlCommand(query, kn.connect);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    role = reader["As"].ToString();
                }
                else
                {
                    role = "Loi";
                }
            }

            return role;
        }
        //Get current username
        public string GetUsername()
        {
            string username = "";
            Form form = Application.OpenForms["Form1"];
            if (form != null && form is Form1)
            {
                Form1 form1 = (Form1)form;
                username = form1.Username;
            }
            return username;
        }
        //Get username avatar
        public Bitmap GetImage( string query)
        {
            Bitmap img = null;
            //Image imgCopy = null;
            ketnoi kn = new ketnoi();
            kn.connect.Open();
            //string query = "Select [Anh] from Profile where Username = '" + username + "'";            
            using (SqlCommand cmd = new SqlCommand(query, kn.connect))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        if (!reader.IsDBNull(0))  // Kiểm tra xem dữ liệu hình ảnh có null không
                        {
                           img = new Bitmap(new MemoryStream((byte[])reader["Anh"]));                        
                           
                        }
                    }
                }
               
            }
            return img;
        }
        //Loadcompany  (dung trong ucfindjob va ucRecruiter)
        public UCBusiness LoadComPany(string query)
        {
            Company company = GetCompany(query);
            UCBusiness business = new UCBusiness(company);
            return business;
        }
        //Get company
        public Company GetCompany(string query)
        {
            ClassBLL objbll = new ClassBLL();
            //string query = "Select * from Company where [Username] ='" + usernameRecruiter + "' ";
            DataTable dt = objbll.GetItems(query);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    Company company = new Company(
                            new Bitmap(new MemoryStream((byte[])row["Anh"])),
                            row["Ten cong ty"].ToString(),
                            row["Ma so thue"].ToString(),
                            row["Nguoi dung dau"].ToString(),
                            new Bitmap(new MemoryStream((byte[])row["Giay phep kinh doanh"])),
                            row["Tru so chinh"].ToString(),
                            row["Chi nhanh"].ToString(),
                            row["Gioi thieu cong ty"].ToString(),
                            row["Username"].ToString()
                    );
                    return company;
                }
                return null;
            }
            return null;
        }
        //
        public bool isOwner { get; set; }
        //xac dinh chu so huu
        public void DetermineOwnership(string username, IconButton iconButton)
        {
            ClassDAL dal = new ClassDAL();
            string currentusername = dal.GetUsername();
            if (currentusername == username)
                isOwner = true;
            else if (currentusername != username)
                isOwner = false;
            if (isOwner)
            {
                iconButton.Enabled = true;
                iconButton.Visible = true;
            }
            else
            {
                iconButton.Enabled = false;
                iconButton.Visible = false;
            }
        }


    }
    }
