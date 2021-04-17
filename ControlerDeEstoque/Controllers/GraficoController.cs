using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlerDeEstoque.Controllers
{
    public class GraficoController : Controller
    {
        [Authorize]
        public ActionResult PerdaMes()
        {
             
            return View();
        }
        [Authorize]
        public ActionResult EntraSaidaMes()
        {
            return View();
        }
    }
}