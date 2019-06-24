using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZapateriaMVC.Models;

namespace ZapateriaMVC.Controllers
{
    public class HomeController : Controller
    {
        ZapatosDAL ZapatosDAL = new ZapatosDAL();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Mision()
        {
            return View();
        }

        public ActionResult Vision()
        {
            return View();
        }

        public ActionResult Contacto()
        {
            return View();
        }

        public ActionResult Quienes()
        {
            return View();
        }

        public ActionResult Categoria(int id)
        {
            if(id >=1 && id <= 2)
            {
                ViewBag.Categoria = id;
                return View(ZapatosDAL.ListarZapatos(id));
            }
            else
            {
                return new HttpStatusCodeResult(404);
            }

        }

        // GET: Home/Details/5
        public ActionResult Zapato(int id)
        {
            try
            {
                var Zapat = ZapatosDAL.ObtenerDatosZapato(id);
                if(Zapat.Id > 0)
                {
                    return View(Zapat);

                }
                else
                {
                    return new HttpStatusCodeResult(404);
                }

            }
            catch
            {
                return new HttpStatusCodeResult(404);
            }
        }

       
    }
}
