using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace cuoiky.ClassDAO
{
    public class PostedJob
    {
        Image img;
        string tencongviec;
        string macv;
        int sluong;
        string trangthai;
        public PostedJob(Image img, string tencongviec, string macv, int sluong, string trangthai)
        {
            this.img = img;
            this.tencongviec = tencongviec;
            this.macv = macv;
            this.sluong = sluong;
            this.trangthai = trangthai;
        }   
        public Image Img {  get =>  img; set => img = value; }  
        public string Tencongviec { get => tencongviec; set => tencongviec = value; }
        public string Macv { get => macv; set => macv = value; }
        public int Sluong { get => sluong; set => sluong = value; }
        public string Trangthai { get => trangthai; set => trangthai = value; }
    }
}
