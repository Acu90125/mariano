using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using logeo.clases;
using logeo.entidades;
using System.Data.SqlClient;
using System.Data;

namespace logeo
{
    public partial class loginpassword : System.Web.UI.Page
    {
        Entidades Ent = new Entidades();
     
        Email correo = new Email();
        ConexionBd_Operaciones conection = new ConexionBd_Operaciones();
        public string valorfila2 = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            // datos para dropdownlist
            ident.DataSource = ObtenerDocumento();
            ident.DataValueField = "Ident";
            ident.DataTextField = "Nombre";
            ident.DataBind();


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
                Label4.Text = "usuario  incorrecto";
            }

            if (Request.QueryString["error"] == "2")
            {
                Label5.Text = "La contraseña fue enviada a  su direccion de correo electronico";
            }

            if (Request.QueryString["error"] == "3")
            {
                Label6.Text = "Error en el email registrado";
            }

            if (Request.QueryString["error"] == "4")
            {
                Label7.Text = "Usuario deshabilitado!";
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

       
      

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection dbconn = ConexionBd_Operaciones.ObtenerConexion(); 
            SqlCommand cmd = new SqlCommand();
            Int32 rowsAffected;

            if (valorfila2 == "SI")
            {
                Ent.Usuario = txtusuario.Text;
            }
            else
            {
                Ent.Usuario = ident + txtusuario.Text;
            }
            if (Ent.Usuario != "")
            {
                Ent.Clave = GenerateString(12);
            }
           
                try 
	                {	    
                     if (dbconn.State == ConnectionState.Closed)
                        dbconn.Open();


                     cmd.CommandText = "update prestador set pass = HashBytes('MD5', @paramName) where usuario = @usuario and activo = 1";
                     // set it to a varchar SqlDbType: 
                     cmd.Parameters.Add("@paramName", SqlDbType.VarChar).Value = Ent.Clave.Trim();
                     cmd.Parameters.AddWithValue("@usuario", Ent.Usuario);


                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = dbconn;
                        rowsAffected = cmd.ExecuteNonQuery();



                        cmd.CommandText = "SELECT usuario, isnull(email, '') as email, case when activo = 1 then 1 else 0 end as activo from prestador where usuario = @usuarioemail";
                        // set it to a varchar SqlDbType: 
                        cmd.Parameters.AddWithValue("@usuarioemail", Ent.Usuario);


                        SqlDataReader mdr = cmd.ExecuteReader();
                        while (mdr.Read())
                        {
                            
                            //   objColumns.Cardinal = Convert.ToInt16(mdr["ordinal_position"]);
                            // objColumns.EsNulo = Convert.ToInt16(mdr["IS_NULLABLE"]);
                            Ent.Email = (mdr["email"]).ToString();
                         

                        }
                        mdr.Close();
                        cmd.Dispose();
                        Ent.Asunto_mail = "Recordatorio de clave .: Acuario :.";
                        Ent.Mensaje_mail = "Su clave de acceso al sistema es: " + Ent.Clave;
                         
                        correo.EnvioCorreo(1, Ent.Email,Ent.Asunto_mail,Ent.Mensaje_mail,"");
                        
                   
                     }
	                catch (Exception)
	                {
		
		                throw;
	                }

                    finally
                    {
                        if (dbconn.State == ConnectionState.Open)
                            dbconn.Close();
                    }
    
        }

        Random rand = new Random();

        public const string Alphabet = "abcdefghijklmnopqrstuvwyxz";
        //"abcdefghijklmnopqrstuvwyxzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        public string GenerateString(int size)
        {
            char[] chars = new char[size];
            for (int i = 0; i < size; i++)
            {
                chars[i] = Alphabet[rand.Next(Alphabet.Length)];
            }
            return new string(chars);
        }


            
    }
}