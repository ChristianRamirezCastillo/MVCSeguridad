using AwSales.Repositorio;
using AwSales.Repositorio.Impl;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AwSales.Web.Funcionalidades.ListarPersonas
{
    class ListarPersonaHandler : IDisposable
    {
        private readonly PersonRepositorio personRepositorio;
        public ListarPersonaHandler()
        {
            personRepositorio = new PersonRepositorio(
                            new AwPersonContexto()
                );
        }

        public void Dispose()
        {
            personRepositorio.Dispose();
        }

        public IEnumerable<ListaPersonasViewModel> Ejecutar(string filtro)
        {
            var consulta = personRepositorio.Personas.TrerTodos();


            if (!string.IsNullOrEmpty(filtro))
                consulta = consulta
                    .Where(x =>
                    x.FirstName.Contains(filtro) ||
                    x.LastName.Contains(filtro)
                    );

            return consulta.Select(e =>
                          new ListaPersonasViewModel()
                          {
                              Id = e.BusinessEntityID,
                              Nombre = e.FirstName + " " + e.LastName,

                              Titulo = e.Title,
                              CorreoElectronico = e.EmailAddress.FirstOrDefault().EmailAddress1

                             //string.Join(",", e.EmailAddress.Select(x=>x.EmailAddress1).ToArray())
                         }
                      ).Take(100).ToList();
        }
    }
}
