using Project.Domain.Entities.User;
using Project.Domain.Entities.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BusinessLogic.Interfaces
{
     public interface ISession
     {
          PostResponse UserSignup(USignupData data);
          PostResponse UserLogin(ULoginData data);
          PostResponse UserLogout(int userId);
          UserMinimal GetUserByCookie(string apiCookieValue);
          CookieData GenCookie(string loginCredential);
     }
}
