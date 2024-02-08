using Project.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Entities.User
{
     public class UserMinimal
     {
          public int Id { get; set; }
          public string Username { get; set; }
          public string Email { get; set; }
          public string Gender { get; set; }
          public string District { get; set; }
          public string Region { get; set; }
          public URole Level { get; set; }
     }
}
