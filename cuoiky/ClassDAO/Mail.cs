using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cuoiky.ClassDAO
{
    public class Mail
    {
        string usernamee;
        string usernamer;
        string noidung;
        string ngaygui;
        string macv;
        string henlich;
        public Mail(string usernamee, string usernamer, string noidung, string ngaygui, string macv, string henlich)
        {
            this.usernamee = usernamee;
            this.usernamer = usernamer;
            this.noidung = noidung;
            this.ngaygui = ngaygui;
            this.macv = macv;   
            this.henlich = henlich;
        }   
        public string Usernamee { get =>  usernamee; set => usernamee = value;}
        public string Usernamer { get => usernamer; set => usernamer = value;}  
        public string Noidung { get => noidung; set => noidung = value;}
        public string Ngaygui { get => ngaygui; set => ngaygui = value;}    
        public string Macv { get => macv; set => macv = value; }
        public string Henlich { get => henlich; set => henlich = value;}    
    }
}
