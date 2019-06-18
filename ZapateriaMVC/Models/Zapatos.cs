using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZapateriaMVC.Models
{
    public class Zapatos
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public byte[] Foto { get; set; }
        public int Categoria { get; set; }
        public int Stock { get; set; }
    }
}