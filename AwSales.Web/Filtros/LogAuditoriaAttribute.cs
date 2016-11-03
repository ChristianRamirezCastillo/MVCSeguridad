using log4net;
using Microsoft.AspNet.Identity;
using System;
using System.Reflection;
using System.Web.Mvc;

namespace AwSales.Web.Filtros
{
    public class LogAuditoriaAttribute : ActionFilterAttribute
    {
        private static ILog Log { get; set; }

        public LogAuditoriaAttribute()
        {
            Log = LogManager
                .GetLogger(MethodBase.GetCurrentMethod().Name);
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
             => LogMensaje(filterContext, "OnActionExecuted");

        public override void OnResultExecuted(ResultExecutedContext filterContext)
            => LogMensaje(filterContext, "OnResultExecuted");

        private void LogMensaje(ControllerContext filterContext, string metodo)
        {
            var controller = filterContext.RouteData.Values["controller"];
            var action = filterContext.RouteData.Values["action"];
            var usuario = filterContext.HttpContext.User;
            Log.Info($"Usuario {usuario.NombreUsuario()} ingreso a {metodo} del {controller}.{action}");
        }
    }
}
