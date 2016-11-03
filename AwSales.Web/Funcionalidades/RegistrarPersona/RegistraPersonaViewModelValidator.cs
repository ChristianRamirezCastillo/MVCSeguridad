using System;
using FluentValidation;

namespace AwSales.Web.Funcionalidades.RegistrarPersona
{
    public class RegistraPersonaViewModelValidator : AbstractValidator<RegistrarPersonaViewModel>
    {
        public RegistraPersonaViewModelValidator()
        {
            RuleFor(modelo => modelo.FirstName)
                .NotEmpty()
                .Length(2, 50)
                .WithMessage("El primer nombre debe tener una longitud entre 2 a 50 carateres");

            RuleFor(modelo => modelo.MiddleName)
                .NotEmpty()
                .Length(2, 50)
                .WithMessage("El segundo nombre debe tener una longitud entre 2 a 50 carateres");


            RuleFor(modelo => modelo.LastName)
                .NotEmpty()
                .Length(2, 50)
                .WithMessage("El apellido debe tener una longitud entre 2 a 50 carateres");


            RuleFor(modelo => modelo.Suffix)
                .Length(0, 10)
                .WithMessage("El segundo nombre debe tener una longitud entre 2 a 50 carateres");

            RuleFor(modelo => modelo.Title)
                .Length(0, 8)
                .WithMessage("El segundo nombre debe tener una longitud entre 2 a 50 carateres");


            RuleFor(modelo => modelo.Salario)
                .GreaterThan(0)
                .WithMessage("El Salario debe ser superior a Cero");


            RuleFor(modelo => modelo.DescuentoJudicial)
                .Must(ValidaDescuento)
                .WithMessage("El Descuento es invalido");

        }

        private bool ValidaDescuento(RegistrarPersonaViewModel modelo, decimal descuento)
        {
            return (descuento <= (modelo.Salario * 0.45m));
        }
    }
}
