using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ZapateriaMVC.Models
{
    public class ZapatosDAL
    {
        string connectionString = "Data Source=den1.mssql7.gear.host; Initial Catalog=zapateria;User Id=zapateria;Password=Uh4KI~h~1iNL;";
        //To View all employees details
        public IEnumerable<Zapatos> ListarZapatos()
        {
            List<Zapatos> ListaEmpleados = new List<Zapatos>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM zapatos", con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Zapatos Zapato = new Zapatos();
                    Zapato.Id = Convert.ToInt32(rdr["id"]);
                    Zapato.Nombre = rdr["nombre"].ToString();
                    Zapato.Descripcion = rdr["descripcion"].ToString();
                    Zapato.Precio = Convert.ToDouble(rdr["precio"]);
                    Zapato.Foto = (byte[])rdr["foto"];
                    Zapato.Categoria = (int)rdr["categoria"];
                    Zapato.Stock = (int)rdr["stock"];
                    ListaEmpleados.Add(Zapato);
                }
                con.Close();
            }
            return ListaEmpleados;

        }

        public IEnumerable<Zapatos> ListarZapatos(int categoria)
        {
            List<Zapatos> ListaEmpleados = new List<Zapatos>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM zapatos WHERE categoria="+categoria, con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Zapatos Zapato = new Zapatos();
                    Zapato.Id = Convert.ToInt32(rdr["id"]);
                    Zapato.Nombre = rdr["nombre"].ToString();
                    Zapato.Descripcion = rdr["descripcion"].ToString();
                    Zapato.Precio = Convert.ToDouble(rdr["precio"]);
                    Zapato.Foto = (byte[])rdr["foto"];
                    Zapato.Categoria = (int)rdr["categoria"];
                    Zapato.Stock = (int)rdr["stock"];
                    ListaEmpleados.Add(Zapato);
                }
                con.Close();
            }
            return ListaEmpleados;

        }

        public void AgregarZapatos(Zapatos Zapato, string[] Colores, string[] Tallas)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Zapatos OUTPUT INSERTED.ID VALUES(@nombre, @descripcion, @precio, @foto, @categoria, @stock)", con);
               
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@nombre", Zapato.Nombre);
                cmd.Parameters.AddWithValue("@descripcion", Zapato.Descripcion);
                cmd.Parameters.AddWithValue("@precio", Zapato.Precio);
                cmd.Parameters.AddWithValue("@foto", Zapato.Foto);
                cmd.Parameters.AddWithValue("@categoria", Zapato.Categoria);
                cmd.Parameters.AddWithValue("@stock", Zapato.Stock);
                con.Open();
                int id = (int)cmd.ExecuteScalar();
                foreach(string color in Colores)
                {
                    cmd = new SqlCommand("INSERT INTO colores_zapato VALUES(@id, @color)", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@color", color);
                    cmd.ExecuteNonQuery();
                }

                foreach (string talla in Tallas)
                {
                    cmd = new SqlCommand("INSERT INTO talla_zapato VALUES(@id, @talla)", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@talla", talla);
                    cmd.ExecuteNonQuery();
                }

                con.Close();
            }
        }
        public void ModificarZapato(Zapatos Zapato, string[] Colores, string[] Tallas)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("UPDATE zapatos SET nombre = @Nombre, descripcion = @descripcion, precio = @precio, foto = @foto, categoria=@categoria, stock=@stock WHERE ID = @ID", con);
               
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@ID", Zapato.Id);
                cmd.Parameters.AddWithValue("@Nombre", Zapato.Nombre);
                cmd.Parameters.AddWithValue("@descripcion", Zapato.Descripcion);
                cmd.Parameters.AddWithValue("@precio", Zapato.Precio);
                cmd.Parameters.AddWithValue("@foto", Zapato.Foto);
                cmd.Parameters.AddWithValue("@categoria", Zapato.Categoria);
                cmd.Parameters.AddWithValue("@stock", Zapato.Stock);
                con.Open();
                cmd.ExecuteNonQuery();
                cmd = new SqlCommand("DELETE FROM colores_zapato WHERE idzapato=" + Zapato.Id, con);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                foreach (string color in Colores)
                {
                    cmd = new SqlCommand("INSERT INTO colores_zapato VALUES(@id, @color)", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@id", Zapato.Id);
                    cmd.Parameters.AddWithValue("@color", color);
                    cmd.ExecuteNonQuery();
                }
                cmd = new SqlCommand("DELETE FROM talla_zapato WHERE idzapato=" + Zapato.Id, con);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                foreach (string talla in Tallas)
                {
                    cmd = new SqlCommand("INSERT INTO talla_zapato VALUES(@id, @talla)", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@id", Zapato.Id);
                    cmd.Parameters.AddWithValue("@talla", talla);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        public Zapatos ObtenerDatosZapato(int? ID)
        {
            Zapatos Zapato = new Zapatos();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM zapatos WHERE ID= " + ID;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Zapato.Id = Convert.ToInt32(rdr["ID"]);
                    Zapato.Nombre = rdr["nombre"].ToString();
                    Zapato.Nombre = rdr["nombre"].ToString();
                    Zapato.Descripcion = rdr["descripcion"].ToString();
                    Zapato.Precio = Convert.ToDouble(rdr["precio"]);
                    Zapato.Foto = (byte[])rdr["foto"];
                    Zapato.Categoria = (int)rdr["categoria"];
                    Zapato.Stock = (int)rdr["stock"];
                }
            }
            return Zapato;
        }
        //To Delete the record on a particular employee
        public void BorrarZapato(int? ID)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM zapatos WHERE ID = @ID", con);
               
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@ID", ID);
                con.Open();
                cmd.ExecuteNonQuery();
                cmd = new SqlCommand("DELETE FROM colores_zapato WHERE idzapato=" + ID, con);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                cmd = new SqlCommand("DELETE FROM talla_zapato WHERE idzapato=" + ID, con);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

    }
}