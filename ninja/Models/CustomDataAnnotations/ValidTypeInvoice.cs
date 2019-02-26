using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ninja.Models.CustomDataAnnotations
{
    public class ValidTypeInvoice : ValidationAttribute
    {
        /// <summary>
        /// Devuelve si es correcto lo ingresado en el campo Type
        /// </summary>
        /// <param name="value"></param>
        /// <param name="validationContext"></param>
        /// <returns></returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var validTypes = new List<string> { "A", "B", "C" };
            string currentValue = Convert.ToString(value).ToUpper().Trim();
            
            //Primero revisamos si es mayor a 1 CARACTER y luego si esta contenido en los valores correctos. (NO VALIDO)
            if (currentValue.Length > 1 || !validTypes.Contains(currentValue))
            {
                return new ValidationResult("Debe elegir un tipo de factura válido.");
            }
            return ValidationResult.Success;
        }
    }
}