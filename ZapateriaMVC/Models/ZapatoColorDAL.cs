using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ZapateriaMVC.Models
{
    public class ZapatoColorDAL
    {
        string connectionString = "Data Source=den1.mssql7.gear.host; Initial Catalog=zapateria;User Id=zapateria;Password=Uh4KI~h~1iNL;";
        public IEnumerable<ZapatoColor> ListarColores(int id)
        {
            List<ZapatoColor> ListaColores = new List<ZapatoColor>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM colores_zapato WHERE idzapato=" + id, con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    ZapatoColor Zapato = new ZapatoColor();
                    Zapato.Id = Convert.ToInt32(rdr["idzapato"]);
                    Zapato.Color = rdr["color"].ToString();
                    ListaColores.Add(Zapato);
                }
                con.Close();
            }
            return ListaColores;
        }
    }
}