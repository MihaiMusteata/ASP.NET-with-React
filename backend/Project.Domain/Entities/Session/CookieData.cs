using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Entities.Session
{
     public class CookieData
     {
          public CookieOptions Options { get; set; }
          public string Key { get; set; }
          public string Value { get; set; }
     }
}
