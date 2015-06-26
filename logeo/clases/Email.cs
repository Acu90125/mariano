using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using logeo.entidades;
using System.Configuration;
using System.IO;
using logeo.entidades;
using System.Security.Permissions;

namespace logeo.clases
{
    public class Email
    {
  
 
        ConexionBd_Operaciones conection = new ConexionBd_Operaciones();
        Entidades Ent = new Entidades();

        public void EnvioCorreo(int tipo, string para,string asunto,string cuerpo,string adjunto)
        {


            // sp para login por mail
            SqlConnection dbconn = ConexionBd_Operaciones.ObtenerConexion();
            SqlCommand msc = new SqlCommand("dbo.ObtenerParametro", dbconn);
            //parametros de entrada           
            msc.Parameters.AddWithValue("@parametro", 3);
            //parametros de salida
            msc.Parameters.Add("@valor", SqlDbType.VarChar, 120);
            msc.Parameters["@valor"].Direction = ParameterDirection.Output;
            try
            {
                if (dbconn.State == ConnectionState.Closed)
                    dbconn.Open();
                msc.CommandType = CommandType.StoredProcedure;
                msc.ExecuteNonQuery();

                 Ent.Ruta= msc.Parameters["@valor"].Value.ToString();

              

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


            // sp para login por mail
            SqlConnection dbconn_1 = ConexionBd_Operaciones.ObtenerConexion();
            SqlCommand msc_1 = new SqlCommand("dbo.ObtenerParametro", dbconn_1);
            //parametros de entrada           
            msc_1.Parameters.AddWithValue("@parametro", 4);
            //parametros de salida
            msc_1.Parameters.Add("@valor", SqlDbType.VarChar, 120);
            msc_1.Parameters["@valor"].Direction = ParameterDirection.Output;
            try
            {
                if (dbconn_1.State == ConnectionState.Closed)
                    dbconn_1.Open();
                msc_1.CommandType = CommandType.StoredProcedure;
                msc_1.ExecuteNonQuery();

                Ent.Remitente = msc_1.Parameters["@valor"].Value.ToString();



            }
            catch (Exception exp)
            {
                throw (exp);
            }
            finally
            {
                if (dbconn_1.State == ConnectionState.Open)
                    dbconn_1.Close();
            }




            try
            {
                Ent.Clave = GenerateString(12);

                FileStream stream = new FileStream(Ent.Ruta+"\\"+Ent.Clave+".eml",FileMode.OpenOrCreate, FileAccess.Write);

                // "C:\\mariano\\archivo.txt"

                StreamWriter writer = new StreamWriter(stream); 
                              
                writer.WriteLine("X-Receiver:" + para);
                writer.WriteLine("X-Sender:" + Ent.Remitente);
				writer.WriteLine("Thread-Topic: " +asunto);
                writer.WriteLine("From: <" + Ent.Remitente + ">");
				writer.WriteLine("To: <"+para+">");
				writer.WriteLine("Subject: " +asunto);
                writer.WriteLine("Date: " + DateTime.Now);
                writer.WriteLine("Message-ID: <" + Ent.Clave + "@" + HttpContext.Current.Request.ServerVariables["SERVER_NAME"] + ">");
				writer.WriteLine("MIME-Version: 1.0");
				writer.WriteLine("Content-Type: multipart/alternative;");
                writer.WriteLine("    boundary=\"----=_NextPart_000_0006_01D05CBF.39B81A60 \"");
				writer.WriteLine("X-Mailer: Acuario Salud");
				writer.WriteLine("Content-Class: urn:content-classes:message");
				writer.WriteLine("Importance: normal");
				writer.WriteLine("Priority: normal");
				writer.WriteLine("X-MimeOLE: Generado por Acuario Salud");
                writer.Write(String.Concat(Enumerable.Repeat(Environment.NewLine, 1).ToArray()));
				writer.WriteLine("This is a multi-part message in MIME format.");
                writer.Write(String.Concat(Enumerable.Repeat(Environment.NewLine, 1).ToArray()));
				writer.WriteLine("------=_NextPart_000_0006_01D05CBF.39B81A60");
				writer.WriteLine("Content-Type: text/plain");
				writer.WriteLine("Content-Transfer-Encoding: 8bit");
                writer.Write(String.Concat(Enumerable.Repeat(Environment.NewLine, 1).ToArray()));
				writer.WriteLine(cuerpo);
				writer.WriteLine("------=_NextPart_000_0006_01D05CBF.39B81A60");
				writer.WriteLine("Content-Type: text/html;");			
			    writer.WriteLine("    charset=\"iso-8859-1\"");
				writer.WriteLine("Content-Transfer-Encoding: 8bits");
                writer.Write(String.Concat(Enumerable.Repeat(Environment.NewLine, 1).ToArray()));
				writer.WriteLine(cuerpo);
                writer.WriteLine("------=_NextPart_000_0006_01D05CBF.39B81A60--");
               
                writer.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex);
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