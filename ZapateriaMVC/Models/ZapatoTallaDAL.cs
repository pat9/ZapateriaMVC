using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ZapateriaMVC.Models
{
    public class ZapatoTallaDAL
    {
        string connectionString = "Data Source=den1.mssql7.gear.host;  Initial Catalog=Zapateria;User Id=zapateria;Password=Uh4KI~h~1iNL;";
        public IEnumerable<ZapatoTalla> ListarTalla(int id)
        {
            List<ZapatoTalla> ListaTalla = new List<ZapatoTalla>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM talla_zapato WHERE idzapato=" + id, con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    ZapatoTalla Zapato = new ZapatoTalla();
                    Zapato.Id = Convert.ToInt32(rdr["idzapato"]);
                    Zapato.Talla = rdr["talla"].ToString();
                    ListaTalla.Add(Zapato);
                }
                con.Close();
            }
            return ListaTalla;
        }
    }
}