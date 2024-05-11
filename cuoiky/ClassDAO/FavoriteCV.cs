using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace cuoiky.ClassDAO
{
    public class FavoriteCV
    {
        string usernamee;
        string usernamer;
        string ngayghim;
        string hoten;
        Image img;
        public FavoriteCV(string usernamee, string usernamer, string ngayghim, string hoten, Image img)
        {
            this.usernamee = usernamee; 
            this.ngayghim = ngayghim;
            this.usernamer = usernamer;
            this.hoten = hoten; 
            this.img = img;
        }
        public string Usernamee { get =>  usernamee; set => usernamee = value; }
        public string Usernamer { get => usernamer; set => usernamer = value; }  
        public string Ngayghim { get => ngayghim; set => ngayghim = value; }  
        public string Hoten { get => hoten; set => hoten = value;  }
        public Image Img { get => img; set => img = value; }
    }
}
