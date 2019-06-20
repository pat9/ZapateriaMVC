using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ZapateriaMVC.Models
{
    public class UsuariosDAL
    {
        string connectionString = "Data Source=DESKTOP-GOR5NCI;Initial Catalog=Zapateria;Integrated Security = True";
        //To View all employees details
        public IEnumerable<Usuarios> ListarZapatos()
        {
            List<Usuarios> ListaEmpleados = new List<Usuarios>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM usuarios", con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Usuarios Usuario = new Usuarios();
                    Usuario.Id = Convert.ToInt32(rdr["id"]);
                    Usuario.Usuario = rdr["usuario"].ToString();
                    Usuario.Password = rdr["password"].ToString();
                    Usuario.Nombre = rdr["nombre"].ToString();
                    ListaEmpleados.Add(Usuario);
                }
                con.Close();
            }
            return ListaEmpleados;
        }

        public void AgregarUsuario(Usuarios Usuario)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO usuarios VALUES(@usuario, @pass, @nombre)", con);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@nombre", Usuario.Nombre);
                cmd.Parameters.AddWithValue("@usuario", Usuario.Usuario);
                cmd.Parameters.AddWithValue("@pass", Usuario.Password);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void ModificarUsuario(Usuarios Usuario)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("UPDATE usuarios SET nombre = @Nombre, usuario = @usuario, pass = @pass WHERE ID = @ID", con);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@ID", Usuario.Id);
                cmd.Parameters.AddWithValue("@Nombre", Usuario.Nombre);
                cmd.Parameters.AddWithValue("@pass", Usuario.Password);
                cmd.Parameters.AddWithValue("@usuario", Usuario.Usuario);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public Usuarios ObtenerDatosUsuario(int? ID)
        {
            Usuarios Usuario = new Usuarios();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM usuarios WHERE ID= " + ID;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Usuario.Id = Convert.ToInt32(rdr["id"]);
                    Usuario.Usuario = rdr["usuario"].ToString();
                    Usuario.Password = rdr["pass"].ToString();
                    Usuario.Nombre = rdr["nombre"].ToString();
                }
            }
            return Usuario;
        }

        public Usuarios ObtenerDatosUsuario(string usuario, string password)
        {
            Usuarios Usuario = new Usuarios();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM usuarios WHERE usuario='" + usuario + "' and pass='"+password+"'";
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Usuario.Id = Convert.ToInt32(rdr["id"]);
                    Usuario.Usuario = rdr["usuario"].ToString();
                    Usuario.Password = rdr["pass"].ToString();
                    Usuario.Nombre = rdr["nombre"].ToString();
                }
            }
            return Usuario;
        }

        //To Delete the record on a particular employee
        public void BorrarUsuario(int? ID)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM usuarios WHERE ID = @ID", con);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@ID", ID);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}