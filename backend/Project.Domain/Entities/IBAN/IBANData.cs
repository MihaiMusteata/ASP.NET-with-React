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
}
