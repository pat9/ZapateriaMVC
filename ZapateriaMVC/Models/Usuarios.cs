﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZapateriaMVC.Models
{
    public class Usuarios
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }

    }
}