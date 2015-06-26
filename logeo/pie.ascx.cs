using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace logeo
{
    public partial class pie : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["prestador"].ToString() != "")
            {
                return;
            }

            Label1.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
    }
}