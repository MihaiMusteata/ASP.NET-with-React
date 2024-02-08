using Project.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Entities.User
{
     public class USignupData
     {
          public string Email { get; set; }
          public string Username { get; set; }
          public string Password { get; set; }
          public string ConfirmPassword { get; set; }
          public string Gender { get; set; }
          public string Distrcit { get; set; }
          public string Region { get; set; }
          public string LoginIp { get; set; }
          public DateTime LoginDateTime { get; set; }
          public URole Level { get; set; }   
     }
}
