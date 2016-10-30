using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace URL.Validation.Client.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult DomainIsAvailable(string url)
        {
            if (ModelState.IsValid)
            {
                //Data save to database  
                return Json(new
                {
                    success = true
                }, 
                JsonRequestBehavior.AllowGet);
            }

            return Json(new
            {
                success = false,
                errors = ModelState.Keys.SelectMany(i => ModelState[i].Errors).Select(m => m.ErrorMessage).ToArray()
            }, JsonRequestBehavior.AllowGet);
        }
    }
}