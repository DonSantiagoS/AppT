using AppT.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

using AppT.Services;

namespace AppT.Controllers
{
    public class HomeController : Controller
    {
        private readonly ServicioApi servicioApi;

        public HomeController(ServicioApi servicioApi)
        {
            this.servicioApi = servicioApi;
        }

        public async Task<IActionResult> Index()
        {
            List<Register> Lista = await servicioApi.Lista();

            return View(Lista);
        }
        public async Task<IActionResult> Registro(String TitleRegister)
        {
            Register register = new Register();
            ViewBag.Accion = "Nuevo Registro";

            if (TitleRegister != null)
            {
                register = await servicioApi.Obtener(TitleRegister);
                ViewBag.Accion = "Editar Registro";
            }
            return View(register);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}