using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Xml;
using System.Reflection;

namespace logeo
{
    public class ConexionBd_Operaciones
    {
        public static SqlConnection ObtenerConexion()
        {
            SqlConnection Conexion = new SqlConnection("Data Source=SVR01\\SQLEXPRESS;Initial Catalog=AcuarioDev;User Id=sa;PWD=Acu2014;Persist Security Info=True;");
            
            
            Conexion.Open();
            return Conexion;

        }
    }

}