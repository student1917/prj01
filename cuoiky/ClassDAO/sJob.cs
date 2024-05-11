using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace cuoiky.ClassDAO
{
    public class sJob
    {
        Image img;
        string tencongviec;
        string tencongty;
        int mucluong;
        string diadiem;
        string macv;
        

        public sJob(Image img, string tencongviec, string tencongty, int mucluong, string diadiem, string macv)
        {
            this.img = img;
            this.tencongviec = tencongviec;
            this.tencongty = tencongty;
            this.mucluong = mucluong;
            this.diadiem = diadiem;
            this.macv = macv;
        }

        public Image Img { get => img; set => img = value; }
        public string Tencongviec { get => tencongviec; set => tencongviec = value; }
        public string Tencongty { get => tencongty; set => tencongty = value; }
        public int Mucluong { get => mucluong; set => mucluong = value; }
        public string Diadiem { get => diadiem; set => diadiem = value; }
        public string Macv { get => macv; set => macv = value; }    

    }
}
