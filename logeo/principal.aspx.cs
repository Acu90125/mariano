using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using logeo.entidades;
using System.Resources;
using System.Windows.Forms;


namespace logeo
{
    public partial class principal : System.Web.UI.Page
    {
        Entidades Ent = new Entidades();
        ConexionBd_Operaciones conection = new ConexionBd_Operaciones();

        protected void Page_Load(object sender, EventArgs e)
        {

            Ent.Ident = (int)(Session["prestador"]);
            Label1.Text = Convert.ToString(Session["nombreprestador"]);
        }
    }
}