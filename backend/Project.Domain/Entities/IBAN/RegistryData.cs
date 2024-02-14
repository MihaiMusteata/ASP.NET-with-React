using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Entities.IBAN
{
     public class RegistryData
     {
          public byte[] Content { get; set; }
          public string FileName { get; set; }
          public string ContentType { get; set; }
     }
}
