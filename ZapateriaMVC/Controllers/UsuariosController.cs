using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZapateriaMVC.Models;

namespace ZapateriaMVC.Controllers
{
    public class UsuariosController : Controller
    {

        UsuariosDAL UsersDAL = new UsuariosDAL();
        // GET: Usuarios
        public ActionResult Index()
        {
            if (Session["Usuario"] == null)
            {
                return Redirect("/Admin/Login");
            }
            ViewBag.Usuario = (Usuarios)Session["Usuario"];
            return View(UsersDAL.ListarZapatos());
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int id)
        {
            if (Session["Usuario"] == null)
            {
                return Redirect("/Admin/Login");
            }
            ViewBag.Usuario = (Usuarios)Session["Usuario"];
            return View();
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            if (Session["Usuario"] == null)
            {
                return Redirect("/Admin/Login");
            }
            ViewBag.Usuario = (Usuarios)Session["Usuario"];
            return View();
        }

        // POST: Usuarios/Create
        [HttpPost]
        public ActionResult Create(Usuarios Usuario)
        {
            try
            {
                // TODO: Add insert logic here
                UsersDAL.AgregarUsuario(Usuario);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int id)
        {
            if (Session["Usuario"] == null)
            {
                return Redirect("/Admin/Login");
            }
            ViewBag.Usuario = (Usuarios)Session["Usuario"];
            return View(UsersDAL.ObtenerDatosUsuario(id));
        }

        // POST: Usuarios/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Usuarios Usuario)
        {
            try
            {
                // TODO: Add update logic here
                Usuario.Id = id;
                UsersDAL.ModificarUsuario(Usuario);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int id)
        {
            if (Session["Usuario"] == null)
            {
                return Redirect("/Admin/Login");
            }
            ViewBag.Usuario = (Usuarios)Session["Usuario"];
            return View(UsersDAL.ObtenerDatosUsuario(id));
        }

        // POST: Usuarios/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Usuarios Usuario)
        {
            try
            {
                // TODO: Add delete logic here
                Usuario.Id = id;
                UsersDAL.ModificarUsuario(Usuario);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
