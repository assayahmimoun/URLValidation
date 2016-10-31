using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using URL.Validation.Client.Business.Services;

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
                var result = URLService.CheckDomainIsAvailable(url);
                if(result != null)
                {
                    if(result.OperationSuccess)
                    {
                        return Json(new
                        {
                            Success = true,
                            Message = "Nom de domaine disponible"
                        }, JsonRequestBehavior.AllowGet);
                    }
                    else if(result.ErrorType.HasValue)
                    {
                        string message = string.Empty;
                        switch(result.ErrorType.Value)
                        {
                            case DTO.Enum.ErrorType.EmptyRequest:
                                message = "Veuillez saisir un nom de domaine.";
                                break;
                            case DTO.Enum.ErrorType.Exist:
                                message = $"{url} est déjà enregistré.";
                                break;
                            case DTO.Enum.ErrorType.InvalidUrl:
                                message = "Le nom de domaine n'est pas valide. Veuillez le saisir à nouveau.";
                                break;
                        }

                        return Json(new
                        {
                            Success = false,
                            Message = message
                        }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new
                    {
                        Success = false,
                        Message = "Un problème est survenu lors de la connexion. Veuillez réessayer s’il vous plait."
                    }, JsonRequestBehavior.AllowGet);
                }
            }

            return Json(new
            {
                Success = false,
                Message = "Un problème est survenu lors de la connexion. Veuillez réessayer s’il vous plait."
            }, JsonRequestBehavior.AllowGet);
        }
    }
}