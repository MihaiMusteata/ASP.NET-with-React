namespace Project.Api.Models
{
     public class UserSignup
     {
          public string Email { get; set; }
          public string Username { get; set; }
          public string Password { get; set; }
          public string ConfirmPassword { get; set; }
          public string Gender { get; set; }
          public string LoginIp { get; set; }
          public DateTime LoginDateTime { get; set; }

     }
}
