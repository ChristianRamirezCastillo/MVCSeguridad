namespace System.ComponentModel.DataAnnotations
{
    public class ValidaLimiteAttribute : ValidationAttribute
    {
        public ValidaLimiteAttribute(string propiedadBase, double porcentaje)
        {
            this.PropiedadBase = propiedadBase;
            this.Porcentaje = porcentaje;
            this.ErrorMessage = "{0} no puede ser superior al {1}% de {2}";
        }

        public double Porcentaje { get; set; }
        public string PropiedadBase { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            double monto = Convert.ToDouble(value);

            var infoPropiedad = validationContext.ObjectType.GetProperty(this.PropiedadBase);

            if (infoPropiedad != null )
            {
                double valorbase = Convert.ToDouble(infoPropiedad.GetValue(validationContext.ObjectInstance, null));

                double limitePermitido = valorbase * this.Porcentaje / 100;
                if (monto <= limitePermitido) return ValidationResult.Success;
            }

            return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(ErrorMessage, name, Porcentaje, PropiedadBase);
        }
    }
}
