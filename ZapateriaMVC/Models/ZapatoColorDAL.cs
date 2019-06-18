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
        string connectionString = "Data Source=DESKTOP-GOR5NCI;Initial Catalog=Zapateria;Integrated Security = True";
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