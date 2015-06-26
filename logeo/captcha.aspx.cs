using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Design;


namespace logeo
{
    public partial class captcha : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(140, 30);
            Graphics gp = Graphics.FromImage(bmp);
            gp.Clear(Color.White);
            Font ft = new Font("verdana", 14, FontStyle.Regular);
            string str = getcapt();
            Session.Add("str", str);
            gp.DrawString(str, ft, Brushes.Green, 2, 2);
            Response.ContentType = "image/GIF";
            bmp.Save(Response.OutputStream, ImageFormat.Gif);
            bmp.Dispose();
            gp.Dispose();
            ft.Dispose();

        }
        public string getcapt()
        {
            string allowedchars = ""; // van letras may
            allowedchars += "";     //  van letras minus
            allowedchars += "2,3,4,5,6,7,8,9";
            char[] sep = { ',' };
            string[] arr = allowedchars.Split(sep);
            string passwordchars = "";
            string temp;
            Random rmd = new Random();
            int i;
            for (i = 0; i <= 5; i++)
            {
                temp = arr[rmd.Next(0, arr.Length)];
                passwordchars += temp;
            }
            return passwordchars;
        }

    }
}