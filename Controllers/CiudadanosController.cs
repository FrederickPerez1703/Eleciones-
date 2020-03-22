using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Elecciones_itla.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Elecciones_itla.Controllers
{
    public class CiudadanosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Ciudadanos model, string cedu)
        {
            Usermodel User = new Usermodel();

            var ValidaLogin = User.LoginUser(cedu);
            if (ModelState.IsValid)
            {
                if (ValidaLogin == true)
                {
                    return View("Entrada");
                }
                else
                {
                    ViewBag.mess = "El usuario o la contraseña es incorrecta";
                    return View(model);
                }

            }
            else
            {
                return View(model);
            }
          
        }
        [Authorize]
        public IActionResult Entrada()
        {
            return View();
        }
    }
}