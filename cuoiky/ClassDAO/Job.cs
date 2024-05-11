using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace cuoiky
{
    public class Job
    {
        Image img;
        string tencongviec;
        string tencongty;
        int mucluong;
        string diadiem;
        string nganhnghe;
        string chucvu;
        string loaihinh;
        string ngaydang;
        string chitiet;
        string gioithieucty;
        string macv;
        string usernamerecruiter;
        string trangthai;

        public Job(Image img, string tencongviec, string tencongty, int mucluong, string diadiem, string nganhnghe, string chucvu, string loaihinh, string ngaydang, string chitiet, 
            string gioithieucty, string macv, string usernamerecruiter, string trangthai)
        {
            this.img = img;
            this.tencongviec = tencongviec;
            this.tencongty = tencongty;
            this.mucluong = mucluong;
            this.diadiem = diadiem;
            this.nganhnghe = nganhnghe;
            this.chucvu = chucvu;
            this.loaihinh = loaihinh;
            this.ngaydang = ngaydang;
            this.chitiet = chitiet;
            this.gioithieucty = gioithieucty;
            this.macv = macv;
            this.usernamerecruiter = usernamerecruiter;
            this.trangthai = trangthai;
        }

        public Image Img { get => img; set => img = value; }
        public string Tencongviec { get => tencongviec; set => tencongviec = value; }
        public string Tencongty { get => tencongty; set => tencongty = value; }
        public int Mucluong { get => mucluong; set => mucluong = value; }
        public string Diadiem { get => diadiem; set => diadiem = value; }
        public string Nganhnghe { get => nganhnghe; set => nganhnghe = value; }
        public string Chucvu { get => chucvu; set => chucvu = value; }
        public string Loaihinh { get => loaihinh; set => loaihinh = value; }
        public string Ngaydang { get => ngaydang; set => ngaydang = value; }
        public string Chitiet { get => chitiet; set => chitiet = value; }
        public string Gioithieucty { get => gioithieucty; set => gioithieucty = value; }
        public string Macv { get => macv; set => macv = value; }
        public string Usernamerecruiter { get => usernamerecruiter; set => usernamerecruiter = value; }
        public string Trangthai { get => trangthai; set => trangthai = value; }
    }
}
