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
    public class AdministradorController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Index(Administrador model, string Usu, string pass)
        {
            Usermodel Admin = new Usermodel();
            var ValidaLogin = Admin.LoginAdmin(Usu, pass);

            if (ModelState.IsValid)
            {
                if (ValidaLogin == true)
                {
                    return View("EntradaAdmin");
                }
                else
                {
                    ViewBag.mess = "El Usuario o La Contraseña incorrecta";
                    return View(model);
                }

            }
            else
            {
                return View(model);
            }
        }
        [Authorize]
        public IActionResult EntradaAdmin()
        {
            return View();
        }
    }
}