using FluentValidation.Attributes;
using System.ComponentModel.DataAnnotations;

namespace AwSales.Web.Funcionalidades.RegistrarPersona
{
    [Validator(typeof(RegistraPersonaViewModelValidator))]
    public class RegistrarPersonaViewModel
    {
        [Display(Name = "Tipo")]
        public string PersonType { get; set; }

        [Display(Name = "Estilo")]
        public bool NameStyle { get; set; }

        [Display(Name = "Titulo")]
        public string Title { get; set; }

        [Display(Name = "Primer Nombre")]
        public string FirstName { get; set; }

        [Display(Name = "Segundo Nombre")]
        public string MiddleName { get; set; }

        [Display(Name = "Apellido")]
        public string LastName { get; set; }

        [Display(Name = "Sufijo")]
        public string Suffix { get; set; }

        [Display(Name = "Promociones")]
        public int EmailPromotion { get; set; }

        public decimal Salario { get; set; }

        //[ValidaLimite("Salario",45)]
        public decimal DescuentoJudicial { get; set; }

    }
}
