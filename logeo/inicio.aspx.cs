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
    public partial class inicio : System.Web.UI.Page
    {
        Entidades Ent = new Entidades();
        ConexionBd_Operaciones conection = new ConexionBd_Operaciones();


        protected void Page_Load(object sender, EventArgs e)
        {

            Ent.Ident = (int)(Session["prestador"]);

            if (!IsPostBack)                                        //   es la primera vez que cargo la pagina 
            // agrego esto porque sino en cada seleccion del combo se recarga la pagina
            // y vuelve a selected value = 0
            {
                centro.DataSource = ObtenerCentro();
                centro.DataValueField = "IdentCentro";
                centro.DataTextField = "Nombrecentro";
                centro.DataBind();
                centro.Items.Insert(0, new ListItem("seleccione el Centro", ""));
                centro.SelectedIndex = 0;
            }

            // recupero el nombre de session prestador
            Label1.Text = Convert.ToString(Session["nombreprestador"]);


            using (ResXResourceSet resx = new ResXResourceSet("C:\\punto.net\\logeo\\logeo\\App_GlobalResources\\Resources ar-ES.resx"))
            {

                this.Label2.Text = resx.GetString("InicioLabel");

            }
            // obtener parametro 21 
            SqlConnection dbconn21 = ConexionBd_Operaciones.ObtenerConexion();

            SqlCommand msc21 = new SqlCommand("dbo.ObtenerParametro", dbconn21);
            //parametros de entrada           
            msc21.Parameters.AddWithValue("@parametro", 21);
            //parametros de salida
            msc21.Parameters.Add("@valor", SqlDbType.VarChar, 120);
            msc21.Parameters["@valor"].Direction = ParameterDirection.Output;
            try
            {
                if (dbconn21.State == ConnectionState.Closed)
                    dbconn21.Open();
                msc21.CommandType = CommandType.StoredProcedure;
                msc21.ExecuteNonQuery();
                string valorfila21 = msc21.Parameters["@valor"].Value.ToString();
                if (valorfila21 == "SI")
                {
                    si.Visible = true;
                    no.Visible = true;

                }

            }
            catch (Exception exp)
            {
                throw (exp);
            }
            finally
            {
                if (dbconn21.State == ConnectionState.Open)
                    dbconn21.Close();
            }


        }

        // metodo para conseguir tipo 
        public List<centro> ObtenerCentro()
        {
            List<centro> _lista = new List<centro>();

            SqlConnection dbconn = ConexionBd_Operaciones.ObtenerConexion();

            SqlCommand msc = new SqlCommand("dbo.ListarCentrosPrestador", dbconn);
            msc.Parameters.AddWithValue("@prestador", Ent.Ident);


            msc.CommandType = CommandType.StoredProcedure;

            SqlDataReader _reader = msc.ExecuteReader();
            while (_reader.Read())
            {
                centro pcentro = new centro();

                pcentro.Identcentro = _reader.GetInt32(2);
                pcentro.Nombrecentro = _reader.GetString(0);

                _lista.Add(pcentro);
            }
            dbconn.Close();
            return _lista;
        }




        protected void inputNewLogin1_Click1(object sender, EventArgs e)
        {



            int idex = centro.SelectedIndex;
            if (idex == 0)
            {

                //  ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "seleccione el Centro" + "');", true);
                Response.Write("<script>window.alert('Seleccione el Centro.')</script>");
                centro.Focus();
            }

            else if (idex > 0)
            {
                Session["Centro"] = centro.SelectedValue;
                Ent.Centro = Convert.ToInt32(Session["Centro"].ToString());

                Session["GuardiaSN"] = si.Text;

                SqlConnection dbconn22 = ConexionBd_Operaciones.ObtenerConexion();
                SqlCommand msc22 = new SqlCommand("dbo.PosicionCentro", dbconn22);
                //parametros de entrada           
                msc22.Parameters.AddWithValue("@Centro", centro.SelectedValue);
                //parametros de salida
                msc22.Parameters.Add("@barrio", SqlDbType.Int, 120);
                msc22.Parameters["@barrio"].Direction = ParameterDirection.Output;
                msc22.Parameters.Add("@localidad", SqlDbType.Int, 120);
                msc22.Parameters["@localidad"].Direction = ParameterDirection.Output;
                msc22.Parameters.Add("@partido", SqlDbType.Int, 120);
                msc22.Parameters["@partido"].Direction = ParameterDirection.Output;
                msc22.Parameters.Add("@provincia", SqlDbType.Int, 120);
                msc22.Parameters["@provincia"].Direction = ParameterDirection.Output;

                try
                {
                    if (dbconn22.State == ConnectionState.Closed)
                        dbconn22.Open();
                    msc22.CommandType = CommandType.StoredProcedure;
                    msc22.ExecuteNonQuery();
                    Session["barrio"] = msc22.Parameters["@barrio"].Value.ToString();
                    Session["localidad"] = msc22.Parameters["@localidad"].Value.ToString();
                    Session["partido"] = msc22.Parameters["@partido"].Value.ToString();
                    Session["provincia"] = msc22.Parameters["@provincia"].Value.ToString();

                    Response.Redirect("principal.aspx");
                }
                catch (Exception exp)
                {
                    throw (exp);
                }
                finally
                {
                    if (dbconn22.State == ConnectionState.Open)
                        dbconn22.Close();
                    msc22.Dispose();
                    msc22 = null;


                }


            }
            else
            {
                Session["nombreprestador"] = 0;
                Response.Redirect("login.asp?error=4");
            }



            //if (string.IsNullOrEmpty(Centro.Text))
            //{
            //    MessageBox.Show("No Item is Selected"); 
            //}
            //else
            //{
            //    MessageBox.Show("Item Selected is:" + Centro.Text);
            //}
        }

        

    }
}
      

       
