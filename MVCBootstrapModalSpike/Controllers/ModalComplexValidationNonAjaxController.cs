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
    public class ModalComplexValidationNonAjaxController : Controller
    {
        //
        // GET: /ModalComplex/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Person(int? id)
        {
            //could add code here to get model based on id....

            if (Request.IsAjaxRequest())
            {
                return PartialView("_Person");
                //calling partial with existing model....
                //return PartialView("_Person", model);
            }

                //return View("_Person");//Partial is wired up to work with jQuery Modal.... loose cancel functionality & client side validation...
            //return View("View1");
            return RedirectToAction("View1",id);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Person(PersonValidationViewModel model)
        {
            if (!ModelState.IsValid)
            {

                if (Request.IsAjaxRequest())
                {
                    var errors = GetErrorsFromModelState();
                    return Json(new {success = false, errors = errors});
                }
                else
                {
                    return View("_Person",model);
                    //RedirectToAction("View1", model);
                }
                //return PartialView("_Person", model);
            }

            //save to persistent store;
            //return data back to post OR do a normal MVC Redirect....
            if (Request.IsAjaxRequest())
            {
                return Json(new {success = true});  //perhaps you want to do more on return.... otherwise this if block is not necessary....
            }

            return RedirectToAction("Index");
        }

        private Dictionary<string,ModelErrorCollection> GetErrorsFromModelState() //IEnumerable<string>
        {
            //return ModelState.SelectMany(x => x.Value.Errors
            //    .Select(error => error.ErrorMessage));

            return ModelState.Keys.Where(key => ModelState[key].Errors.Count > 0).ToDictionary(key => key, key => ModelState[key].Errors);
        }


        public ActionResult View1()
        {
            //could add code here for a model....
            return View();

            //calling partial with existing model....
            //return PartialView("_Person", model);
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