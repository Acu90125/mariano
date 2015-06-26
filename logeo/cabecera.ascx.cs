using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using logeo.entidades;
using System.Data.SqlClient;
using System.Data;
using logeo.clases;




namespace logeo
{
    public partial class cabecera : System.Web.UI.UserControl 
    {

        ConexionBd_Operaciones conection = new ConexionBd_Operaciones();
        Logout login_salida = new Logout();
        Entidades Ent = new Entidades();

        protected void Page_Load(object sender, EventArgs e)
        {
           
            Ent.Ident = (int)(Session["prestador"]);
            Ent.Ip = ips.GetIPAddress();   

            if (Ent.Ident != 0)
            {
                  login_salida.LogoutMembers = Convert.ToString(Request.Url.AbsolutePath) + "?MM_Logoutnow=1";
              //  login_salida.LogoutMembers = Convert.ToString(Request.ServerVariables["HTTP_HOST"]) + Convert.ToString(Request.Url.AbsolutePath) + "?MM_Logoutnow=1";
                  HyperLink1.NavigateUrl = String.Format(login_salida.LogoutMembers);
                //  HyperLink1.Attributes.Add("onclick", "return TestLinkClick();");

                  if (!IsPostBack)// si no es la primera vez
                  {
                      string valor = Request.QueryString["MM_Logoutnow"];
                      if (valor =="1")
                      {
                        
                              SqlConnection dbconn = ConexionBd_Operaciones.ObtenerConexion();
                              SqlCommand msc = new SqlCommand("dbo.AgregarLogsLogin", dbconn);
                              //parametros de entrada           
                              msc.Parameters.AddWithValue("@usuario", Ent.Ident);
                              msc.Parameters.AddWithValue("@ip", Ent.Ip);
                              msc.Parameters.AddWithValue("@estado", 3);
                              //parametros de salida
                            
                              try
                              {
                                  if (dbconn.State == ConnectionState.Closed)
                                      dbconn.Open();
                                  msc.CommandType = CommandType.StoredProcedure;
                                  msc.ExecuteNonQuery();
                                 
                                 

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

                          


                          Session.RemoveAll();
                          Response.Redirect("~/logeo.aspx?error=3");
                      }
                      
                  }
                 
             
            //   if (Session["paciente"].ToString() != "")
            //{
            //    login_salida.LogoutPatient = Convert.ToString(Request.Url.AbsolutePath) + "?MM_LogoutPacnow=1";
            //    Label2.Text = login_salida.LogoutPatient;
            //}


            }
        }

    
       
      
    }
}