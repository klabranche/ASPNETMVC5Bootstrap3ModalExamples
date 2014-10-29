using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.WebParts;
using Microsoft.Ajax.Utilities;
using MVCBootstrapModalSpike.Models;

namespace MVCBootstrapModalSpike.Controllers
{
    public class ModalComplexController : Controller
    {
        //
        // GET: /ModalComplex/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Person()
        {
            //could add code here for a model....
            return PartialView("_Person");
            
            //calling partial with existing model....
            //return PartialView("_Person", model);
        }

        [HttpPost]
        public ActionResult Person(PersonViewModel model)
        {
            //check validity, save to persistent store;
            return RedirectToAction("Index");
        }
	}
}