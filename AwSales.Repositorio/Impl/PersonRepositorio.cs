using AwSales.Modelo;
using System.Data.Entity;
using System;
using AwSales.Modelo.HumanResources;
using AwSales.Modelo.Person;

namespace AwSales.Repositorio.Impl
{
    public class PersonRepositorio : IDisposable
    {
        private readonly DbContext bd;

        private readonly RepositorioGenerico<Person> _personas;

        public PersonRepositorio(DbContext bd)
        {
            this.bd = bd;
            _personas = new RepositorioGenerico<Person>(bd);
        }

        public RepositorioGenerico<Person> Personas { get { return _personas; } }

        public void Commit()
        {
            bd.SaveChanges();
        }

        public void Dispose()
        {
            bd.Dispose();
        }
    }
}