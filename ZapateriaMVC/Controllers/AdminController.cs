using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZapateriaMVC.Models;

namespace ZapateriaMVC.Controllers
{
    public class AdminController : Controller
    {
        UsuariosDAL Usuarios = new UsuariosDAL();
        // GET: Admin
        public ActionResult Index()
        {
            if (Session["Usuario"] == null)
            {
                return Redirect("/Admin/Login");
            }
            ViewBag.Usuario = (Usuarios)Session["Usuario"];
            return View();
        }

        public ActionResult Login()
        {
            if(Session["Usuario"] != null)
            {
                return Redirect("/Admin/");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login(string usuario, string password)
        {
            if (Session["Usuario"] != null)
            {
                return Redirect("/Admin/");
            }
            var user = Usuarios.ObtenerDatosUsuario(usuario, password);
            if(user.Id > 0)
            {
                Session["Usuario"] = user;
                return Redirect("/Admin/");
            }
            else
            {
                return View();

            }
        }
    }
}
