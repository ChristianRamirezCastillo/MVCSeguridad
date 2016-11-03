using AwSales.Modelo.Person;
using AwSales.Repositorio;
using AwSales.Repositorio.Impl;
using System;

namespace AwSales.Web.Funcionalidades.RegistrarPersona
{
    class RegistrarPersonaHandler : IDisposable
    {
        private readonly PersonRepositorio personaRepositorio;

        public RegistrarPersonaHandler()
        {
            personaRepositorio = new PersonRepositorio(new AwPersonContexto());
        }

        public void Ejecutar(RegistrarPersonaViewModel modelo)
        {
            // crear el objeto del modelo dominio Person
            validaEmailPromotion(modelo);
            ValidaTipoPersona(modelo);
            Person persona = CreaPersona(modelo);
            // Ejecutar validaciones de Negocio
            // grabar la persona
            personaRepositorio.Personas.Agregar(persona);
            personaRepositorio.Commit();
        }

        private Person CreaPersona(RegistrarPersonaViewModel modelo)
        {
            return new Person()
            {
                FirstName = modelo.FirstName,
                LastName = modelo.LastName,
                MiddleName = modelo.MiddleName,
                NameStyle = modelo.NameStyle,
                Title = modelo.Title,
                Suffix = modelo.Suffix,
                PersonType = modelo.PersonType,
                EmailPromotion = modelo.EmailPromotion,
                rowguid = Guid.NewGuid(),
                ModifiedDate = DateTime.Now,
                BusinessEntity = new BusinessEntity()
                {
                    rowguid = Guid.NewGuid(),
                    ModifiedDate = DateTime.Now
                }
            };
        }

        private void ValidaTipoPersona(RegistrarPersonaViewModel modelo)
        {
            if (!string.IsNullOrEmpty(modelo.PersonType) &&
                (modelo.PersonType != "SC" && modelo.PersonType != "IN" &&
                modelo.PersonType != "SP" &&
                modelo.PersonType != "EM" && modelo.PersonType != "VC" &&
                modelo.PersonType != "GC")) throw new Exception("Tipo de Persona inválido");
        }

        private void validaEmailPromotion(RegistrarPersonaViewModel modelo)
        {
            if (modelo.EmailPromotion < 0 || modelo.EmailPromotion > 2) throw new Exception("Email Promotion invalido");
        }

        public void Dispose()
        {
            personaRepositorio.Dispose();
        }
    }
}