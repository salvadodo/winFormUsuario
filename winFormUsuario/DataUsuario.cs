using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace winFormUsuario
{
    public class DataUsuario
    {

        //private string cadCon = "data source = DESKTOP - 7NJ0RL5;initial catalog = Usuario; integrated security = True";
        public DataTable registrosUsuarios()
        {
            //using (SqlConnection con = new SqlConnection(cadCon))
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UsuarioEntities"].ConnectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_selectAllUsuario";
                    //cmd.CommandType = CommandType.Text;
                    //cmd.CommandText = "select * from Casas";
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable tbl = new DataTable();
                    da.Fill(tbl);
                    return tbl;
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    if (con.State != ConnectionState.Closed)
                    {
                        con.Close();
                    }
                }
            }
        }
        //public DataTable selectCasa(int idUsuario)
        //{
        //    using (SqlConnection con = new SqlConnection(cadCon))
        //    {
        //        try
        //        {
        //            SqlCommand cmd = new SqlCommand();
        //            cmd.Connection = con;
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.CommandText = "sp_selectOneCasas";
        //            cmd.Parameters.AddWithValue("@idCasa", idCasa);
        //            con.Open();
        //            SqlDataAdapter da = new SqlDataAdapter();
        //            DataTable tbl = new DataTable();
        //            da.Fill(tbl);
        //            return tbl;
        //        }
        //        catch (Exception)
        //        {
        //            throw;
        //        }
        //        finally
        //        {
        //            if (con.State != ConnectionState.Closed)
        //            {
        //                con.Close();
        //            }
        //        }
        //    }
        //}
        public void insertarUsuario(Usuario insUsuario)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UsuarioEntities"].ConnectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_insertUsuario";
                    cmd.Parameters.AddWithValue("@Nombre", insUsuario.Nombre);
                    cmd.Parameters.AddWithValue("@Edad", insUsuario.Edad);
                    cmd.Parameters.AddWithValue("@Sexo", insUsuario.Sexo);
                    cmd.Parameters.AddWithValue("@Direccion", insUsuario.Direccion);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    if (con.State != ConnectionState.Closed)
                    {
                        con.Close();
                    }
                }
            }
        }
        public void modificarUsuario(Usuario modUsuario)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UsuarioEntities"].ConnectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_updateUsuaio";
                    cmd.Parameters.AddWithValue("@idUsuario", modUsuario.idUsuario);
                    cmd.Parameters.AddWithValue("@Nombre", modUsuario.Nombre);
                    cmd.Parameters.AddWithValue("@Edad", modUsuario.Edad);
                    cmd.Parameters.AddWithValue("@Sexo", modUsuario.Sexo);
                    cmd.Parameters.AddWithValue("@Direccion", modUsuario.Direccion);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    if (con.State != ConnectionState.Closed)
                    {
                        con.Close();
                    }
                }
            }
        }
        public void eliminarUsuario(int eliUsuario)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UsuarioEntities"].ConnectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_deleteUsuario";
                    cmd.Parameters.AddWithValue("@idUsuario", eliUsuario);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    if (con.State != ConnectionState.Closed)
                    {
                        con.Close();
                    }
                }
            }
        }
        public DataTable buscarPorNombre(string Name)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["UsuarioEntities"].ConnectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_buscarNombreUsuario";
                    cmd.Parameters.AddWithValue("@Nombre", Name);
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable tbl = new DataTable();
                    da.Fill(tbl);
                    return tbl;
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    if(con.State != ConnectionState.Closed)
                    {
                        con.Close();
                    }
                }
            }
        }
    }
}
