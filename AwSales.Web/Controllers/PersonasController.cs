using AwSales.Web.Filtros;
using AwSales.Web.Funcionalidades.ListarPersonas;
using AwSales.Web.Funcionalidades.RegistrarPersona;
using System;
using System.Web.Mvc;

namespace AwSales.Web.Controllers
{
    [MiAutorizacion]
    public class PersonasController : Controller
    {
        [AllowAnonymous]
        public ActionResult Lista(string filtro)
        {
            using (var listarPersonas = new ListarPersonaHandler())
            {

                return View(new FiltrarPersonasViewModel()
                {
                    Filtro = string.Empty,
                    Personas = listarPersonas.Ejecutar(filtro)
                });
            }
        }

        public PartialViewResult FiltrarPorNombre(string filtro)
        {
            using (var listarPersonas = new ListarPersonaHandler())
            {

                return PartialView("_PersonasEncontradas",
                        listarPersonas.Ejecutar(filtro)
                    );
            }
        }

        [HttpGet]
        public ActionResult Registrar()
        {
            return View(new RegistrarPersonaViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registrar(RegistrarPersonaViewModel modelo)
        {
            if (!ModelState.IsValid) return View(modelo);

            using (var registrarPersona = new RegistrarPersonaHandler())
            {
                try
                {
                    registrarPersona.Ejecutar(modelo);
                    return RedirectToAction("Lista");

                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(modelo);
                }

            }
        }

        [HttpGet]
        public PartialViewResult Editar(int id)
        {
            using (var buscarPersona = new VerPersonaHandler())
            {
                return PartialView("_Editar", buscarPersona.Execute(id));
            }
        }

        [HttpPost]
        public ActionResult Editar(ListaPersonasViewModel model)
        {
            return RedirectToAction("Lista");
        }

    }
}