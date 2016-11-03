using AwSales.Web.Filtros;
using AwSales.Web.Funcionalidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AwSales.Web.Controllers
{
    public class EmpleadosController : Controller
    {
        // GET: Empleados
        public ActionResult Lista()
        {
            //ActionExecuting

            using (var listarEmpleados = new ListarEmpleados())
            {
                // ActionExecuted
                //ResultExecuting
                return View(listarEmpleados.Ejecutar());
                // ResultExecuted
            }
        }

    }
}