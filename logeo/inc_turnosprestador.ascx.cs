using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using logeo.entidades;
using System.Data.SqlClient;

namespace logeo
{
    public partial class inc_turnosprestador : System.Web.UI.UserControl
    {
        Entidades Ent = new Entidades();
        prestador pres = new prestador();
        ConexionBd_Operaciones conection = new ConexionBd_Operaciones();
        int val = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            Ent.Ident = (int)(Session["prestador"]);
            Ent.Centro = Convert.ToInt32(Session["Centro"].ToString());
          
                pres.FechaActual = DateTime.Now.ToString("dd/MM/yyyy");
          
         
          
            if(todos.Checked == true)
            {
               val = 1;

            }
            else
            {
                val = 0;
            }

            if (!IsPostBack)
            {
                txtfecha.Text = pres.FechaActual;
          

            SqlConnection dbconn1 = ConexionBd_Operaciones.ObtenerConexion();
            SqlCommand msc1 = new SqlCommand("dbo.ListarTurnosPrestador", dbconn1);
            //parametros de entrada         
            msc1.Parameters.AddWithValue("@prestador", Ent.Ident);
            msc1.Parameters.AddWithValue("@fecha", pres.FechaActual);
            msc1.Parameters.AddWithValue("@Centro", Ent.Centro);          
            msc1.Parameters.AddWithValue("@todos", val);
            //parametros de salida

            try
            {
                if (dbconn1.State == ConnectionState.Closed)
                    dbconn1.Open();
                msc1.CommandType = CommandType.StoredProcedure;

                //DataSet ds = new DataSet();
                //using (SqlDataAdapter adapter = new SqlDataAdapter(msc1))
                //{
                //    adapter.Fill(ds);
                //    GridView1.DataSource = ds.Tables[0];
                //    GridView1.DataBind();
                //}
               
                DataSet ds = new DataSet();
                using (SqlDataAdapter adapter = new SqlDataAdapter(msc1))
                    adapter.Fill(ds);
                Repeater1.DataSource = ds.Tables[0];
                Repeater1.DataBind();

                //for (int i = 0; i < ds.Tables[0].Rows.Count; i++) // accedo a cada uno de los dataset field
                //{

                // pres.Identturno = Convert.ToInt32(ds.Tables[0].Rows[i][14].ToString());// = ident turno
                
                //}
          

               
              

            }
            catch (Exception exp)
            {
                throw (exp);
            }
            finally
            {
                if (dbconn1.State == ConnectionState.Open)

                    dbconn1.Close();
            }

            }
        }

        protected void Button2_Click(object sender, EventArgs e)  // cambia de dia 
        {

            if (todos.Checked == true)
            {
                val = 1;

            }
            else
            {
                val = 0;
            }
               SqlConnection dbconn1 = ConexionBd_Operaciones.ObtenerConexion();
            SqlCommand msc1 = new SqlCommand("dbo.ListarTurnosPrestador", dbconn1);
            //parametros de entrada         
            msc1.Parameters.AddWithValue("@prestador", Ent.Ident);
            msc1.Parameters.AddWithValue("@fecha", txtfecha.Text);
            msc1.Parameters.AddWithValue("@Centro", Ent.Centro);          
            msc1.Parameters.AddWithValue("@todos", val);
            //parametros de salida

            try
            {
                if (dbconn1.State == ConnectionState.Closed)
                    dbconn1.Open();
                msc1.CommandType = CommandType.StoredProcedure;

                //DataSet ds = new DataSet();
                //using (SqlDataAdapter adapter = new SqlDataAdapter(msc1))
                //{
                //    adapter.Fill(ds);
                //    GridView1.DataSource = ds.Tables[0];
                //    GridView1.DataBind();
                //}
               
                DataSet ds = new DataSet();
                using (SqlDataAdapter adapter = new SqlDataAdapter(msc1))
                    adapter.Fill(ds);
                Repeater1.DataSource = ds.Tables[0];
                Repeater1.DataBind();

              
               
              

            }
            catch (Exception exp)
            {
                throw (exp);
            }
            finally
            {
                if (dbconn1.State == ConnectionState.Open)
                    dbconn1.Close();
            }
        }



        //public string GetDetail(object objEmplayeeId)
        //{
        //    int EmplayeeId = int.Parse(objEmplayeeId.ToString());

        //    if (EmplayeeId > 0)
        //    {
        //        return "http://www.emplayeerecord.com/Emplayee/EmplayeeDetail.aspx?EmplayeeId=" + EmplayeeId;
        //        //Write the url which you want to make
        //    }
        //    else
        //        return "http://www.c-sharpcorner.com/";
        //}

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            pres.Identturno = Convert.ToInt32(e.CommandArgument);

         

                SqlConnection dbconn = ConexionBd_Operaciones.ObtenerConexion();
                SqlCommand msc = new SqlCommand("dbo.AsistenciaTurno", dbconn);
                //parametros de entrada           
                msc.Parameters.AddWithValue("@Identturno", pres.Identturno);
                msc.Parameters.AddWithValue("@prestador", Ent.Ident);
                if (e.CommandName == "presente")
                {
                    msc.Parameters.AddWithValue("@estado", 2);
                }
                if (e.CommandName == "anunciar")
                {
                    msc.Parameters.AddWithValue("@estado", 6);
                }
                if (e.CommandName == "ausente")
                {
                    msc.Parameters.AddWithValue("@estado", 4);
                }

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
            
     
            
        }
       
    }
}