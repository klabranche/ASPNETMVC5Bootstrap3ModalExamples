using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCBootstrapModalSpike.Controllers
{
    public class ModalWithPartialViewController : Controller
    {
        //
        // GET: /ModalWithPartialView/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Search()
        {
            return PartialView("_Search");
        }
	}
}