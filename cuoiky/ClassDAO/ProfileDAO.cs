using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace cuoiky.DAL
{
    public class ProfileDAO
    {
        Image img;
        string hoten;
        string gioitinh;
        string ngaysinh;
        string sdt;
        string email;
        string zlfb;
        string diachi;
        string hocvan;
        string kynang;
        string kinhnghiem;
        string mongmuon;
        string username;

        public ProfileDAO(Image img, string hoten, string gioitinh, string ngaysinh, string sdt, string email, string zlfb, string diachi, string hocvan, string kynang, string kinhnghiem, string mongmuon, string username)
        {
            this.img = img;
            this.hoten = hoten;
            this.gioitinh = gioitinh;
            this.ngaysinh = ngaysinh;
            this.sdt = sdt;
            this.email = email;
            this.zlfb = zlfb;
            this.diachi = diachi;
            this.hocvan = hocvan;
            this.kynang = kynang;
            this.kinhnghiem = kinhnghiem;
            this.mongmuon = mongmuon;
            this.username = username;
        }

        public Image Img
        {
            get => img;
            set => img = value;
        }

        public string Hoten 
        {
            get => hoten;
            set => hoten = value;
        }

        public string Gioitinh
        {
            get => gioitinh;
            set => gioitinh = value;
        }

        public string Ngaysinh
        {
            get => ngaysinh;
            set => ngaysinh = value;
        }

        public string Sdt
        {
            get => sdt;
            set => sdt = value;
        }

        public string Email
        {
            get => email;
            set => email = value;
        }

        public string Zlfb
        {
            get => zlfb;
            set => zlfb = value;
        }

        public string Diachi
        {
            get => diachi;
            set => diachi = value;
        }

        public string Hocvan
        {
            get => hocvan;
            set => hocvan = value;
        }

        public string Kynang
        {
            get => kynang;
            set => kynang = value;
        }

        public string Kinhnghiem
        {
            get => kinhnghiem;
            set => kinhnghiem = value;
        }

        public string Mongmuon
        {
            get => mongmuon;
            set => mongmuon = value;
        }

        public string Username
        {
            get => username;
            set => username = value;
        }
    }
}
