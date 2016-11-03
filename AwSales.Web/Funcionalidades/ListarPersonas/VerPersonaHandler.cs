using AwSales.Repositorio;
using AwSales.Repositorio.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwSales.Web.Funcionalidades.ListarPersonas
{
    class VerPersonaHandler : IDisposable
    {
        private readonly PersonRepositorio repositorio;

        public VerPersonaHandler()
        {
            repositorio = new PersonRepositorio(new AwPersonContexto());
        }


        public ListaPersonasViewModel Execute(int id)
        {
            var persona = repositorio.Personas.TraerUno(x => x.BusinessEntityID == id);
            return new ListaPersonasViewModel()
            {
                Id = persona.BusinessEntityID,
                Nombre = persona.FirstName + " " + persona.LastName,

                Titulo = persona.Title,
                CorreoElectronico = persona.EmailAddress.FirstOrDefault().EmailAddress1

            };
        }
        public void Dispose()
        {
            repositorio.Dispose();
        }
    }
}
