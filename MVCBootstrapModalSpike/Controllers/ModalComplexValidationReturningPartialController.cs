using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.WebParts;
using Microsoft.Ajax.Utilities;
using MVCBootstrapModalSpike.Models;
using WebGrease.Css.Extensions;

namespace MVCBootstrapModalSpike.Controllers
{
    public class ModalComplexValidationReturningPartialController : Controller
    {
        //
        // GET: /ModalComplex/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Person(int id=1)
        {
            //could add code here to get model based on id....
            return PartialView("_Person");
            
            //calling partial with existing model....
            //return PartialView("_Person", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Person(PersonValidationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                //var errors = GetErrorsFromModelState();
                //return Json(new {success = false, errors = errors});
                return PartialView("_Person", model);
            }

            //save to persistent store;
            //return data back to post OR do a normal MVC Redirect....
            return Json(new {success = true});
            //return RedirectToAction("Index");
        }

        public ActionResult View1()
        {
            //could add code here for a model....
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult View1(PersonValidationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            //save to persistent store;
            return RedirectToAction("Index");
        }

	}
}