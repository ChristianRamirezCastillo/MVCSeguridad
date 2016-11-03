using AwSales.Repositorio;
using AwSales.Repositorio.Impl;
using AwSales.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AwSales.Web.Funcionalidades
{
    class ListarEmpleados : IDisposable
    {
        private readonly HumanResourcesRepositorio humanResourcesRepositorio;
        public ListarEmpleados()
        {
            humanResourcesRepositorio = new HumanResourcesRepositorio(
                            new AwHumanResourcesContexto()
                );
        }

        public void Dispose()
        {
            humanResourcesRepositorio.Dispose();
        }

        public IEnumerable<Models.ListaEmpleados> Ejecutar()
        {
            return humanResourcesRepositorio.Empleados
                     .TrerTodos().Select(e =>
                         new ListaEmpleados()
                         {
                             Id = e.BusinessEntityID,
                             NombreUsuario = e.LoginID,
                             Titulo = e.JobTitle,
                             FechaContrato =e.HireDate
                         }
                     ).ToList();
        }
    }
}
