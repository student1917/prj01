using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace cuoiky
{
    public class Company
    {
        Image img;
        string tencongty;
        string masothue;       
        string nguoidungdau;
        Image gpkd;
        string trusochinh;
        string chinhanh;
        string gioithieucty;
        string username;

        public Company(Image img, string tencongty, string masothue, string nguoidungdau, Image gpkd, string trusochinh, string chinhanh, string gioithieucty, string username)
        {
            this.img = img;
            this.tencongty = tencongty;
            this.masothue = masothue;          
            this.nguoidungdau = nguoidungdau;
            this.gpkd = gpkd;
            this.trusochinh = trusochinh;
            this.chinhanh = chinhanh; 
            this.gioithieucty = gioithieucty;
            this.username = username;
        }

        public Image Img { get => img; set => img = value; }
        public string Tencongty { get => tencongty; set => tencongty = value; }
        public string Masothue { get => masothue; set => masothue = value; }    
        public string Nguoidungdau { get => nguoidungdau; set => nguoidungdau = value; }
        public Image Gpkd { get => gpkd; set => gpkd = value; }
        public string Trusochinh { get => trusochinh; set => trusochinh = value; }
        public string Chinhanh { get => chinhanh; set => chinhanh = value; }
        public string Gioithieucty { get => gioithieucty; set => gioithieucty = value; }
        public string Username { get => username; set => username = value; }    
    }
}
    

