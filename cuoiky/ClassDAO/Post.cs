using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cuoiky.ClassDAO
{
    public class Post
    {
        Image img;
        string username;
        string noidung;
        string ngaydang;
        public Post(Image img, string username, string noidung, string ngaydang)
        {
            this.img = img;
            this.username = username;
            this.noidung = noidung;
            this.ngaydang = ngaydang;
        }
        public string Username { get => username; set => username = value; }
        public string Noidung { get => noidung; set => noidung = value; }
        public string Ngaydang { get => ngaydang; set => ngaydang = value; }    
        public Image Img { get => img; set => img = value; }
    }
}
