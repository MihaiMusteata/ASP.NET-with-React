using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Entities.IBAN
{
     public class IBANData
     {
          public int Id { get; set; }
          public int Year { get; set; }
          public string IBAN { get; set; }
          public string EcoCode { get; set; }
          public string District { get; set; }
          public string Region { get; set; }
     }

     public class IBANValidator : AbstractValidator<IBANData>
     {
          public IBANValidator()
          {
               RuleFor(x => x.IBAN).NotEmpty().WithMessage("IBAN is required");
               RuleFor(x => x.EcoCode).NotEmpty().WithMessage("EcoCode is required");
               RuleFor(x => x.District).NotEmpty().WithMessage("District is required");
               RuleFor(x => x.Region).NotEmpty().WithMessage("Region is required");
               RuleFor(x => x.Year).NotEmpty().WithMessage("Year is required");

               RuleFor(x => x.IBAN).Must(x => x.ToUpper() == x).WithMessage("IBAN must be uppercase");
               RuleFor(x => x.IBAN).Must(x => x.Length == 24).WithMessage("IBAN must be 24 characters long");
               RuleFor(x => x.IBAN).Must(x => x.StartsWith("MD")).WithMessage("First 2 characters must be MD");
               RuleFor(x => x.IBAN).Must(iban => iban.Length >= 14 && iban.Substring(10).All(char.IsDigit)).WithMessage("Last 14 characters must be digits only");
          }
     }
}
