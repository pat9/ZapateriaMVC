using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZapateriaMVC.Models;

namespace ZapateriaMVC.Controllers
{
    public class ZapatosController : Controller
    {
        ZapatosDAL ZapatosDAL = new ZapatosDAL();
        // GET: Zapatos
        public ActionResult Index()
        {
            List<Zapatos> ZapatosList = new List<Zapatos>(ZapatosDAL.ListarZapatos());
            return View(ZapatosList);
        }

        // GET: Zapatos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Zapatos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Zapatos/Create
        [HttpPost]
        public ActionResult Create(Zapatos Zapato, HttpPostedFileBase fotozapato, string[] zapatocolor , string[] talla)
        {

            try
            {
                // TODO: Add insert logic here
                if (fotozapato != null)
                {
                    using (var binaryReader = new BinaryReader(Request.Files[0].InputStream))
                    {
                        Zapato.Foto = binaryReader.ReadBytes(Request.Files[0].ContentLength);
                    }

                }

                ZapatosDAL.AgregarZapatos(Zapato, zapatocolor,talla);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Zapatos/Edit/5
        public ActionResult Edit(int id)
        {
            return View(ZapatosDAL.ObtenerDatosZapato(id));
        }

        // POST: Zapatos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Zapatos Zapato,HttpPostedFileBase fotozapato, string[] zapatocolor, string[] talla)
        {
            try
            {
                // TODO: Add update logic here
                var Zapato1 = ZapatosDAL.ObtenerDatosZapato(id);
                if(Zapato.Foto == null)
                {
                    Zapato.Foto = Zapato1.Foto;
                }
                if (fotozapato != null)
                {
                    using (var binaryReader = new BinaryReader(Request.Files[0].InputStream))
                    {
                        Zapato.Foto = binaryReader.ReadBytes(Request.Files[0].ContentLength);
                    }

                }
                ZapatosDAL.ModificarZapato(Zapato, zapatocolor, talla);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(ZapatosDAL.ObtenerDatosZapato(id));
            }
        }

        // GET: Zapatos/Delete/5
        public ActionResult Delete(int id)
        {
            return View(ZapatosDAL.ObtenerDatosZapato(id));
        }

        // POST: Zapatos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                ZapatosDAL.BorrarZapato(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
