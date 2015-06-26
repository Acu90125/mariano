using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using logeo.clases;
using logeo.entidades;
using Microsoft.VisualBasic;
using System.Text;




namespace logeo
{
    public partial class logeo : System.Web.UI.Page
    {
        Entidades Ent = new Entidades();
        ConexionBd_Operaciones conection = new ConexionBd_Operaciones();

        protected void Page_Load(object sender, EventArgs e)
        {
            //string aspUrl = "C:\\punto.net\\logeo\\logeo\\captcha.asp";
            //System.Net.WebClient wc = new System.Net.WebClient();
            //Label1.Text = wc.DownloadString(aspUrl);

            // datos para dropdownlist
            ident.DataSource = ObtenerDocumento();
            ident.DataValueField = "Ident";
            ident.DataTextField = "Nombre";
            ident.DataBind();




            // sp para login por mail
            SqlConnection dbconn = ConexionBd_Operaciones.ObtenerConexion();
            SqlCommand msc = new SqlCommand("dbo.ObtenerParametro", dbconn);
            //parametros de entrada           
            msc.Parameters.AddWithValue("@parametro", 2);  
            //parametros de salida
            msc.Parameters.Add("@valor", SqlDbType.VarChar, 120);
            msc.Parameters["@valor"].Direction = ParameterDirection.Output;  
            try
            {
                if (dbconn.State == ConnectionState.Closed)
                    dbconn.Open();
                msc.CommandType = CommandType.StoredProcedure;
                msc.ExecuteNonQuery();
                string valorfila2 = msc.Parameters["@valor"].Value.ToString();
                // si la fila 2 de parametros esta en No , no muestro documentos
                if (valorfila2 == "NO")
                {
                    Label2.Visible = true;
                    ident.Visible = true;
                }

                if (Request.QueryString["res"] == "1")
                {
                    txtfecha_nac.Visible = true;
                    Label1.Visible = true;
                    imgPopup.Visible = true;
                }

            }
            catch (Exception exp)
            {
                throw (exp);
            }
            finally
            {
                if (dbconn.State == ConnectionState.Open)
                    dbconn.Close();
            }
           

            if (Request.QueryString["error"] == "1")
            {
                Label4.Text = "Usuario o Contrase&ntilde;a Incorrectos";
            }

            if (Request.QueryString["error"] == "2")
            {
                Label5.Text = "Acceso denegado";
            }

            if (Request.QueryString["error"] == "3")
            {
                Label6.Text = "Usuario desconectado correctamente";
            }

            if (Request.QueryString["error"] == "4")
            {
                Label7.Text = "No especifico Centro!";
            }
            if (Request.QueryString["error"] == "4")
            {
                Label8.Text = "Acceso denegado (referido incorrecto";
            }
            
        }
        // metodo para conseguir tipo de documento documento
        public static List<documento> ObtenerDocumento()
        {
            List<documento> _lista = new List<documento>();

            SqlConnection dbconn = ConexionBd_Operaciones.ObtenerConexion();          

            SqlCommand msc = new SqlCommand("dbo.ListarTipoDoc", dbconn);

            msc.CommandType = CommandType.StoredProcedure;
            
            SqlDataReader _reader = msc.ExecuteReader();
            while (_reader.Read())
            {
                documento pdocumento = new documento();

                pdocumento.Ident = _reader.GetInt32(0);
                pdocumento.Nombre = _reader.GetString(1);

                _lista.Add(pdocumento);
            }
            dbconn.Close();
            return _lista;
        }
      

         
        // boton de accion
        protected void Button1_Click(object sender, EventArgs e)
        {  // validador captcha
            if (txtcaptcha.Text != "")
            {
                if (Session["str"].ToString() != txtcaptcha.Text)
                {
                    Label3.Text = "Codigo Incorrecto";
                    return;
                }

                else
                {

                    Ent.Ip = ips.GetIPAddress();
                    Ent.Reseteado = 0;

                    // para saber si viene con reseado 1 , desde loginpassword  
                    // grabo en 
                    Ent.Reseteado = Convert.ToInt32(Request.QueryString["res"]);
                    if (Ent.Reseteado == 1)
                    {
                        // txtclave.Text  =  GenerateString(12);
                    }



                    // sp para extraer de la base varios parametros
                    SqlConnection dbconn = ConexionBd_Operaciones.ObtenerConexion();
                    SqlCommand msc = new SqlCommand("dbo.ingresar", dbconn);
                    //parametros de entrada
                    msc.Parameters.AddWithValue("@reseteado", Ent.Reseteado);
                    msc.Parameters.AddWithValue("@Tipodoc", ident.SelectedValue);
                    msc.Parameters.AddWithValue("@uss", txtusuario.Text);
                    msc.Parameters.AddWithValue("@pass", txtclave.Text);
                    msc.Parameters.AddWithValue("@nacimiento", txtfecha_nac.Text);
                    msc.Parameters.AddWithValue("@ip", Ent.Ip);

                    //parametros de salida
                    msc.Parameters.Add("@nombreprestador", SqlDbType.VarChar, 120);
                    msc.Parameters["@nombreprestador"].Direction = ParameterDirection.Output;
                    msc.Parameters.Add("@Identprestador", SqlDbType.Int, 120);
                    msc.Parameters["@Identprestador"].Direction = ParameterDirection.Output;
                    msc.Parameters.Add("@perfil", SqlDbType.Int, 120);
                    msc.Parameters["@perfil"].Direction = ParameterDirection.Output;
                    msc.Parameters.Add("@nivel", SqlDbType.Int, 120);
                    msc.Parameters["@nivel"].Direction = ParameterDirection.Output;

                    try
                    {
                        if (dbconn.State == ConnectionState.Closed)
                            dbconn.Open();
                        msc.CommandType = CommandType.StoredProcedure;
                        msc.ExecuteNonQuery();

                        string prestador = msc.Parameters["@nombreprestador"].Value.ToString();
                        int identprestador = Convert.ToInt32(msc.Parameters["@Identprestador"].Value.ToString());
                        int perfil = Convert.ToInt32(msc.Parameters["@perfil"].Value.ToString());
                        int nivel = Convert.ToInt32(msc.Parameters["@nivel"].Value.ToString());



                        if (identprestador > 0)
                        {
                            Session.Add("prestador", identprestador);
                            Session.Add("nombreprestador", prestador);
                            Session.Add("perfil", perfil);
                            Session.Add("nivel", nivel);



                            if (Ent.Reseteado == 1)
                            {
                                Session.Add("passnew", txtclave.Text);
                                Session["passres"] = 1;
                                Response.Redirect("cambiarpass.aspx");
                            }
                            else
                            {
                                Response.Redirect("inicio.aspx");
                            }
                        }
                        else
                        {
                            Session.RemoveAll();
                            Response.Redirect("login.aspx?error=1");

                        }


                    }
                    catch (Exception exp)
                    {
                        throw (exp);
                    }
                    finally
                    {
                        if (dbconn.State == ConnectionState.Open)
                            dbconn.Close();
                    }

                }



            }
            Label3.Text = "Falta Codigo";
        }

     

     
    }
}