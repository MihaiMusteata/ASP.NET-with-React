using Project.Domain.Entities.Enums;

namespace Project.Api.Models
{
     public class UserSignup
     {
          public string Email { get; set; }
          public string Username { get; set; }
          public string Password { get; set; }
          public string ConfirmPassword { get; set; }
          public string Gender { get; set; }
          public string District { get; set; }
          public string Region { get; set; }
          public string LoginIp { get; set; }
          public DateTime LoginDateTime { get; set; }
          public URole Level { get; set; }

     }
}
